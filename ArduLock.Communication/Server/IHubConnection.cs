using System.Net;

namespace ArduLock.Communication.Server
{
    public interface IHubConnection
    {
        (IPAddress ip, int port) Connection { get; }
    }
}
