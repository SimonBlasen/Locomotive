using LocomotiveServer.Games;
using LocomotiveServer.utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static LocomotiveServer.Games.Game;

namespace LocomotiveServer.Infrastructure
{
    public class PlayersManager : TimerListener, MessageListener
    {
        private const float timeout = 10f;

        private Player[] players;
        private bool[] connectedPlayers;

        public PlayersManager()
        {
            players = new Player[255];
            connectedPlayers = new bool[255];

            for (int i = 0; i < connectedPlayers.Length; i++)
            {
                connectedPlayers[i] = false;
            }
        }

        public void RecMessage(IPAddress ip, int port, byte[] data)
        {
            byte id = data[2];

            if (connectedPlayers[id])
            {
                players[id].NoMessageFor = 0f;
            }
        }

        public void TimerElapsed(float time, int timerCounter)
        {
            tickPlayersTimeout(time);
        }

        public Player AddNewPlayer()
        {
            byte newID = getNextFreePlayerID();
            if (newID == 255)
            {
                return null;
            }

            addNewPlayer(newID);

            return players[newID];
        }

        public void DisconnectPlayer(byte id)
        {
            connectedPlayers[id] = false;
            players[id] = null;

            Program.Write("Disconnected player [" + id.ToString() + "]");
        }






        private void addNewPlayer(byte id)
        {
            connectedPlayers[id] = true;
            players[id] = new Player(id);
        }

        private byte getNextFreePlayerID()
        {
            for (int i = 0; i < connectedPlayers.Length; i++)
            {
                if (!connectedPlayers[i])
                {
                    return (byte)i;
                }
            }

            return 255;
        }

        private void tickPlayersTimeout(float time)
        {
            for (int i = 0; i < connectedPlayers.Length; i++)
            {
                if (connectedPlayers[i])
                {
                    players[i].NoMessageFor += time;

                    if (players[i].NoMessageFor >= timeout)
                    {
                        DisconnectPlayer((byte)i);
                    }
                }
            }
        }
    }
}
