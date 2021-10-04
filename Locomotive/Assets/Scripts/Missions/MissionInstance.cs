using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInstance : MonoBehaviour
{
    private int[] missionTriggersSides = null;
    private MissionTrigger[] missionTriggers = null;

    private bool initedMissionTriggers = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        missionTriggers = GetComponentsInChildren<MissionTrigger>();
        missionTriggersSides = new int[missionTriggers.Length];

        for (int i = 0; i < missionTriggers.Length; i++)
        {
            missionTriggersSides[i] = 0;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!initedMissionTriggers)
        {
            initializeMissionTriggers();
        }
    }

    public Train PlayerTrain
    {
        get; set;
    } = null;

    public virtual void MissionStart()
    {

    }

    public virtual void EnterRailsegment(RailSegment railSegment)
    {

    }

    public virtual void StopInTrainstation(TrainStation trainStation)
    {

    }

    public virtual void PassTrigger(MissionTrigger missionTrigger)
    {
        Debug.Log("Passing mission trigger");
    }


    public void RefreshMissionTriggers()
    {
        for (int i = 0; i < missionTriggers.Length; i++)
        {
            if (missionTriggers[i].IsReady)
            {
                int oldValue = missionTriggersSides[i];
                int newValue = missionTriggers[i].CheckSideOfTrain();
                if (oldValue != 0 && newValue != 0 && oldValue != newValue)
                {
                    PassTrigger(missionTriggers[i]);
                }
                missionTriggersSides[i] = newValue;
            }
        }
    }


    private void initializeMissionTriggers()
    {
        bool allReady = true;
        for (int i = 0; i < missionTriggers.Length; i++)
        {
            if (missionTriggers[i].IsReady == false)
            {
                allReady = false;
                break;
            }
        }

        if (allReady)
        {
            initedMissionTriggers = true;

            MissionStart();

            /*for (int i = 0; i < missionTriggers.Length; i++)
            {
                MissionTrigger missionTrigger = missionTriggers[i];

            }*/
        }
    }
}
