using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPServer.UDPServer
{
    /// <summary>
    /// 
    /// FLAGS
    /// 255     255     Rel Message from server
    /// 255     254     Rel Message ack for a server message
    /// 255     253     Rel Message from client
    /// 255     252     Rel Message ack for a client message
    /// 
    /// 254     Unrel message
    /// 
    /// 253     x       [ack]   [ack]   [ack]   [ack]   [largeID]   [largeID]   [amnt]  [amnt]  [indx]  [indx]  Long message
    /// 
    /// 
    /// 
    /// </summary>
    public class Server
    {
        // Const params
        private int relSendInterval = 10;
        private int resendsAmounts = 10;
        private int maxAckNumber = int.MaxValue / 2;
        private int inactiveKick = 1000 * 60;
        private int largeMsgMaxIndex = 32000;
        private int maxPckgSize = 1000;


        public delegate void ReceiveUdpMessage(IPAddress ip, int port, byte[] datas);
        public event ReceiveUdpMessage ReceiveUdpData;

        private UDPSocket socket;
        private Thread relThread;
        private Thread sendThread;

        private List<UDPConn> udps;
        private int globalAckCounter = 0;
        private int globalLargeIndx = 0;

        public Server(int port)
        {
            Port = port;
            udps = new List<UDPConn>();

            socket = new UDPSocket(port);
            socket.ReceiveUdpData += Socket_ReceiveUdpData;

            sendThread = new Thread(new ThreadStart(SendLoop));

            //relThread.Start();
            sendThread.Start();
        }

        public int Port
        {
            get; protected set;
        }

        private void Socket_ReceiveUdpData(IPAddress ip, int port, byte[] data)
        {
            UDPConn conn = getUdpConn(ip, port);

            if (conn == null)
            {
                conn = new UDPConn(ip, port);
                udps.Add(conn);
            }

            conn.ResetInactiveTime();

            int offset = 0;
            do
            {
                if (data != null && data.Length >= 3)
                {
                    int msgLen = (data[0 + offset] << 8) | (data[1 + offset]);
                    int additionalOffset = msgLen + 2;

                    // Is unrel messagae
                    if (data[2 + offset] == 254)
                    {
                        additionalOffset += 1;
                        byte[] cropData = new byte[msgLen];
                        for (int i = 0; i < cropData.Length; i++)
                        {
                            cropData[i] = data[3 + offset + i];
                        }

                        ReceiveUdpData(ip, port, cropData);
                    }
                    // ACK
                    else if (data.Length >= 4 && data[2 + offset] == 255 && data[3 + offset] == 254)
                    {
                        additionalOffset += 6;
                        int ack = (data[4 + offset] << 24) | (data[5 + offset] << 16) | (data[6 + offset] << 8) | (data[7 + offset]);
                        conn.AckMessage(ack);
                        /*for (int i = 0; i < udps.Count; i++)
                        {
                            conn.AckMessage(ack);
                        }*/
                    }
                    // Rel message
                    else if (data.Length >= 4 && data[2 + offset] == 255 && data[3 + offset] == 253)
                    {
                        additionalOffset += 6;
                        int ack = (data[4 + offset] << 24) | (data[5 + offset] << 16) | (data[6 + offset] << 8) | (data[7 + offset]);

                        if (conn.IsAckKnown(ack) == false)
                        {
                            byte[] cropData = new byte[msgLen];
                            for (int i = 0; i < cropData.Length; i++)
                            {
                                cropData[i] = data[4 + 4 + offset + i];
                            }

                            conn.AddRecentAckMessage(ack);

                            ReceiveUdpData(ip, port, cropData);
                        }

                        socket.Send(ip, port, new byte[] { 0, 6, 255, 252, data[4 + offset], data[5 + offset], data[6 + offset], data[7 + offset] });
                    }
                    // Large message
                    else if (data.Length >= 4 && data[2 + offset] == 253 && data[3] + offset == 253)
                    {
                        additionalOffset += 12;
                        int ack = (data[4 + offset] << 24) | (data[5 + offset] << 16) | (data[6 + offset] << 8) | (data[7 + offset]);
                        int largeID = (data[8 + offset] << 8) | (data[9 + offset]);
                        int amntPckgs = (data[10 + offset] << 8) | (data[11 + offset]);
                        int pckgIndex = (data[12 + offset] << 8) | (data[13 + offset]);

                        if (conn.IsAckKnown(ack) == false)
                        {
                            byte[] cropData = new byte[msgLen];
                            for (int i = 0; i < cropData.Length; i++)
                            {
                                cropData[i] = data[4 + 4 + 4 + 2 + offset + i];
                            }

                            conn.AddRecentAckMessage(ack);

                            if (conn.ReceiveLargeMessage(largeID, amntPckgs, pckgIndex, cropData))
                            {
                                ReceiveUdpData(ip, port, conn.RetrieveLargeMessage(largeID));
                            }
                        }

                        socket.Send(ip, port, new byte[] { 0, 6, 255, 252, data[4 + offset], data[5 + offset], data[6 + offset], data[7 + offset] });
                    }

                    offset += additionalOffset;
                }
                else
                {
                    break;
                    //offset = data.Length;
                }
            }
            while (offset < data.Length);



        }

        private bool serverStopped = false;
        public void Stop()
        {
            serverStopped = true;
            //relThread.Join();
            sendThread.Join();

            socket.Stop();
        }

        public int SendUdp(IPAddress ip, int port, byte[] data)
        {
            byte[] dataWLength = new byte[data.Length + 2 + 1];
            dataWLength[0] = (byte)(data.Length >> 8);
            dataWLength[1] = (byte)(data.Length);
            dataWLength[2] = 254;
            for (int i = 0; i < data.Length; i++)
            {
                dataWLength[i + 3] = data[i];
            }

            return socket.Send(ip, port, dataWLength);
        }


        public bool SendUDPRel(IPAddress ip, int port, byte[] data, UDPConn udpConn)
        {
            if (data.Length <= maxPckgSize)
            {
                RelMessage message = new RelMessage();

                // Ack number
                message.ackNumber = globalAckCounter++;
                if (globalAckCounter > maxAckNumber)
                {
                    globalAckCounter = 0;
                }


                // Data
                byte[] dataWLength = new byte[data.Length + 4 + 2 + 2];
                dataWLength[0] = (byte)(data.Length >> 8);
                dataWLength[1] = (byte)(data.Length);
                dataWLength[2] = 255;
                dataWLength[3] = 255;
                dataWLength[4] = (byte)(message.ackNumber >> 24);
                dataWLength[5] = (byte)(message.ackNumber >> 16);
                dataWLength[6] = (byte)(message.ackNumber >> 8);
                dataWLength[7] = (byte)(message.ackNumber);
                for (int i = 0; i < data.Length; i++)
                {
                    dataWLength[i + 4 + 2 + 2] = data[i];
                }
                message.dataWLength = dataWLength;
                message.resendsLeft = resendsAmounts;
                message.timeTillResend = 0;

                if (udpConn != null)
                {
                    udpConn.AddMessage(message);
                }

                //SendUdp(ip, port, getRelBytes(data, relCount));

                //relCount++;

                return true;
            }
            else
            {
                int largeID = globalLargeIndx;
                globalLargeIndx++;
                if (globalLargeIndx >= largeMsgMaxIndex)
                {
                    globalLargeIndx = 0;
                }
                int pckgAmount = ((data.Length - 1) / maxPckgSize) + 1;
                int runningIndex = 0;
                for (int j = 0; j < pckgAmount; j++)
                {
                    List<byte> cropped = new List<byte>();

                    if (j != pckgAmount - 1)
                    {
                        for (int k = 0; k < maxPckgSize; k++)
                        {
                            cropped.Add(data[runningIndex + k]);
                        }
                    }
                    else
                    {
                        for (int k = 0; k < maxPckgSize; k++)
                        {
                            if (runningIndex + k < data.Length)
                            {
                                cropped.Add(data[runningIndex + k]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }



                    RelMessage message = new RelMessage();

                    // Ack number
                    message.ackNumber = globalAckCounter++;
                    if (globalAckCounter > maxAckNumber)
                    {
                        globalAckCounter = 0;
                    }


                    // Data
                    byte[] dataWLength = new byte[cropped.Count + 4 + 2 + 2 + 6];
                    dataWLength[0] = (byte)(cropped.Count >> 8);
                    dataWLength[1] = (byte)(cropped.Count);
                    dataWLength[2] = 253;
                    dataWLength[3] = 255;
                    dataWLength[4] = (byte)(message.ackNumber >> 24);
                    dataWLength[5] = (byte)(message.ackNumber >> 16);
                    dataWLength[6] = (byte)(message.ackNumber >> 8);
                    dataWLength[7] = (byte)(message.ackNumber);
                    dataWLength[8] = (byte)(largeID >> 8);
                    dataWLength[9] = (byte)(largeID);
                    dataWLength[10] = (byte)(pckgAmount >> 8);
                    dataWLength[11] = (byte)(pckgAmount);
                    dataWLength[12] = (byte)(j >> 8);
                    dataWLength[13] = (byte)(j);
                    for (int i = 0; i < cropped.Count; i++)
                    {
                        dataWLength[i + 4 + 2 + 2 + 6] = cropped[i];
                    }
                    message.dataWLength = dataWLength;
                    message.resendsLeft = resendsAmounts;
                    message.timeTillResend = 0;

                    if (udpConn != null)
                    {
                        udpConn.AddMessage(message);
                    }



                    runningIndex += maxPckgSize;
                }

                return true;
            }
        }

        public bool SendUDPRel(IPAddress ip, int port, byte[] data)
        {
            return SendUDPRel(ip, port, data, getUdpConn(ip, port));
        }

        public bool SendUdpAll(byte[] data)
        {
            for (int i = 0; i < udps.Count; i++)
            {
                SendUdp(udps[i].IP, udps[i].Port, data);
            }
            return true;
        }

        public bool SendUdpRelAll(byte[] data)
        {
            for (int i = 0; i < udps.Count; i++)
            {
                SendUDPRel(udps[i].IP, udps[i].Port, data, udps[i]);
            }
            return true;
        }

        private void SendLoop()
        {
            int sleepTime = relSendInterval;

            while (!serverStopped)
            {
                Thread.Sleep(sleepTime);

                for (int i = 0; i < udps.Count; i++)
                {
                    udps[i].Tick(sleepTime);
                    RelMessage toSendMsg = udps[i].PopMessage();

                    if (toSendMsg != null)
                    {
                        socket.Send(udps[i].IP, udps[i].Port, toSendMsg.dataWLength);
                    }

                    if (udps[i].InactiveTime >= inactiveKick)
                    {
                        removeUdpConn(udps[i]);
                        break;
                    }
                }
            }

        }

        private void removeUdpConn(UDPConn udpConn)
        {
            udps.Remove(udpConn);
        }

        private UDPConn getUdpConn(IPAddress ip, int port)
        {
            for (int i = 0; i < udps.Count; i++)
            {
                if (udps[i].IP.Equals(ip) && udps[i].Port == port)
                {
                    return udps[i];
                }
            }

            return null;

            /*
            for (int i = 0; i < udps.Count; i++)
            {
                if (udps[i].IPString == ip.ToString() && udps[i].Port == port)
                {
                    return udps[i];
                }
            }

            return null;*/
        }
    }
}
