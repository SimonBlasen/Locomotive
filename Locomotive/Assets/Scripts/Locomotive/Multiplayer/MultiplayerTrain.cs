using System;
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

    private int bytesPerWaggon = 9;
    private int bytesAdditional = 6;

    private byte[] serBytes = new byte[0];
    public byte[] Serialized
    {
        get
        {
            TrainPartPose[] partPoses = train.TrainRailHandler.GetTrainPoses();
            if (serBytes.Length != partPoses.Length * bytesPerWaggon + bytesAdditional)
            {
                serBytes = new byte[bytesAdditional + bytesPerWaggon * partPoses.Length];
                serBytes[0] = Network.OwnID;
                serBytes[1] = localTrainID;
            }

            // Velocity and stuff
            byte[] velocityBytes = BitConverter.GetBytes(train.CurrentSpeed);
            serBytes[2] = velocityBytes[0];
            serBytes[3] = velocityBytes[1];
            serBytes[4] = velocityBytes[2];
            serBytes[5] = velocityBytes[3];

            for (int i = 0; i < partPoses.Length; i++)
            {
                byte[] splineIDBytes = BitConverter.GetBytes(partPoses[i].splineID);
                byte[] splineSBytes = BitConverter.GetBytes(partPoses[i].splineS);
                serBytes[bytesAdditional + i * bytesPerWaggon + 0] = splineIDBytes[0];
                serBytes[bytesAdditional + i * bytesPerWaggon + 1] = splineIDBytes[1];
                serBytes[bytesAdditional + i * bytesPerWaggon + 2] = splineIDBytes[2];
                serBytes[bytesAdditional + i * bytesPerWaggon + 3] = splineIDBytes[3];
                serBytes[bytesAdditional + i * bytesPerWaggon + 4] = splineSBytes[0];
                serBytes[bytesAdditional + i * bytesPerWaggon + 5] = splineSBytes[1];
                serBytes[bytesAdditional + i * bytesPerWaggon + 6] = splineSBytes[2];
                serBytes[bytesAdditional + i * bytesPerWaggon + 7] = splineSBytes[3];
                serBytes[bytesAdditional + i * bytesPerWaggon + 8] = partPoses[i].flipped ? ((byte)1) : ((byte)0);
            }

            return serBytes;
        }
    }

    public void ReceivedBytes(byte[] bytes)
    {

    }
}


public class TrainPartPose
{
    public int splineID;
    public float splineS;
    public float splineSNotFlipped;
    public bool flipped;
}