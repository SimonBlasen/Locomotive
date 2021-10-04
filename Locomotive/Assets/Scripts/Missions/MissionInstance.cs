using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInstance : MonoBehaviour
{
    [SerializeField]
    private ScrDialogues dialogues = null;

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

    public MissionManager MissionManager
    {
        get; set;
    } = null;

    public Train PlayerTrain
    {
        get; set;
    } = null;

    public Fire Fire
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

    protected void showDialogue(string dialogueName)
    {
        bool found = false;
        for (int i = 0; i < dialogues.dialogues.Length; i++)
        {
            if (dialogues.dialogues[i].name == dialogueName)
            {
                found = true;

                MissionManager.Radio.ShowDialogue(dialogues.dialogues[i]);

                break;
            }
        }

        if (!found)
        {
            Debug.LogError("Dialogue not found with name \"" + dialogueName + "\"");
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
