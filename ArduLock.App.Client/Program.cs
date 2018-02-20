using ArduLock.Communication.Client;
using ArduLock.Communication.Server;
using ArduLock.Core;
using ArduLock.Core.Strategy;
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (!int.TryParse(msg, out int distance)) return;
                    if (distance <= 25 || distance > 3000) return;
                    Console.WriteLine($"Detected: {distance} cm");
                    if (distance <= 120) return;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Locked: {distance} cm");
                    LockScreenManager.Use(new WindowsUser32LockStationStrategy(), m => m.LockNow());
                    Console.ResetColor();

                }, (ex) =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                });
        }
    }
}
