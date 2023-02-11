using Importer2Web.Aim;
using Importer2Web.Clients;
using Importer2Web.Images;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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

        public MsacBridge(MsacConfigFile configFile, MsacSystemConfig systemConfig, MsacBridgeConfig bridgeConfig, IWebImageCategory storeIcons, IWebImageCategory storeCache)
        {
            //Set
            this.configFile = configFile;
            this.systemConfig = systemConfig;
            this.bridgeConfig = bridgeConfig;
            this.storeIcons = storeIcons;
            this.storeCache = storeCache;

            //Get the default station icon
            if (!storeIcons.TryGetAsset(bridgeConfig.Id + ".jpg", out defaultIcon))
                throw new Exception("The default station icon is missing. Was it moved?");

            //Set up server
            server = new AimServer(bridgeConfig.DataPort);
            server.OnMessageReceived += Server_OnMessageReceived;
            server.OnSocketError += Server_OnSocketError;

            //Create outputs
            foreach (var o in bridgeConfig.Outputs)
            {
                if (o.TryResolve(out IOutputClientFactory outputFactory))
                    outputs.Add(outputFactory.CreateOutputClient(o.Config));
            }

            //Start server
            try
            {
                server.Start();
                serverReady = true;
            } catch
            {
                serverReady = false;
                MsacLogger.Log(MsacLogger.LogLevel.Errr, bridgeConfig.Id, $"Unable to bind to port {bridgeConfig.DataPort}. Is it already being used?");
            }
        }

        private readonly MsacConfigFile configFile;
        private readonly MsacSystemConfig systemConfig;
        private readonly MsacBridgeConfig bridgeConfig;
        private readonly IWebImageCategory storeIcons;
        private readonly IWebImageCategory storeCache;

        private readonly AimServer server;
        private readonly bool serverReady;
        private readonly IWebImage defaultIcon;
        private readonly List<IOutputClient> outputs = new List<IOutputClient>();

        private volatile PlayoutItem currentItem;

        public MsacConfigFile ConfigFile => configFile;
        public MsacSystemConfig SystemConfig => systemConfig;
        public MsacBridgeConfig BridgeConfig => bridgeConfig;
        public IWebImage DefaultImage => defaultIcon;
        public bool SocketReady => serverReady;
        public PlayoutItem CurrentItem => currentItem;

        public event StartedUpdatedEventArgs OnUpdateStarted;
        public event FinishedUpdatedEventArgs OnUpdateFinished;

        public void Shutdown()
        {
            //Log
            MsacLogger.Log(MsacLogger.LogLevel.Info, bridgeConfig.Id, "Shutting down...");

            //Send to server
            server.Dispose();
        }

        private void Server_OnSocketError(AimServer server, Exception ex)
        {
            //Log
            MsacLogger.Log(MsacLogger.LogLevel.Warn, bridgeConfig.Id, $"Network error: {ex.Message}");
        }

        private void Server_OnMessageReceived(AimServer server, AimPlayoutItem item)
        {
            //Handle image
            IWebImage image = defaultIcon;
            if (item.Image != null && item.Image.Length > 0)
            {
                //Parse Base-64 encoded image
                byte[] imageData = Convert.FromBase64String(item.Image);

                //Upload image
                image = storeCache.UploadAsset(imageData);
            }

            //Set metadata
            currentItem = new PlayoutItem(item.Artist, item.Title, item.Id, item.Type, item.DurationParsed, image);

            //Log
            MsacLogger.Log(MsacLogger.LogLevel.Info, bridgeConfig.Id, "Sending update: " + currentItem.ToDebugString());

            //Send event
            OnUpdateStarted?.Invoke(this);

            //Send to destinations
            bool success = true;
            foreach (var o in outputs)
            {
                try
                {
                    o.SendUpdate(currentItem);
                }
                catch
                {
                    success = false;
                    MsacLogger.Log(MsacLogger.LogLevel.Warn, bridgeConfig.Id, $"Output destination \"{o.Name}\" failed!");
                }
            }

            //Send success event
            OnUpdateFinished?.Invoke(this, success);
        }
    }
}
