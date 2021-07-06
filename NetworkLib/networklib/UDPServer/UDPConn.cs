using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace UDPServer.UDPServer
{
    public class UDPConn
    {
        private int resendWaitTime = 100;
        private int ackHoldTime = 3000;

        private int inactiveTime;

        private IPAddress ip;
        private int port;

        private List<LargeMessage> largeMessages;
        private List<RecentAckMessage> recentAckMessages;
        private List<RelMessage> messages;

        private static readonly Object lockObj = new Object();

        public UDPConn(IPAddress ip, int port)
        {
            this.ip = ip;
            this.port = port;
            messages = new List<RelMessage>();
            recentAckMessages = new List<RecentAckMessage>();
            largeMessages = new List<LargeMessage>();
            inactiveTime = 0;

            IPString = ip.ToString();
        }

        public IPAddress IP { get { return ip; } }
        public string IPString { get; protected set; }
        public int Port { get { return port; } }
        public int InactiveTime { get { return inactiveTime; } }

        public void ResetInactiveTime()
        {
            inactiveTime = 0;
        }

        public void AddMessage(RelMessage message)
        {
            lock (lockObj)
            {
                messages.Add(message);
            }
        }

        public void AddRecentAckMessage(int ack)
        {
            RecentAckMessage ram = new RecentAckMessage();
            ram.ack = ack;
            ram.timeTillDelete = ackHoldTime;

            lock (lockObj)
            {
                recentAckMessages.Add(ram);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="largeID"></param>
        /// <param name="amntPckgs"></param>
        /// <param name="pckgIndex"></param>
        /// <param name="data"></param>
        /// <returns>If the message is now complete</returns>
        public bool ReceiveLargeMessage(int largeID, int amntPckgs, int pckgIndex, byte[] data)
        {
            LargeMessage largeMsg = null;
            bool found = false;
            lock (lockObj)
            {
                for (int i = 0; i < largeMessages.Count; i++)
                {
                    if (largeMessages[i].LargeID == largeID)
                    {
                        found = true;
                        largeMsg = largeMessages[i];
                        break;
                    }
                }

                if (!found)
                {
                    largeMsg = new LargeMessage(largeID, amntPckgs);
                    largeMessages.Add(largeMsg);
                }

                largeMsg.AddSnippet(pckgIndex, data);

            }

            return largeMsg.IsComplete;
        }

        public byte[] RetrieveLargeMessage(int largeID)
        {
            byte[] complMessage = null;
            lock (lockObj)
            {
                for (int i = 0; i < largeMessages.Count; i++)
                {
                    if (largeMessages[i].LargeID == largeID)
                    {
                        complMessage = largeMessages[i].CompleteMessage;
                        break;
                    }
                }
            }

            return complMessage;
        }

        public bool IsAckKnown(int ack)
        {
            bool isKnown = false;

            lock (lockObj)
            {
                for (int i = 0; i < recentAckMessages.Count; i++)
                {
                    if (recentAckMessages[i].ack == ack)
                    {
                        isKnown = true;
                        break;
                    }
                }
            }

            return isKnown;
        }

        public void Tick(int passedTime)
        {
            lock (lockObj)
            {
                for (int i = 0; i < messages.Count; i++)
                {// null exception
                    messages[i].timeTillResend -= passedTime;
                    if (messages[i].timeTillResend < 0)
                    {
                        messages[i].timeTillResend = 0;
                    }
                }

                for (int i = 0; i < recentAckMessages.Count; i++)
                {//hier kam null pointer 
                    recentAckMessages[i].timeTillDelete -= passedTime;
                    if (recentAckMessages[i].timeTillDelete <= 0)
                    {
                        recentAckMessages.RemoveAt(i);
                        i--;
                    }
                }

                if (messages.Count > 0)
                {
                    inactiveTime += passedTime;
                }
            }
        }

        public RelMessage PopMessage()
        {
            RelMessage relMsg = null;

            lock (lockObj)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].timeTillResend <= 0 && messages[i].resendsLeft > 0)
                    {
                        messages[i].resendsLeft--;
                        messages[i].timeTillResend = resendWaitTime;
                        relMsg = messages[i];
                        break;
                    }
                    else if (messages[i].resendsLeft <= 0)
                    {
                        messages.RemoveAt(i);
                        i--;
                    }
                }

            }

            return relMsg;
        }

        public void AckMessage(int ackNumber)
        {
            lock (lockObj)
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].ackNumber == ackNumber)
                    {
                        messages.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
