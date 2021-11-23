using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillStation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private RailSegment railSegment;
    [SerializeField]
    private float trainStationBegin = 0f;
    [SerializeField]
    private float trainStationEnd = 0f;

    private List<Train> allTrains = new List<Train>();

    private float checkTrainsCounter = 0f;

    private List<TrainstationPerson> instPersons = new List<TrainstationPerson>();

    private List<TrainstationPerson> personsExitingTrain = new List<TrainstationPerson>();

    private float personExitTrainCounter = 0f;

    private bool wasInGlobalOffset = false;

    private Train[] currentTrainsInStation = new Train[0];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkTrainsCounter += Time.deltaTime;

        if (checkTrainsCounter >= 1f)
        {
            checkTrainsCounter = 0f;


            Train[] trainsInStation = getTrainsInsidePlatform();

            // Remove train station from old trains, add to current trains
            for (int i = 0; i < currentTrainsInStation.Length; i++)
            {
                currentTrainsInStation[i].CurrentRefillStation = null;
            }
            for (int i = 0; i < trainsInStation.Length; i++)
            {
                trainsInStation[i].CurrentRefillStation = this;
            }

            currentTrainsInStation = trainsInStation;

            if (trainsInStation.Length > 0)
            {
                Debug.Log("Train is in refill station");
            }
        }

        for (int i = 0; i < currentTrainsInStation.Length; i++)
        {
            currentTrainsInStation[i].Refill(true, true, Time.deltaTime);
        }
    }


    public Train[] GetTrainsInStation()
    {
        return getTrainsInsidePlatform();
    }

    private Train[] getTrainsInsidePlatform()
    {
        List<Train> trainsIn = new List<Train>();

        for (int i = 0; i < allTrains.Count; i++)
        {
            if (allTrains[i].CurrentSpeed <= 0.1f)
            {
                RailSegment curRailSeg = allTrains[i].CurrentRailSegment;

                if (railSegment == curRailSeg
                    && allTrains[i].CurPosOnSPline >= trainStationBegin && allTrains[i].CurPosOnSPline <= trainStationEnd)
                {
                    trainsIn.Add(allTrains[i]);
                }
            }
        }

        return trainsIn.ToArray();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(railSegment.Spline.GetSampleAtDistance(trainStationBegin).location + GlobalOffsetManager.Inst.GlobalOffset, 2f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(railSegment.Spline.GetSampleAtDistance(trainStationEnd).location + GlobalOffsetManager.Inst.GlobalOffset, 2f);
    }

    public void RegisterTrain(Train train)
    {
        if (allTrains.Contains(train) == false)
        {
            allTrains.Add(train);
        }
    }

    public void DeregisterTrain(Train train)
    {
        allTrains.Remove(train);
    }
}