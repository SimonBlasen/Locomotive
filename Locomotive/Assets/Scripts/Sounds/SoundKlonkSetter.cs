using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundKlonkSetter : MonoBehaviour
{
    [SerializeField]
    private float metersKlonk = 20f;
    [SerializeField]
    private float metersSpawnInfrontLoc = 1f;
    [SerializeField]
    private Train train = null;
    [SerializeField]
    private Transform[] soundEmitters = null;

    private StudioEventEmitter[] sees = null;
    private List<float>[] distancesTillSound = new List<float>[0];

    private float drivenDistance = 0f;

    private int klonkEmitterRunningIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        sees = new StudioEventEmitter[soundEmitters.Length];
        distancesTillSound = new List<float>[sees.Length];
        for (int i = 0; i < sees.Length; i++)
        {
            sees[i] = soundEmitters[i].GetComponent<StudioEventEmitter>();
            distancesTillSound[i] = new List<float>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceDelta = train.CurrentSpeed * Time.deltaTime;
        drivenDistance += distanceDelta;

        if (drivenDistance >= metersKlonk)
        {
            drivenDistance -= metersKlonk;

            spawnKlonk();
        }


        for (int i = 0; i < distancesTillSound.Length; i++)
        {
            for (int j = 0; j < distancesTillSound[i].Count; j++)
            {
                distancesTillSound[i][j] -= distanceDelta;
                if (distancesTillSound[i][j] <= 0f)
                {
                    sees[i].Play();
                    distancesTillSound[i].RemoveAt(j);
                    break;
                }
            }
        }
    }

    private void spawnKlonk()
    {
        Debug.Log("Spawning klonk");
        Vector3 spawnPos = train.Locomotive.transform.position + train.Locomotive.transform.forward * metersSpawnInfrontLoc;

        soundEmitters[klonkEmitterRunningIndex].position = spawnPos;

        distancesTillSound[klonkEmitterRunningIndex].Add(0f);

        float sum = 0f;
        for (int i = 0; i < train.DistancesBetween.Length; i++)
        {
            distancesTillSound[klonkEmitterRunningIndex].Add(train.DistancesBetween[i] + sum);
            sum += train.DistancesBetween[i];
        }

        klonkEmitterRunningIndex++;
        klonkEmitterRunningIndex = klonkEmitterRunningIndex % sees.Length;
    }
}
