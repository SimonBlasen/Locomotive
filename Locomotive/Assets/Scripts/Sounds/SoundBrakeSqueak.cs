using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBrakeSqueak : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float speedThresh = 1f;
    [SerializeField]
    private float minBrakePressure = 0.5f;

    [Space]

    [Header("References")]
    [SerializeField]
    private Train train = null;
    [SerializeField]
    private BrakeLeaver brakeLeaver = null;
    [SerializeField]
    private StudioEventEmitter soundEmitter = null;

    private float prevTrainSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (train.CurrentSpeed < speedThresh && prevTrainSpeed >= speedThresh && brakeLeaver.BrakeLevel <= minBrakePressure)
        {
            soundEmitter.Play();
        }


        prevTrainSpeed = train.CurrentSpeed;
    }
}
