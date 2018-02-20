using ArduLock.Communication.Server;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ArduLock.Communication.Client
{
    public class TcpClientHub : IClientHub
    {
        private readonly IHubConnection _hubConnection;

        public TcpClientHub(IHubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }

        public void Listener(Action<string> subscribe, Action<Exception> onError = null)
        {
            void AskForever(Action action) { while (true) action?.Invoke(); }

            AskForever(() =>
            {
                try
                {
                    using (var tcpclnt = new TcpClient(_hubConnection.Connection.ip.ToString(), _hubConnection.Connection.port))
                    using (var stm = tcpclnt.GetStream())
                    using (var ms = new MemoryStream())
                    {
                        stm.CopyTo(ms);
                        var line = Encoding.UTF8.GetString(ms.ToArray());
                        subscribe?.Invoke(line);
                    }

                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex);
                }
            });
        }
    }
}
