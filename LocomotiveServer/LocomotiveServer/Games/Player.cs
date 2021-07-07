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


        public byte ID
        {
            get
            {
                return id;
            }
        }

    }
}
