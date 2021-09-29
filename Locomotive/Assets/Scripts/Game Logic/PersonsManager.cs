using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TrainStation[] trainStations = null;


    private float personSpawnCounter = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        personSpawnCounter -= Time.deltaTime;

        if (personSpawnCounter <= 0f)
        {
            personSpawnCounter = Random.Range(20f, 21f);

            spawnRandomPerson();
        }
    }

    private void spawnRandomPerson()
    {
        int randomTrainstation = Random.Range(0, trainStations.Length);

        if (trainStations[randomTrainstation].PeopleWaiting == 0)
        {
            trainStations[randomTrainstation].PeopleWaitingPlatform = Random.Range(0, trainStations[randomTrainstation].PlatformsAmount);
        }
        trainStations[randomTrainstation].SpawnPerson(trainStations[randomTrainstation].PeopleWaitingPlatform);
    }
}
