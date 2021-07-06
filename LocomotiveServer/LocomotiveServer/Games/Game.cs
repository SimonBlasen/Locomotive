﻿using CubeRacerServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Schema;
using UDPServer.UDPServer;

namespace LocomotiveServer.Games
{

    public class Game
    {
        

        private Server server;
        private int port = 0;
        private System.Timers.Timer timer;
        private int timerCounter = 0;

        private Player[] players;
        private bool[] connectedPlayers;

        


        public Game(Server server, int runningPort)
        {
            this.port = runningPort;
            this.server = server;
            server.ReceiveUdpData += ReceiveBytes;

            timer = new System.Timers.Timer();
            timer.Interval = 10.0;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            players = new Player[255];
            connectedPlayers = new bool[255];

            for (int i = 0; i < connectedPlayers.Length; i++)
            {
                connectedPlayers[i] = false;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            doTimerOperation();
        }

        private void doTimerOperation()
        {
            timerCounter++;
            if (timerCounter >= 256 * 256)
            {
                timerCounter = 0;
            }

            
        }

        public void ReceiveBytes(IPAddress ip, int port, byte[] data)
        {
            if (data.Length >= 3)
            {
                byte playerID = data[2];

                if (connectedPlayers[data[2]])
                {
                    players[data[2]].NoMessageFor = 0f;
                }


                // Connect
                if (data[0] == 0 && data[1] == 0)
                {
                    Program.Write("Got message: " + data.Length.ToString());

                    server.SendUdp(ip, port, data);
                }
            }
        }
    }
}
