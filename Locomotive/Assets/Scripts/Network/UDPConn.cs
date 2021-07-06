using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace UDPServer.UDPClient
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

        public UDPConn(IPAddress ip, int port)
        {
            this.ip = ip;
            this.port = port;
            messages = new List<RelMessage>();
            recentAckMessages = new List<RecentAckMessage>();
            largeMessages = new List<LargeMessage>();
            inactiveTime = 0;
        }

        public IPAddress IP { get { return ip; } }
        public int Port { get { return port; } }
        public int InactiveTime { get { return inactiveTime; } }

        public void ResetInactiveTime()
        {
            inactiveTime = 0;
        }

        public void AddMessage(RelMessage message)
        {
            messages.Add(message);
        }

        public void AddRecentAckMessage(int ack)
        {
            RecentAckMessage ram = new RecentAckMessage();
            ram.ack = ack;
            ram.timeTillDelete = ackHoldTime;

            recentAckMessages.Add(ram);
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

            return largeMsg.IsComplete;
        }

        public byte[] RetrieveLargeMessage(int largeID)
        {
            for (int i = 0; i < largeMessages.Count; i++)
            {
                if (largeMessages[i].LargeID == largeID)
                {
                    return largeMessages[i].CompleteMessage;
                }
            }

            return null;
        }

        public bool IsAckKnown(int ack)
        {
            for (int i = 0; i < recentAckMessages.Count; i++)
            {
                if (recentAckMessages[i] != null
                    && recentAckMessages[i].ack == ack)
                {
                    return true;
                }
            }

            return false;
        }

        public void Tick(int passedTime)
        {
            try
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    messages[i].timeTillResend -= passedTime;
                    if (messages[i].timeTillResend < 0)
                    {
                        messages[i].timeTillResend = 0;
                    }
                }

                for (int i = 0; i < recentAckMessages.Count; i++)
                {
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
            catch (Exception ex)
            {

            }
        }

        public RelMessage PopMessage()
        {
            try
            {
                for (int i = 0; i < messages.Count; i++)
                {
                    if (messages[i].timeTillResend <= 0 && messages[i].resendsLeft > 0)
                    {
                        messages[i].resendsLeft--;
                        messages[i].timeTillResend = resendWaitTime;
                        return messages[i];
                    }
                    else if (messages[i].resendsLeft <= 0)
                    {
                        messages.RemoveAt(i);
                        i--;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public void AckMessage(int ackNumber)
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
