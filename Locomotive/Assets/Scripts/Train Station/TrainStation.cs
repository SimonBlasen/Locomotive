using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrainStation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Platform[] platforms = null;
    [SerializeField]
    private float personsExitSpeedMin = 0.1f;
    [SerializeField]
    private float personsExitSpeedMax = 0.3f;

    private List<Train> allTrains = new List<Train>();

    private float checkTrainsCounter = 0f;

    private List<TrainstationPerson> instPersons = new List<TrainstationPerson>();

    private float personExitTrainCounter = 0f;

    private Train[] currentTrainsInStation = new Train[0];
    private Platform[] platformsOn = new Platform[0];

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

            
            Train[] trainsInStation = getTrainsInsidePlatform(out platformsOn);

            currentTrainsInStation = trainsInStation;

            if (platformsOn.Length > 0)
            {
                Debug.Log("Train is in station");
            }
        }

        personExitTrainCounter -= Time.deltaTime;
        if (personExitTrainCounter <= 0f)
        {
            personExitTrainCounter = UnityEngine.Random.Range(personsExitSpeedMin, personsExitSpeedMax);

            for (int i = 0; i < currentTrainsInStation.Length; i++)
            {
                if (currentTrainsInStation[i].GetPersonsWithTarget(this) > 0)
                {
                    ejectPersonFromTrain(currentTrainsInStation[i], platformsOn[i]);
                }
                else
                {
                    sendPersonIntoTrain(currentTrainsInStation[i], platformsOn[i]);
                    // Send person after person into train
                }
            }
        }
    }

    private void ejectPersonFromTrain(Train train, Platform platform)
    {
        train.ReducePersonsWithTarget(this);
        // Spawn person


        GameObject instPerson = Instantiate(Resources.Load<GameObject>("Train Station/TrainstationPerson"), transform);

        TrainstationPerson person = instPerson.GetComponent<TrainstationPerson>();
        person.WaitingPlatform = platform;

        //Vector3 randomPos = Vector3.Lerp(platform.waitingAreaMinPos.position, platform.waitingAreaMaxPos.position, UnityEngine.Random.Range(0f, 1f));
        //person.transform.position = randomPos;
        person.CanEnterTrain = true;

        Vector3 spawnPos = Vector3.zero;
        Wagon spawnWagon = train.Wagons[UnityEngine.Random.Range(0, train.Wagons.Length)];
        Transform selectedDoor = spawnWagon.RandomDoor();
        spawnPos = selectedDoor.position;
        person.IsExitingTrain = true;
        person.HasPreviouslyExitedTrain = true;

        person.transform.position = spawnPos;
        person.GetComponent<NavMeshAgent>().enabled = false;

        if (Vector3.Distance(platform.waitingAreaMinPos.position, selectedDoor.position + selectedDoor.right * 3f) < Vector3.Distance(platform.waitingAreaMinPos.position, selectedDoor.position + selectedDoor.right * -3f))
        {
            person.NavDestination = selectedDoor.position + selectedDoor.right * 3f;
        }
        else
        {
            person.NavDestination = selectedDoor.position + selectedDoor.right * -3f;
        }

        //instPersons.Add(person);
    }

    private void sendPersonIntoTrain(Train train, Platform platform)
    {
        List<TrainstationPerson> personsThisPlatform = new List<TrainstationPerson>();
        for (int i = 0; i < instPersons.Count; i++)
        {
            if (instPersons[i].WaitingPlatform == platform && instPersons[i].HasPreviouslyExitedTrain == false)
            {
                personsThisPlatform.Add(instPersons[i]);
            }
        }

        if (personsThisPlatform.Count > 0)
        {
            Vector3 waggonPos = Vector3.zero;
            Wagon spawnWagon = train.Wagons[UnityEngine.Random.Range(0, train.Wagons.Length)];
            Transform selectedDoor = spawnWagon.RandomDoor();
            waggonPos = selectedDoor.position;

            int randomPerson = UnityEngine.Random.Range(0, personsThisPlatform.Count);

            TrainstationPerson person = personsThisPlatform[randomPerson];
            person.IsEnteringTrain = true;
            person.CanEnterTrain = true;
            person.NavDestination = waggonPos;
            person.DestinationTrain = train;
            person.OriginTrainstation = this;

            instPersons.Remove(person);
        }
        else
        {
            Debug.Log("Did send all persons into train");
        }
    }

    public Train[] GetTrainsInStation(out Platform[] platformsOn)
    {
        return getTrainsInsidePlatform(out platformsOn);
    }

    private Train[] getTrainsInsidePlatform(out Platform[] platformsOn)
    {
        List<Train> trainsIn = new List<Train>();
        List<Platform> plats = new List<Platform>();

        for (int i = 0; i < allTrains.Count; i++)
        {
            if (allTrains[i].CurrentSpeed <= 0.1f)
            {
                RailSegment curRailSeg = allTrains[i].CurrentRailSegment;

                for (int j = 0; j < platforms.Length; j++)
                {
                    if (platforms[j].railSegment == curRailSeg
                        && allTrains[i].CurPosOnSPline >= platforms[j].trainStationBegin && allTrains[i].CurPosOnSPline <= platforms[j].trainStationEnd
                        && allTrains[i].PosOfLastWagon >= platforms[j].trainStationBegin && allTrains[i].PosOfLastWagon <= platforms[j].trainStationEnd)
                    {
                        trainsIn.Add(allTrains[i]);
                        plats.Add(platforms[j]);
                    }
                }
            }
        }

        platformsOn = plats.ToArray();
        return trainsIn.ToArray();
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(platforms[i].spline.GetSampleAtDistance(platforms[i].trainStationBegin).location, 2f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(platforms[i].spline.GetSampleAtDistance(platforms[i].trainStationEnd).location, 2f);
        }
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

    public int PeopleWaiting
    {
        get
        {
            return instPersons.Count;
        }
    }

    public void SpawnPerson(int platform)
    {
        GameObject instPerson = Instantiate(Resources.Load<GameObject>("Train Station/TrainstationPerson"), transform);

        TrainstationPerson person = instPerson.GetComponent<TrainstationPerson>();
        person.WaitingPlatform = platforms[platform];

        Vector3 randomPos = Vector3.Lerp(platforms[platform].waitingAreaMinPos.position, platforms[platform].waitingAreaMaxPos.position, UnityEngine.Random.Range(0f, 1f));
        person.transform.position = randomPos;
        person.CanEnterTrain = false;
        person.GetComponent<NavMeshAgent>().enabled = false;

        instPersons.Add(person);
    }

    public int PeopleWaitingPlatform
    {
        get; set;
    } = 0;

    public int PlatformsAmount
    {
        get
        {
            return platforms.Length;
        }
    }

    public static TrainStation[] AllTrainstations
    {
        get; set;
    } = new TrainStation[0];
}

[Serializable]
public class Platform
{
    public RailSegment railSegment = null;
    public Spline spline= null;
    public float trainStationBegin = 0f;
    public float trainStationEnd = 0f;
    public Transform waitingArea = null;
    public Transform waitingAreaMinPos = null;
    public Transform waitingAreaMaxPos = null;
}