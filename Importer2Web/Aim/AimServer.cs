using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Importer2Web.Aim
{
    class AimServer : IDisposable
    {
        public AimServer(int listenPort)
        {
            this.listenPort = listenPort;
        }

        private readonly int listenPort;
        private readonly byte[] buffer = new byte[65536];

        private Socket server;
        private Thread worker;
        private volatile bool active = true;

        public event MessageEventArgs OnMessageReceived;
        public event SocketErrorEventArgs OnSocketError;

        public delegate void MessageEventArgs(AimServer server, AimPlayoutItem item);
        public delegate void SocketErrorEventArgs(AimServer server, Exception ex);

        public void Start()
        {
            //Make sure this isn't called twice
            if (worker != null)
                return;

            //Start server
            server = new Socket(SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, listenPort));
            server.Listen(2);

            //Start worker thread
            worker = new Thread(Worker);
            worker.IsBackground = true;
            worker.Start();
        }

        public void Dispose()
        {
            //This probably isn't the right way to do this...
            active = false;
            server.Close();
            server.Dispose();
        }

        private void Worker()
        {
            while (active)
            {
                try
                {
                    //Accept client
                    using (Socket sock = server.Accept())
                    {
                        //Begin getting packets
                        int length = 0;
                        while (true)
                        {
                            //Read
                            int read = sock.Receive(buffer, length, buffer.Length - length, SocketFlags.None);

                            //Update state
                            length += read;
                            if (length == buffer.Length)
                                throw new Exception("Client sent too much data!");

                            //Check if we're done
                            if (read == 0)
                            {
                                //Convert to string and parse as JSON
                                string messageString = Encoding.UTF8.GetString(buffer, 0, length);
                                IncomingData message = JsonConvert.DeserializeObject<IncomingData>(messageString);

                                //Send event
                                if (message != null && message.NowPlaying.Length >= 1 && message.NowPlaying[0] != null)
                                    OnMessageReceived?.Invoke(this, message.NowPlaying[0]);
                                else
                                    throw new Exception("Unexpected message format!");

                                break;
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    //Send events
                    OnSocketError?.Invoke(this, ex);
                }
            }
        }

        class IncomingData
        {
            public AimPlayoutItem[] NowPlaying { get; set; }
        }
    }
}
