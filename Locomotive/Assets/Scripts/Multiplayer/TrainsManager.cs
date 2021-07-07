using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainsManager : MonoBehaviour
{
    [SerializeField]
    private Train localOwnTrain = null;

    [Space]

    [SerializeField]
    private float sendRate = 0.1f;

    private List<MultiplayerTrain> mulTrains = new List<MultiplayerTrain>();

    private float sendCounter = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Network.Inst.TrainsManager = this;

        MultiplayerTrain multiplayerTrain = localOwnTrain.gameObject.AddComponent<MultiplayerTrain>();

        multiplayerTrain.Init(true);
        mulTrains.Add(multiplayerTrain);
    }

    // Update is called once per frame
    void Update()
    {
        if (Network.OwnID != 255)
        {
            localOwnTrain.GetComponent<MultiplayerTrain>().OwnerID = Network.OwnID;

            sendCounter += Time.deltaTime;

            if (sendCounter >= sendRate)
            {
                sendCounter -= sendRate;

                sendOwnTrainBytes();
            }
        }
    }

    public void ReceiveTrainBytes(byte[] trainBytes)
    {
        for (int i = 0; i < mulTrains.Count; i++)
        {
            if (trainBytes[0] == mulTrains[i].OwnerID
                && trainBytes[1] == mulTrains[i].LocalTrainID)
            {
                mulTrains[i].ReceivedBytes(trainBytes);
                break;
            }
        }
    }

    private void sendOwnTrainBytes()
    {
        for (int i = 0; i < mulTrains.Count; i++)
        {
            if (mulTrains[i].IsOwnTrain)
            {
                Network.Inst.SendTrainBytes(mulTrains[i].Serialized);
            }
        }
    }
}
