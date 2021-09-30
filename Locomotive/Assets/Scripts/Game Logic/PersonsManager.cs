using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsManager : MonoBehaviour
{
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
            personSpawnCounter = Random.Range(5f, 21f);

            spawnRandomPerson();
        }
    }

    private void spawnRandomPerson()
    {
        List<TrainStation> possibleTrainstations = new List<TrainStation>();
        possibleTrainstations.AddRange(TrainStation.AllTrainstations);
        for (int i = 0; i < possibleTrainstations.Count; i++)
        {
            Platform[] platforms;
            if (possibleTrainstations[i].GetTrainsInStation(out platforms).Length > 0)
            {
                possibleTrainstations.RemoveAt(i);
                i--;
            }
        }

        if (possibleTrainstations.Count > 0)
        {
            int randomTrainstation = Random.Range(0, possibleTrainstations.Count);

            if (possibleTrainstations[randomTrainstation].PeopleWaiting == 0)
            {
                possibleTrainstations[randomTrainstation].PeopleWaitingPlatform = Random.Range(0, possibleTrainstations[randomTrainstation].PlatformsAmount);
            }
            possibleTrainstations[randomTrainstation].SpawnPerson(possibleTrainstations[randomTrainstation].PeopleWaitingPlatform);
        }
    }
}
