using ArduLock.Communication.Client;
using ArduLock.Communication.Server;
using System;

namespace ArduLock.App.Client
{
    class Program
    {
        static void Main()
        {
            ClientRunning();
            Console.Read();
        }
        private static void ClientRunning()
        {
            new TcpClientHub(LocalHubConnection.Factory())
                .Listener(msg =>
                {
                    Console.WriteLine(msg);

                }, (ex) =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                });
        }
    }
}
