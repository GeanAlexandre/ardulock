using System;

namespace ArduLock.Communication.Client
{
    public interface IClientHub
    {
        void Listener(Action<string> subscribe, Action<Exception> onError);
    }
}
