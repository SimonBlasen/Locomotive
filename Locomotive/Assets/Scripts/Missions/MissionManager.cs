using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Train playerTrain = null;

    [Space]

    [Header("Missions")]
    [SerializeField]
    private GameObject[] missions = null;

    [Space]

    [Header("Settings")]
    [SerializeField]
    private float missionTriggersRefreshRate = 2f;

    private MissionInstance runningMission = null;
    private float mtRefreshCounter = 0f;

    private RailSegment oldRailSegment = null;
    private TrainStation oldTrainStation = null;

    // Start is called before the first frame update
    void Start()
    {
        Radio = playerTrain.GetComponentInChildren<Radio>();
        StartMission(0);
    }

    // Update is called once per frame
    void Update()
    {
        mtRefreshCounter += Time.deltaTime;

        if (mtRefreshCounter >= missionTriggersRefreshRate)
        {
            mtRefreshCounter = 0f;

            if (runningMission != null)
            {
                runningMission.RefreshMissionTriggers();

                if (oldRailSegment != playerTrain.CurrentRailSegment)
                {
                    oldRailSegment = playerTrain.CurrentRailSegment;
                    runningMission.EnterRailsegment(oldRailSegment);
                }

                if (playerTrain.CurrentTrainStation != oldTrainStation)
                {
                    oldTrainStation = playerTrain.CurrentTrainStation;
                    if (oldTrainStation != null)
                    {
                        runningMission.StopInTrainstation(oldTrainStation);
                    }
                }
            }
        }
    }

    public void StartMission(int missionIndex)
    {
        GameObject instMission = Instantiate(missions[missionIndex], transform);
        instMission.transform.position = Vector3.zero;
        runningMission = instMission.GetComponent<MissionInstance>();

        runningMission.PlayerTrain = playerTrain;
        runningMission.Fire = playerTrain.GetComponentInChildren<Fire>();
        runningMission.MissionManager = this;
    }

    public Radio Radio
    {
        get; protected set;
    } = null;
}
