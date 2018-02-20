using ArduLock.Core.Strategy;
using System;

namespace ArduLock.Core
{
    public class LockScreenManager
    {
        private readonly ILockWorkStationStrategy _lockWorkStationStrategy;

        private LockScreenManager(ILockWorkStationStrategy lockWorkStationStrategy)
        {
            _lockWorkStationStrategy = lockWorkStationStrategy;
        }

        public static void Use(ILockWorkStationStrategy lockWorkStationStrategy, Action<LockScreenManager> action)
        {
            action(new LockScreenManager(lockWorkStationStrategy));
        }

        public void LockNow()
        {
            _lockWorkStationStrategy.Lock();
        }
    }
}
