using System.Runtime.InteropServices;

namespace ArduLock.Core.Strategy
{
    public class WindowsUser32LockStationStrategy : ILockWorkStationStrategy
    {
        [DllImport("user32")]
        private static extern void LockWorkStation();

        public void Lock()
        {
            LockWorkStation();
        }
    }
}
