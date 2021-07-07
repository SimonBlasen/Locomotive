using CubeRacerServer;
using LocomotiveServer.Infrastructure;
using LocomotiveServer.utils;
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

        private PlayersManager playersManager;
        private PingsMeasure pingsMeasure;

        public delegate void TimerElapsEvent(float passedTime, int timerCounter);
        public event TimerElapsEvent TimerElapsed;

        private List<MessageListener> messageListeners = new List<MessageListener>();

        public Game(Server server, int runningPort)
        {
            this.port = runningPort;
            this.server = server;
            server.ReceiveUdpData += ReceiveBytes;

            timer = new System.Timers.Timer();
            timer.Interval = 10.0;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            playersManager = new PlayersManager();
            pingsMeasure = new PingsMeasure(playersManager, server);

            // Not neccessary, but for testing purpose
            TimerListener timerListenerPlayersManager = (TimerListener)playersManager;
            TimerElapsed += timerListenerPlayersManager.TimerElapsed;

            TimerElapsed += pingsMeasure.TimerElapsed;

            messageListeners.Add(playersManager);
            messageListeners.Add(pingsMeasure);

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

            TimerElapsed?.Invoke(((float)timer.Interval) / 1000f, timerCounter);
        }

        public void ReceiveBytes(IPAddress ip, int port, byte[] data)
        {
            if (data.Length >= 3)
            {
                // Connect
                if (data[0] == 0 && data[1] == 0)
                {

                    Player newPlayer = playersManager.AddNewPlayer();

                    if (newPlayer != null)
                    {
                        Program.Write("Player connected. ID: [" + newPlayer.ID.ToString() + "]");

                        byte[] sendBack = new byte[3];
                        sendBack[0] = 128;
                        sendBack[1] = 0;
                        sendBack[2] = newPlayer.ID;

                        server.SendUdp(ip, port, sendBack);
                    }
                    else
                    {
                        Program.Write("Player couldn't connect, server is full");
                    }
                }
                else
                {
                    if (playersManager.IsPlayerConnected(data[2]))
                    {
                        foreach (MessageListener listener in messageListeners)
                        {
                            listener.RecMessage(ip, port, data);
                        }

                        // Passthrough Train
                        if (data[0] == 0 && data[1] == 1)
                        {
                            data[0] = 128;
                            data[1] = 1;

                            server.SendUdpAll(data);
                        }
                    }
                }
            }
        }
    }
}
