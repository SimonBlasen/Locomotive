using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer.UDPServer
{
    public class RecentAckMessage
    {
        public int ack;
        public int timeTillDelete;
    }
}
