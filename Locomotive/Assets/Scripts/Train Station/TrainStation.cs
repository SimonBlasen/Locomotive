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
    [SerializeField]
    private StaticTrainStation staticTrainStation = null;

    [SerializeField]
    public Vector3Int globalOffsetToSpawnPersons = new Vector3Int(-1, 0, 0);        // So that train stations, which have not set this variable don't spawn persons

    private PersonsManager personsManager = null;

    private List<Train> allTrains = new List<Train>();

    private float checkTrainsCounter = 0f;

    private List<TrainstationPerson> instPersons = new List<TrainstationPerson>();
    private List<TrainstationPerson> personsEnteringTrain = new List<TrainstationPerson>();

    private List<TrainstationPerson> personsExitingTrain = new List<TrainstationPerson>();

    private float personExitTrainCounter = 0f;

    private bool wasInGlobalOffset = false;

    private Train[] currentTrainsInStation = new Train[0];
    private Platform[] platformsOn = new Platform[0];

    // Start is called before the first frame update
    void Start()
    {
        personsManager = FindObjectOfType<PersonsManager>();

        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].platformIndex = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkTrainsCounter += Time.deltaTime;

        if (checkTrainsCounter >= 1f)
        {
            checkTrainsCounter = 0f;

            checkGlobalOffsetChange();

            
            Train[] trainsInStation = getTrainsInsidePlatform(out platformsOn);

            // Remove train station from old trains, add to current trains
            for (int i = 0; i < currentTrainsInStation.Length; i++)
            {
                currentTrainsInStation[i].CurrentTrainStation = null;
            }
            for (int i = 0; i < trainsInStation.Length; i++)
            {
                trainsInStation[i].CurrentTrainStation = this;
            }

            currentTrainsInStation = trainsInStation;

            if (platformsOn.Length > 0)
            {
                Debug.Log("Train is in station");
                personsManager.TrainInStation(this);
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
                    for (int j = 0; j < personsExitingTrain.Count; j++)
                    {
                        if (personsExitingTrain[j] == null || personsExitingTrain[j].IsExitingTrain == false)
                        {
                            personsExitingTrain.RemoveAt(j);
                            j--;
                        }
                    }
                    if (personsExitingTrain.Count == 0)
                    {
                        sendPersonIntoTrain(currentTrainsInStation[i], platformsOn[i]);
                    }
                }
            }
        }
    }

    private void checkGlobalOffsetChange()
    {
        if (IsGlobalOffsetMatching != wasInGlobalOffset)
        {
            wasInGlobalOffset = IsGlobalOffsetMatching;

            if (IsGlobalOffsetMatching)
            {
                Debug.Log("Actually spawning train station persons");
                while (toSpawnPersonsOnPlatform.Count > 0)
                {
                    actuallySpawnPerson(toSpawnPersonsOnPlatform[0]);
                }
            }
            else
            {
                Debug.Log("De-Spawning train station persons");

                despawnAllActualPersons();
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

        personsExitingTrain.Add(person);
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

            personsEnteringTrain.Add(person);
            instPersons.Remove(person);
        }
        else
        {
            Debug.Log("Did send all persons into train");

            int previousCount = personsEnteringTrain.Count;

            for (int i = 0; i < personsEnteringTrain.Count; i++)
            {
                if (personsEnteringTrain[i] == null)
                {
                    personsEnteringTrain.RemoveAt(i);
                    i--;
                }
            }

            if (personsEnteringTrain.Count == 0 && previousCount > 0)
            {
                TrainstationWhistle.Inst.BlowWhistle();
            }
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
            Gizmos.DrawSphere(platforms[i].spline.GetSampleAtDistance(platforms[i].trainStationBegin).location + GlobalOffsetManager.Inst.GlobalOffset, 2f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(platforms[i].spline.GetSampleAtDistance(platforms[i].trainStationEnd).location + GlobalOffsetManager.Inst.GlobalOffset, 2f);
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
            return instPersons.Count + toSpawnPersonsOnPlatform.Count;
        }
    }

    public bool IsGlobalOffsetMatching
    {
        get
        {
            return GlobalOffsetManager.Inst.GlobalOffset == globalOffsetToSpawnPersons;
        }
    }

    private List<int> toSpawnPersonsOnPlatform = new List<int>();

    private void despawnAllActualPersons()
    {
        while (instPersons.Count > 0)
        {
            toSpawnPersonsOnPlatform.Add(instPersons[0].WaitingPlatform.platformIndex);

            Destroy(instPersons[0].gameObject);
            instPersons.RemoveAt(0);
        }
    }

    private void actuallySpawnPerson(int platform)
    {
        GameObject instPerson = Instantiate(Resources.Load<GameObject>("Train Station/TrainstationPerson"), transform);

        TrainstationPerson person = instPerson.GetComponent<TrainstationPerson>();
        person.WaitingPlatform = platforms[platform];

        Vector3 randomPos = Vector3.Lerp(platforms[platform].waitingAreaMinPos.position, platforms[platform].waitingAreaMaxPos.position, UnityEngine.Random.Range(0f, 1f));
        person.transform.position = randomPos;
        person.CanEnterTrain = false;
        person.GetComponent<NavMeshAgent>().enabled = false;

        instPersons.Add(person);

        for (int i = 0; i < toSpawnPersonsOnPlatform.Count; i++)
        {
            if (toSpawnPersonsOnPlatform[i] == platform)
            {
                toSpawnPersonsOnPlatform.RemoveAt(i);
                break;
            }
        }
    }

    public void SpawnPerson(int platform)
    {
        // TODO directly spawn person, if the platform is inside global offset

        if (!IsGlobalOffsetMatching)
        {
            toSpawnPersonsOnPlatform.Add(platform);
        }
        else
        {
            actuallySpawnPerson(platform);
        }
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

    public Platform[] Platforms
    {
        get
        {
            return platforms;
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
    public Spline spline = null;
    public float trainStationBegin = 0f;
    public float trainStationEnd = 0f;
    public Transform waitingArea = null;
    public Transform waitingAreaMinPos = null;
    public Transform waitingAreaMaxPos = null;
    public Transform platformExit = null;
    [HideInInspector]
    public int platformIndex = -1;
}