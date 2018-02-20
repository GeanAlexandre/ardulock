using System.ServiceProcess;

namespace ArduLock.WindowsService
{
    static class Program
    {
        static void Main()
        {
            using (var startup = new Startup())
                ServiceBase.Run(startup);
        }
    }
}
