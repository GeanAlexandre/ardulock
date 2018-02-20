using System;

namespace ArduLock.Communication.Server
{
    public interface IServerHub
    {
        void Send(string message);
    }
}
