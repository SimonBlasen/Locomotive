using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerTrain : MonoBehaviour
{
    private Train train;

    private bool isOwnTrain = true;

    private static byte localTrainCounter = 0;
    private byte localTrainID = 0;
    private byte trainOwnerID = 255;

    private float curPing = 0f;

    // Start is called before the first frame update
    void Start()
    {
        train = GetComponent<Train>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trainOwnerID != 255)
        {
            curPing = Network.Inst.PlayerInfos[trainOwnerID].Ping;
        }
    }

    public void Init(bool isOwnTrain)
    {
        this.isOwnTrain = isOwnTrain;
        localTrainID = localTrainCounter;
        localTrainCounter++;

        serBytes = new byte[2];
        serBytes[0] = Network.OwnID;
        serBytes[1] = localTrainID;
    }

    public byte OwnerID
    {
        get
        {
            return trainOwnerID;
        }
        set
        {
            trainOwnerID = value;
        }
    }

    public byte LocalTrainID
    {
        get
        {
            return localTrainID;
        }
    }

    public bool IsOwnTrain
    {
        get
        {
            return isOwnTrain;
        }
    }

    private byte[] serBytes = new byte[0];
    public byte[] Serialized
    {
        get
        {
            return serBytes;
        }
    }

    public void ReceivedBytes(byte[] bytes)
    {

    }
}
