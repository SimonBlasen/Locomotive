using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStationAmbientSnapshotter : MonoBehaviour
{
    [SerializeField]
    private StudioEventEmitter snapshotTrainstationAmbient = null;

    private bool flipflop = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            flipflop = !flipflop;
            if (flipflop)
            {
                snapshotTrainstationAmbient.Play();
            }
            else
            {
                snapshotTrainstationAmbient.Stop();
            }
        }
    }
}
