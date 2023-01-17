using Importer2Web.Clients;
using LibMsacServer;
using LibMsacServer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Importer2Web
{
    public class MsacBridge
    {
        public delegate void StartedUpdatedEventArgs(MsacBridge bridge);
        public delegate void FinishedUpdatedEventArgs(MsacBridge bridge, bool success);

        public MsacBridge(MsacConfigFile configFile, MsacSystemConfig systemConfig, MsacBridgeConfig bridgeConfig)
        {
            //Set
            this.configFile = configFile;
            this.systemConfig = systemConfig;
            this.bridgeConfig = bridgeConfig;
            defaultIcon = new DefaultIcon(this);

            //Set up server
            server = new MsacServer(new IPEndPoint(IPAddress.Any, bridgeConfig.MsacPort));
            server.OnDirectFileCopyRequest += Server_OnDirectFileCopyRequest;
            server.OnAsyncSendRequest += Server_OnAsyncSendRequest;
            server.OnPsdUpdateRequest += Server_OnPsdUpdateRequest;
            server.OnSocketError += Server_OnSocketError;

            //Do some cleanup of the disk. Delete any files in the temp directory
            if (TempWebDirectory.Exists)
            {
                TempWebDirectory.Delete(true);
                TempWebDirectory.Create();
            }

            //Create outputs
            if (bridgeConfig.CirrusEnabled)
                outputs.Add(new CirrusOutputClient(bridgeConfig.CirrusDomain, bridgeConfig.CirrusCallLetters, bridgeConfig.CirrusAuthToken, bridgeConfig.CirrusDefaultDuration));

            //Start worker thread
            if (server.SocketReady)
            {
                worker = new Thread(server.Run);
                worker.Name = "Worker Thread";
                worker.Start();
            } else
            {
                //Log
                MsacLogger.Log(MsacLogger.LogLevel.Errr, bridgeConfig.Id, $"Unable to bind to port {bridgeConfig.MsacPort}. Is it already being used?");
            }
        }

        private readonly MsacConfigFile configFile;
        private readonly MsacSystemConfig systemConfig;
        private readonly MsacBridgeConfig bridgeConfig;
        private readonly MsacServer server;
        private readonly Thread worker;
        private readonly Dictionary<int, TempIcon> lots = new Dictionary<int, TempIcon>();
        private readonly object metadataMutex = new object();
        private readonly DefaultIcon defaultIcon;
        private readonly List<IMetadataOutputClient> outputs = new List<IMetadataOutputClient>();

        private int? currentLot;
        private string currentTitle;
        private string currentArtist;
        private string currentAlbum;

        public MsacConfigFile ConfigFile => configFile;
        public MsacSystemConfig SystemConfig => systemConfig;
        public MsacBridgeConfig BridgeConfig => bridgeConfig;
        public IMsacImage DefaultImage => defaultIcon;
        public bool SocketReady => server.SocketReady;

        public IMsacImage CurrentImage
        {
            get
            {
                IMsacImage image = defaultIcon;
                lock (metadataMutex)
                {
                    if (currentLot.HasValue && lots.TryGetValue(currentLot.Value, out TempIcon tempImage))
                        image = tempImage;
                }
                return image;
            }
        }
        public string CurrentTitle => currentTitle;
        public string CurrentArtist => currentArtist;
        public string CurrentAlbum => currentAlbum;

        public event StartedUpdatedEventArgs OnUpdateStarted;
        public event FinishedUpdatedEventArgs OnUpdateFinished;

        private DirectoryInfo WebDirectory => new DirectoryInfo(systemConfig.WebDirectory).CreateSubdirectory(bridgeConfig.Id);
        private DirectoryInfo TempWebDirectory => WebDirectory.CreateSubdirectory("temp");

        public void Shutdown()
        {
            //Log
            MsacLogger.Log(MsacLogger.LogLevel.Info, bridgeConfig.Id, "Shutting down...");

            //Send to server
            server.Dispose();
        }

        private void Server_OnDirectFileCopyRequest(MsacServer server, string filename, byte[] data)
        {
            //Determine filename on disk
            string safeName = EscapeFilename(filename);
            string diskFilename = TempWebDirectory.FullName + Path.DirectorySeparatorChar + safeName;

            //Write to disk
            File.WriteAllBytes(diskFilename, data);
        }

        private void Server_OnAsyncSendRequest(MsacServer server, HdOutgoingImage image)
        {
            lock (metadataMutex)
            {
                if (lots.ContainsKey(image.LotId))
                    lots.Remove(image.LotId);
                lots.Add(image.LotId, new TempIcon(this, image.FileName, image.Duration));
            }
        }

        private void Server_OnPsdUpdateRequest(MsacServer server, HdPsd psd, HdXhdr xhdr)
        {
            //Set metadata
            lock (metadataMutex)
            {
                currentLot = xhdr.LotId;
                currentTitle = psd.Title;
                currentArtist = psd.Artist;
                currentAlbum = psd.Album;
            }

            //Log
            MsacLogger.Log(MsacLogger.LogLevel.Info, bridgeConfig.Id, $"Sending update: artist={psd.Artist}; title={psd.Title}; image={xhdr.LotId}");

            //Send event
            OnUpdateStarted?.Invoke(this);

            //Send to destinations
            bool success = true;
            foreach (var o in outputs)
            {
                try
                {
                    o.SendUpdate(CurrentTitle, CurrentArtist, CurrentAlbum, CurrentImage);
                } catch
                {
                    success = false;
                    MsacLogger.Log(MsacLogger.LogLevel.Warn, bridgeConfig.Id, $"Output destination \"{o.Name}\" failed!");
                }
            }

            //Send success event
            OnUpdateFinished?.Invoke(this, success);
        }

        private void Server_OnSocketError(MsacServer server, Exception ex)
        {
            //Log
            MsacLogger.Log(MsacLogger.LogLevel.Warn, bridgeConfig.Id, $"Network error: {ex.Message}");
        }

        private static string EscapeFilename(string filename)
        {
            //Trim off "./" at the beginning, if it exists
            if (filename.StartsWith("./"))
                filename = filename.Substring(2);

            //Replace all special characters
            char[] bad = Path.GetInvalidFileNameChars();
            char[] data = filename.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                if (bad.Contains(data[i]))
                    data[i] = '_';
            }
            return new string(data);
        }

        public static FileInfo GetDefaultImagePath(MsacSystemConfig system, string id)
        {
            return new FileInfo(new DirectoryInfo(system.WebDirectory).CreateSubdirectory(id).FullName + Path.DirectorySeparatorChar + "default.jpg");
        }

        class DefaultIcon : IMsacImage
        {
            public DefaultIcon(MsacBridge bridge)
            {
                this.bridge = bridge;
            }

            private readonly MsacBridge bridge;

            public FileInfo FileName => GetDefaultImagePath(bridge.systemConfig, bridge.bridgeConfig.Id);
            public string WebUrl => bridge.systemConfig.PublicUrl + "/" + HttpUtility.UrlEncode(bridge.bridgeConfig.Id) + "/default.jpg";
            public int Duration => 0;
        }

        class TempIcon : IMsacImage
        {
            public TempIcon(MsacBridge bridge, string filename, int duration)
            {
                this.bridge = bridge;
                this.filename = filename;
                this.duration = duration;
            }

            private readonly MsacBridge bridge;
            private readonly string filename;
            private readonly int duration;

            public FileInfo FileName => new FileInfo(bridge.TempWebDirectory.FullName + Path.DirectorySeparatorChar + EscapeFilename(filename));
            public string WebUrl => bridge.systemConfig.PublicUrl + "/" + HttpUtility.UrlEncode(bridge.bridgeConfig.Id) + "/temp/" + HttpUtility.UrlEncode(EscapeFilename(filename));
            public int Duration => duration;
        }
    }
}
