using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private Platform[] platforms = null;

    private List<Train> allTrains = new List<Train>();

    private float checkTrainsCounter = 0f;

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

            Platform[] platformsOn;
            Train[] trainsInStation = getTrainsInsidePlatform(out platformsOn);

            if (platformsOn.Length > 0)
            {
                Debug.Log("Train is in station");
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
        get; set;
    } = 0;

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
}

[Serializable]
public class Platform
{
    public RailSegment railSegment = null;
    public Spline spline= null;
    public float trainStationBegin = 0f;
    public float trainStationEnd = 0f;
}