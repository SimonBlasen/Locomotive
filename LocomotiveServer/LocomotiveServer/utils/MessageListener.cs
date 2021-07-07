using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace LocomotiveServer.utils
{
    public interface MessageListener
    {
        public void RecMessage(IPAddress ip, int port, byte[] data);
    }
}
