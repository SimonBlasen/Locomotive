using LocomotiveServer.Games;
using LocomotiveServer.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using UDPServer.UDPServer;

namespace LocomotiveServer.Infrastructure
{
    public class PingsMeasure : TimerListener, MessageListener
    {
        private PlayersManager playersManager;
        private Server server;

        private Stopwatch stopwatch;

        public PingsMeasure(PlayersManager playersManager, Server server)
        {
            this.playersManager = playersManager;
            this.server = server;
        }

        public void RecMessage(IPAddress ip, int port, byte[] data)
        {
            if (data[0] == 0 && data[1] == 2)
            {
                Player player = playersManager.GetPlayer(data[2]);

                player.AddPingMeasure(stopwatch.ElapsedMilliseconds / 1000f);
            }
        }

        public void TimerElapsed(float time, int timerCounter)
        {
            if (timerCounter % 100 == 0)
            {
                sendOutPings();
            }

            if (timerCounter % 199 == 0)
            {
                sendOutMeasurements();
            }
        }


        private void sendOutMeasurements()
        {
            List<byte> bytes = new List<byte>();
            bytes.Add(128);
            bytes.Add(3);

            for (int i = 0; i < playersManager.Players.Length; i++)
            {
                bytes.Add(playersManager.Players[i].ID);
                bytes.AddRange(BitConverter.GetBytes(playersManager.Players[i].Ping));
            }
            server.SendUdpAll(bytes.ToArray());
        }

        private void sendOutPings()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

            server.SendUdpAll(new byte[] { 128, 2, 0 });
        }
    }
}
