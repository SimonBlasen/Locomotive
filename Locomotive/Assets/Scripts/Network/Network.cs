using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using UDPServer.UDPClient;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.SceneManagement;

public class Network : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_InputField inputIP = null;
    [SerializeField]
    private TMPro.TMP_InputField inputPort = null;
    [SerializeField]
    private GameObject connectPanel = null;


    private Server server = null;
    private bool connected = false;
    private int port = 0;

    private float sendConnectMessageIn = 0f;
    private float connectTimeout = -1f;
    private float noMessageFor = 0f;
    private float noMessageAboveFor = 0f;

    private float pingSendCounter = 0f;
    private bool waitingForPingAck = false;
    private float waitForPingCounter = 0f;

    private float pingCounter = -5f;
    private float waitForPingBack = -1f;
    private int receivedPingCount = 0;

    private PlayerInfo[] playerInfos = new PlayerInfo[256];

    public static Network Inst
    {
        get
        {
            return inst;
        }
    }

    public static int ConnectedPort
    {
        get
        {
            return inst.port;
        }
    }

    private void Awake()
    {
        init();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputIP.text = "192.168.1.11";
        inputPort.text = "38000";
    }

    private static Network inst = null;
    private void init()
    {
        inst = this;

        for (int i = 0; i < playerInfos.Length; i++)
        {
            playerInfos[i] = new PlayerInfo();
            playerInfos[i].ID = (byte)i;
        }

        OwnID = 255;


    }

    // Update is called once per frame
    void Update()
    {
        if (connectTimeout >= 0f)
        {
            connectTimeout += Time.deltaTime;

            if (connectTimeout >= 7f)
            {
                connectTimeout = -1f;
            }
        }

        if (sendConnectMessageIn > 0f)
        {
            sendConnectMessageIn -= Time.deltaTime;

            if (sendConnectMessageIn <= 0f)
            {
                sendConnectMessage();
                sendConnectMessageIn = 0f;
            }
        }
    }


    public static void Stop()
    {

    }

    private void sendConnectMessage()
    {
        byte[] bytes = new byte[4];
        bytes[0] = 0;
        bytes[1] = 0;
        bytes[2] = 0;
        bytes[3] = 0;

        server.SendUdp(bytes);
    }

    public void ConnectButtonClick()
    {
        Connect(inputIP.text, Convert.ToInt32(inputPort.text));
    }


    public void Connect(string ip, int port)
    {
        UnityEngine.Debug.Log("Connecting to " + ip + ":" + port);

        connectTimeout = 0f;

        server = new Server(ip, port);
        server.ReceiveUdpData += Server_ReceiveUdpData;

        sendConnectMessageIn = 0.4f;
    }


    public static byte OwnID
    {
        get; set;
    } = 255;

    public PlayerInfo[] PlayerInfos
    {
        get
        {
            return playerInfos;
        }
        set
        {
            playerInfos = value;
        }
    }

    private List<byte[]> messages = new List<byte[]>();


    private void FixedUpdate()
    {
        if (messages.Count > 30)
        {
            Debug.Log("Cleared messages. Count was: " + messages.Count.ToString());
            messages.Clear();
        }

        while (messages.Count > 0)
        {
            byte[] data = messages[0];
            messages.RemoveAt(0);

            if (!connected)
            {
                connectTimeout = -1f;
                connected = true;

                connectPanel.SetActive(false);
            }

            if (connected)
            {
                Debug.Log("Got message: " + data.Length.ToString());

                if (data != null && data.Length >= 2)
                {
                    noMessageFor = 0f;

                    // Connect Successfull
                    if (data[0] == 128 && data[1] == 0)
                    {
                        OwnID = data[2];
                        Debug.Log("Connected! OwnID: " + OwnID.ToString());
                    }


                    // Train Bytes
                    else if (data[0] == 128 && data[1] == 1)
                    {
                        if (data[2] != OwnID)
                        {
                            byte[] cropped = new byte[data.Length - 3];
                            for (int i = 0; i < cropped.Length; i++)
                            {
                                cropped[i] = data[i + 3];
                            }
                            TrainsManager.ReceiveTrainBytes(cropped);
                        }
                    }

                    // Ping Measurement
                    else if (data[0] == 128 && data[1] == 2)
                    {
                        server.SendUdp(new byte[] { 0, 2, OwnID });
                    }

                    // Player Pings
                    else if (data[0] == 128 && data[1] == 3)
                    {
                        List<byte> playersConnected = new List<byte>();

                        for (int i = 2; i < data.Length; i += 5)
                        {
                            byte playerID = data[i];
                            float ping = BitConverter.ToSingle(data, i + 1);

                            playerInfos[playerID].Ping = ping;
                            playerInfos[playerID].IsConnected = true;

                            playersConnected.Add(playerID);
                        }

                        for (int i = 0; i < playerInfos.Length; i++)
                        {
                            if (playersConnected.Contains((byte)i) == false)
                            {
                                playerInfos[i].IsConnected = false;
                            }
                        }
                    }
                }
            }
        }
    }


    

    private void Server_ReceiveUdpData(byte[] data)
    {
        messages.Add(data);
    }



    public void SendTrainBytes(byte[] trainBytes)
    {
        byte[] bytes = new byte[trainBytes.Length + 3];
        bytes[0] = 0;
        bytes[1] = 1;
        bytes[2] = OwnID;
        for (int i = 0; i < trainBytes.Length; i++)
        {
            bytes[3 + i] = trainBytes[i];
        }

        server.SendUdp(bytes);
    }



    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }

    public TrainsManager TrainsManager
    {
        get; set;
    } = null;
}
