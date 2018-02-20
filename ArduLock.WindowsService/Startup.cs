using ArduLock.Communication.Server;
using System.IO.Ports;
using System.Linq;
using System.ServiceProcess;

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
            var port = SerialPort.GetPortNames().FirstOrDefault();
            var connect = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
            connect.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            connect.DtrEnable = true;
            connect.Open();

        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
             new TcpServerHub(LocalHubConnection.Factory()).Send((sender as SerialPort).ReadExisting());
        }

        protected override void OnStop()
        {
        }
    }
}
