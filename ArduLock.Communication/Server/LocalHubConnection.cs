using System.Net;

namespace ArduLock.Communication.Server
{
    public class LocalHubConnection : IHubConnection
    {
        public static LocalHubConnection Factory() => new LocalHubConnection();
        private LocalHubConnection() { }
        public (IPAddress ip, int port) Connection => (IPAddress.Parse("127.0.0.1"), 8001);
    }
}
