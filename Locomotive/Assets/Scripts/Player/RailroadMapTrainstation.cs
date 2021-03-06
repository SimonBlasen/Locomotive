using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class RailroadMapTrainstation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Material materialIdle = null;
    [SerializeField]
    private Material materialOnRails = null;
    [SerializeField]
    private Material materialStoppedStation = null;


    [Header("References")]
    [SerializeField]
    private RailSegment[] segmentsOfTrainstation = null;
    [SerializeField]
    private TrainStation trainStation = null;


    [Header("Internal References")]
    [SerializeField]
    private TextMeshPro textMeshTrainstationInfo = null;
    [SerializeField]
    private MeshRenderer blinkingMeshRenderer = null;
    [SerializeField]
    private TextMeshPro textMeshStationName = null;

    private Color colorOnTrack = Color.yellow;
    private Color colorStoppedInStation = Color.blue;

    private TrainRailHandler railHandler = null;
    private Train train = null;

    private RailSegment currentRailSegment = null;
    private float checkCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        train = GetComponentInParent<Train>();
        train.RailHandlerInit += Train_RailHandlerInit;

        fillStaticTrainstations();

        // Only for debug purpose
        if (trainStation != null)
        {
            train.PersonEntersTrain(null, trainStation);
            train.PersonEntersTrain(null, trainStation);
            train.PersonEntersTrain(null, trainStation);
        }
    }

    private void fillStaticTrainstations()
    {
        if (trainStation != null)
        {
            List<TrainStation> trainStationsYet = new List<TrainStation>();
            trainStationsYet.AddRange(TrainStation.AllTrainstations);
            trainStationsYet.Add(trainStation);
            TrainStation.AllTrainstations = trainStationsYet.ToArray();

            textMeshStationName.text = trainStation.TrainstationName;
        }
    }

    private void Train_RailHandlerInit(TrainRailHandler railHandler)
    {
        this.railHandler = railHandler;
        currentRailSegment = railHandler.CurrentRailSegment;
    }

    // Update is called once per frame
    void Update()
    {
        checkCounter += Time.deltaTime;

        if (checkCounter >= 1f)
        {
            checkCounter = 0f;
            if (railHandler != null && railHandler.CurrentRailSegment != currentRailSegment)
            {
                currentRailSegment = railHandler.CurrentRailSegment;

                IsTrainOnSegment = isRailsegmentPartOfSelf(currentRailSegment);
            }


            if (trainStation != null)
            {
                // Check train station
                Platform[] platforms;
                Train[] trains = trainStation.GetTrainsInStation(out platforms);
                IsTrainInStation = false;
                for (int i = 0; i < trains.Length; i++)
                {
                    if (trains[i] == train)
                    {
                        IsTrainInStation = true;
                    }
                }

                refreshTextMeshInfo();
            }

        }
    }

    private bool isRailsegmentPartOfSelf(RailSegment railSegment)
    {
        for (int i = 0; i < segmentsOfTrainstation.Length; i++)
        {
            if (railSegment == segmentsOfTrainstation[i])
            {
                return true;
            }
        }
        return false;
    }


    private bool isTrainOnSegment = false;
    public bool IsTrainOnSegment
    {
        get
        {
            return isTrainOnSegment;
        }
        set
        {
            isTrainOnSegment = value;

            blinkingMeshRenderer.sharedMaterial = isTrainInStation ? materialStoppedStation : (isTrainOnSegment ? materialOnRails : materialIdle);
        }
    }


    private bool isTrainInStation = false;
    public bool IsTrainInStation
    {
        get
        {
            return isTrainInStation;
        }
        set
        {
            isTrainInStation = value;

            blinkingMeshRenderer.sharedMaterial = isTrainInStation ? materialStoppedStation : (isTrainOnSegment ? materialOnRails : materialIdle);
        }
    }

    private void refreshTextMeshInfo()
    {
        textMeshTrainstationInfo.text = "Pltfrm: " + (trainStation.PeopleWaitingPlatform + 1).ToString()
                                        + "\nWaiting: " + trainStation.PeopleWaiting.ToString()
                                        + "\nDestination: " + train.GetPersonsWithTarget(trainStation).ToString();
    }
}
