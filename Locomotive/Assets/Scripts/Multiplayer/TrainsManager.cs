using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainsManager : MonoBehaviour
{
    [SerializeField]
    private Train localOwnTrain = null;

    private List<MultiplayerTrain> mulTrains = new List<MultiplayerTrain>();

    // Start is called before the first frame update
    void Start()
    {
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
        }
    }
}
