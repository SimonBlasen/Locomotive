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

    // Start is called before the first frame update
    void Start()
    {
        train = GetComponent<Train>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(bool isOwnTrain)
    {
        this.isOwnTrain = isOwnTrain;
        localTrainID = localTrainCounter;
        localTrainCounter++;
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
}
