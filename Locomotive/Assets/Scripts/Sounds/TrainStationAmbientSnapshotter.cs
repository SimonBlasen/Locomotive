using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStationAmbientSnapshotter : MonoBehaviour
{
    [SerializeField]
    private StudioEventEmitter snapshotTrainstationAmbient = null;

    private bool flipflop = false;

    private RailroadMapTrainstation[] railroadMapTrainstations = null;

    private float checkTrainstations = 0f;

    private bool isInATrainStation = false;

    // Start is called before the first frame update
    void Start()
    {
        railroadMapTrainstations = transform.parent.GetComponentsInChildren<RailroadMapTrainstation>();
    }

    // Update is called once per frame
    void Update()
    {
        checkTrainstations += Time.deltaTime;
        if (checkTrainstations >= 0.7f)
        {
            bool wasInATrainStation = isInATrainStation;
            isInATrainStation = false;
            checkTrainstations = 0f;

            for (int i = 0; i < railroadMapTrainstations.Length; i++)
            {
                if (railroadMapTrainstations[i].IsTrainOnSegment || railroadMapTrainstations[i].IsTrainInStation)
                {
                    isInATrainStation = true;
                    break;
                }
            }

            if (isInATrainStation != wasInATrainStation)
            {
                if (isInATrainStation)
                {
                    snapshotTrainstationAmbient.Play();
                }
                else
                {
                    snapshotTrainstationAmbient.Stop();
                }
            }
        }

        /*if (Input.GetKey(KeyCode.T))
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
        }*/
    }
}
