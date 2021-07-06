using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer.UDPClient
{
    public class RelMessage
    {
        public byte[] dataWLength;
        public int ackNumber;
        public int timeTillResend;
        public int resendsLeft;
    }
}
