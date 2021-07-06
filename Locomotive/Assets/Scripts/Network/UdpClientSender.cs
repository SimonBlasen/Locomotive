using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CubeRacerServer
{
    public class UdpClientSender
    {
        private static Socket socket = null;
        private static IPEndPoint ep = null;

        public static void SendInsta(string ip, int port, byte[] data)
        {
            if (socket == null)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            }
            IPEndPoint epNew;

            IPHostEntry nameToIpAddress = Dns.GetHostEntry(ip);
            if (nameToIpAddress.AddressList.Length > 0)
            {
                int toTakeIndex = -1;
                for (int i = 0; i < nameToIpAddress.AddressList.Length; i++)
                {
                    if (nameToIpAddress.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        toTakeIndex = i;
                        break;
                    }
                }
                if (toTakeIndex != -1)
                {
                    IPAddress broadcast = IPAddress.Parse(nameToIpAddress.AddressList[toTakeIndex].ToString());

                    epNew = new IPEndPoint(broadcast, port);


                    byte[] dataWLength = new byte[data.Length + 3];
                    dataWLength[0] = (byte)(data.Length >> 8);
                    dataWLength[1] = (byte)(data.Length);
                    dataWLength[2] = 254;
                    for (int i = 0; i < data.Length; i++)
                    {
                        dataWLength[i + 3] = data[i];
                    }

                    if (ep == null || epNew.Address.Equals(ep.Address) == false || epNew.Port != ep.Port)
                    {
                        ep = epNew;
                    }

                    socket.SendTo(dataWLength, ep);

                }
            }
        }
    }
}