using ArduLock.Communication.Client;
using ArduLock.Communication.Server;
using ArduLock.Core;
using ArduLock.Core.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArduLock.App.Client
{
    class Program
    {
        private static Queue<int> LastPositions = new Queue<int>();

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

                    if (int.TryParse(msg, out int distance))
                        AddPosition(distance);

                    Console.WriteLine($"Distance {distance} cm");
                    LockScreen();
                    Console.ResetColor();

                }, ex =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                });
        }

        private static void LockScreen()
        {
            if (!PositionsIsFull()) return;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Locked");
            Console.ResetColor();
            LockScreenManager.Use(new WindowsUser32LockStationStrategy(), m => m.LockNow());
            LastPositions.Clear();
        }

        private static bool PositionsIsFull()
        {
            return HasFullPositionSlots() && LastPositions.All(x => x > 120);
        }

        private static bool HasFullPositionSlots()
        {
            return LastPositions.Count == 5;
        }

        private static void AddPosition(int position)
        {
            LastPositions.Enqueue(position);
        }

        private static void DequeueWhenFull()
        {
            if (HasFullPositionSlots())
                LastPositions.Dequeue();
        }
    }
}
