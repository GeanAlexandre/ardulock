using ArduLock.Communication.Server;
using System;
using System.ServiceProcess;
using System.Threading;

namespace ArduLock.WindowsService
{
    partial class Startup : ServiceBase
    {
        public Startup()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            new Thread(() =>
            {
                var server = new TcpServerHub(LocalHubConnection.Factory());

                while (true)
                {
                    server.Send(Guid.NewGuid().ToString());
                }

            }).Start();
        }

        protected override void OnStop()
        {
        }
    }
}
