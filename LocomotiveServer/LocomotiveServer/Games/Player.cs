using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocomotiveServer.Games
{
    public class Player
    {
        private byte id = 0;

        public Player(byte id)
        {
            this.id = id;
            AdditionalBytes = new byte[0];
            NoMessageFor = 0f;
        }

        public byte[] AdditionalBytes
        {
            get;set;
        }

        public float NoMessageFor
        {
            get;set;
        }

        private float[] pingMeasures = new float[16];
        private int runningPingMeasureIndex = 0;
        public void AddPingMeasure(float time)
        {
            pingMeasures[runningPingMeasureIndex] = time;
            runningPingMeasureIndex++;
            runningPingMeasureIndex %= pingMeasures.Length;

            float summedPing = 0f;
            for (int i = 0; i < pingMeasures.Length; i++)
            {
                summedPing += pingMeasures[i];
            }

            Ping = summedPing / pingMeasures.Length;
        }

        public float Ping
        {
            get; protected set;
        } = 0f;


        public byte ID
        {
            get
            {
                return id;
            }
        }

    }
}
