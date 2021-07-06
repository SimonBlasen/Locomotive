using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPServer.UDPClient
{
    public class UDPSocket
    {
        public delegate void ReceiveUdpMessage(byte[] datas);
        public event ReceiveUdpMessage ReceiveUdpData;

        private static readonly Object lockObj = new Object();


        private string address;
        private int port;

        IPEndPoint ep;
        Socket socket;
        private Thread thread;

        public UDPSocket(string address, int port)
        {
            threadRunning = true;
            this.address = address;
            this.port = port;

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPHostEntry nameToIpAddress = Dns.GetHostEntry(address);
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

                    byte[] sendbuf = Encoding.ASCII.GetBytes("Hallo test");
                    ep = new IPEndPoint(broadcast, port);

                    //socket.SendTo(sendbuf, ep);

                    thread = new Thread(new ThreadStart(Process));
                    thread.Start();
                }
                else
                {
#if DEBUG_ENABLED
                Debug.LogException(new System.Exception("Failed to set up udp"));
#endif
                }
            }
            else
            {
                //TODO 
                // Could not solve hostname
#if DEBUG_ENABLED
            Debug.LogException(new System.Exception("Failed to set up udp"));
#endif
            }

        }

        public void Send(byte[] data)
        {
            //lock(lockObj)
            //{

            //if (socket != null)
            //{
                socket.SendTo(data, ep);
            //}

            //}

            /*
            byte[] dataWLength = new byte[data.Length + 2];
            dataWLength[0] = (byte)(data.Length >> 8);
            dataWLength[1] = (byte)(data.Length);
            for (int i = 0; i < data.Length; i++)
            {
                dataWLength[i + 2] = data[i];
            }

            socket.SendTo(dataWLength, ep);*/
        }

        public void Shutdown()
        {
            //socket.Disconnect(false);


            socket.Close();
                socket = null;

                threadRunning = false;
                //thread.Abort();
            

        }


        private bool threadRunning = true;


        private void Process()
        {
            int cnt = 0;
            MemoryStream mem = new MemoryStream();// Empfangspuffer
            byte[] buffer = new byte[2048 * 32];
            while (socket == null)
            {

            }
            while (threadRunning)
            {
                try
                {
                    //Debug.Log("While true");
                    while (socket.Available > 0)
                    {
                        //Debug.Log("Went in");
                        int bytesRead = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                        if (bytesRead <= 0) continue;


                        if (bytesRead >= 2048 * 16)
                        {
#if DEBUG_ENABLED
                    Debug.Log("SAPPHERROR: Critical udp buffer size: bytesRead=" + bytesRead);
#endif
                        }
                        mem.Write(buffer, 0, bytesRead);
                    }
                    if (mem.Length > 0 && socket.Available == 0)
                    {
                        ReceiveUdpData(mem.ToArray());
                        //form.Invoke(new MethodInvoker(delegate () { RecieveData(this, System.Text.Encoding.ASCII.GetString(mem.ToArray(), 0, mem.ToArray().Length), mem.ToArray()); }));
                        mem.Seek(0, SeekOrigin.Begin);
                        mem.SetLength(0);
                    }
                    else
                    {
                        cnt++;
                    }
                    Thread.Sleep(1);
                }
                catch (ObjectDisposedException ex)
                {
                    break;
                }


            }

            UnityEngine.Debug.Log("Exited Socket thread");
        }
    }
}
