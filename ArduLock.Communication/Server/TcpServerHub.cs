using System.Net.Sockets;
using System.Text;

namespace ArduLock.Communication.Server
{
    public class TcpServerHub : IServerHub
    {

        private readonly IHubConnection _hubConnection;

        public TcpServerHub(IHubConnection hubConnection)
        {
            _hubConnection = hubConnection;
        }

        public void Send(string message)
        {
            var listerner = new TcpListener(_hubConnection.Connection.ip, _hubConnection.Connection.port);

            listerner.Start();

            var socket = listerner.AcceptSocket();
            var asen = new ASCIIEncoding();
            socket.Send(asen.GetBytes(message));

            socket.Close();
            listerner.Stop();

        }
    }
}
