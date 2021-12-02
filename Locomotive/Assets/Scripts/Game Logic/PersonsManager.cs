using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsManager : MonoBehaviour
{
    [SerializeField]
    private float averageTimeSpawnPerson = 10f;
    [SerializeField]
    private float averageTimeNewDestStation = 60f * 5f;
    [SerializeField]
    private float averageTimeNewMainStation = 60f * 5f;
    [SerializeField]
    private float[] trainStationsProbDistr = null;
    [SerializeField]
    private float[] trainStationsDestProbDistr = null;

    private float personSpawnCounter = 10f;

    private float selectMainStationIn = 2f;
    private float selectMainDestStationIn = 2f;

    private int mainStationIndex = -1;
    private int mainDestStationIndex = -1;
    private int oldMainStationIndex = -1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectMainStationIn > 0f)
        {
            selectMainStationIn -= Time.deltaTime;

            if (selectMainStationIn <= 0f)
            {
                selectMainStationIn = Random.Range(-120f, 120f) + averageTimeNewMainStation;
                mainStationIndex = oldMainStationIndex;
                while (oldMainStationIndex == mainStationIndex)
                {
                    mainStationIndex = Random.Range(0, TrainStation.AllTrainstations.Length);
                }

                trainStationsProbDistr = new float[TrainStation.AllTrainstations.Length];
                for (int i = 0; i < trainStationsProbDistr.Length; i++)
                {
                    trainStationsProbDistr[i] = (i == mainStationIndex) ? 1f : 0.07f;
                }

                Debug.Log("Selected new main station: " + TrainStation.AllTrainstations[mainStationIndex].TrainstationName);
            }
        }


        personSpawnCounter -= Time.deltaTime;

        if (personSpawnCounter <= 0f)
        {
            personSpawnCounter = averageTimeSpawnPerson + Random.Range(-averageTimeSpawnPerson * 0.5f, averageTimeSpawnPerson * 0.5f);

            spawnRandomPerson();
        }


        if (selectMainDestStationIn > 0f)
        {
            selectMainDestStationIn -= Time.deltaTime;

            if (selectMainDestStationIn <= 0f)
            {
                selectMainDestStationIn = Random.Range(-60f, 60f) + averageTimeNewDestStation;

                mainDestStationIndex = Random.Range(0, TrainStation.AllTrainstations.Length);
                trainStationsDestProbDistr = new float[TrainStation.AllTrainstations.Length];
                for (int i = 0; i < trainStationsDestProbDistr.Length; i++)
                {
                    trainStationsDestProbDistr[i] = (i == mainDestStationIndex) ? 1f : 0.07f;
                }
                Debug.Log("Selected new destination station: " + TrainStation.AllTrainstations[mainDestStationIndex].TrainstationName);
            }
        }
    }

    private void spawnRandomPerson()
    {
        List<TrainStation> possibleTrainstations = new List<TrainStation>();
        List<float> possProbabilities = new List<float>();
        possibleTrainstations.AddRange(TrainStation.AllTrainstations);
        possProbabilities.AddRange(trainStationsProbDistr);
        for (int i = 0; i < possibleTrainstations.Count; i++)
        {
            Platform[] platforms;
            if (possibleTrainstations[i].GetTrainsInStation(out platforms).Length > 0)
            {
                possibleTrainstations.RemoveAt(i);
                possProbabilities.RemoveAt(i);
                i--;
            }
        }

        int randIndex = sampleIndex(possProbabilities);

        if (randIndex != -1)
        {
            int randomTrainstation = randIndex;

            if (possibleTrainstations[randomTrainstation].PeopleWaiting == 0)
            {
                possibleTrainstations[randomTrainstation].PeopleWaitingPlatform = Random.Range(0, possibleTrainstations[randomTrainstation].PlatformsAmount);
            }
            possibleTrainstations[randomTrainstation].SpawnPerson(possibleTrainstations[randomTrainstation].PeopleWaitingPlatform);
        }

        /*
        if (possibleTrainstations.Count > 0)
        {
            int randomTrainstation = Random.Range(0, possibleTrainstations.Count);

            if (possibleTrainstations[randomTrainstation].PeopleWaiting == 0)
            {
                possibleTrainstations[randomTrainstation].PeopleWaitingPlatform = Random.Range(0, possibleTrainstations[randomTrainstation].PlatformsAmount);
            }
            possibleTrainstations[randomTrainstation].SpawnPerson(possibleTrainstations[randomTrainstation].PeopleWaitingPlatform);
        }*/
    }

    private int sampleIndex(List<float> probDistr)
    {
        List<float> summedProbDistr = new List<float>();

        float sum = 0f;
        for (int i = 0; i < probDistr.Count; i++)
        {
            sum += probDistr[i];
            summedProbDistr.Add(sum);
        }


        float randVal = Random.Range(0f, sum);

        int randIndex = -1;
        for (int i = 0; i < probDistr.Count; i++)
        {
            if (i == 0 && randVal <= summedProbDistr[i])
            {
                randIndex = i;
                break;
            }
            else if (i > 0 && randVal > summedProbDistr[i - 1] && randVal <= summedProbDistr[i])
            {
                randIndex = i;
                break;
            }
        }

        return randIndex;
    }

    public void TrainInStation(TrainStation trainStation)
    {
        if (mainStationIndex != -1)
        {
            if (TrainStation.AllTrainstations[mainStationIndex] == trainStation)
            {
                oldMainStationIndex = mainStationIndex;
                mainStationIndex = -1;
                Debug.Log("Train is in main station");
                selectMainStationIn = 10f;
            }
        }
    }

    public TrainStation SampleDestinationTrainstation(List<TrainStation> possibleTrainStations)
    {
        List<float> possProbs = new List<float>();
        possProbs.AddRange(trainStationsDestProbDistr);

        int randIndex = -1;
        TrainStation selTrainStation = null;

        while (possibleTrainStations.Contains(selTrainStation) == false || randIndex == -1)
        {
            randIndex = sampleIndex(possProbs);
            if (randIndex != -1)
            {
                selTrainStation = TrainStation.AllTrainstations[randIndex];
            }
        }

        return selTrainStation;
    }

    private static PersonsManager inst = null;
    public static PersonsManager Inst
    {
        get
        {
            if (inst == null)
            {
                inst = FindObjectOfType<PersonsManager>();
            }
            return inst;
        }
    }
}
