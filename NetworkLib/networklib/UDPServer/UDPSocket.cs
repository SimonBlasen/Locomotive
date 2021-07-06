using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace UDPServer.UDPServer
{
    public class UDPSocket
    {
        public const int SIO_UDP_CONNRESET = -1744830452;
        private UdpClient udpClient;
        private IPEndPoint groupEP;

        public delegate void ReceiveUdpMessage(IPAddress ip, int port, byte[] data);
        public event ReceiveUdpMessage ReceiveUdpData;

        private Thread pollThread;
        private int port;

        public UDPSocket(int port)
        {
            this.port = port;
            udpClient = new UdpClient(port);
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                udpClient.Client.IOControl((IOControlCode)SIO_UDP_CONNRESET, new byte[] { 0, 0, 0, 0 }, null);
            }
            groupEP = new IPEndPoint(IPAddress.Any, port);

            pollThread = new Thread(new ThreadStart(Poll));
            pollThread.Start();
        }

        public int Send(IPAddress ip, int port, byte[] data)
        {
            try
            {
                return udpClient.Send(data, data.Length, new IPEndPoint(ip, port));
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private bool terminatePollThread = false;

        public void Stop()
        {
            terminatePollThread = true;
            pollThread.Join();

            udpClient.Close();
        }

        private void Poll()
        {
            while (!terminatePollThread)
            {
                try
                {
                    groupEP = new IPEndPoint(IPAddress.Any, port);
                    byte[] bytes = udpClient.Receive(ref groupEP);

                    ReceiveUdpData(groupEP.Address, groupEP.Port, bytes);
                }
                catch (Exception ex)
                {
                    int sdjksdj = 0;
                }
            }
        }
    }
}
