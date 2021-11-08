using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionTrigger : MonoBehaviour
{
    private MissionInstance missionInstance = null;

    private bool initialized = false;

    private int railSegmentID = -1;
    private float splineS = 0f;

    private Railroad railroad = null;

    // Start is called before the first frame update
    void Start()
    {
        missionInstance = GetComponentInParent<MissionInstance>();
        railroad = FindObjectOfType<Railroad>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!initialized)
        {
            if (railroad.IsReady)
            {
                initialized = true;
                searchClosestRailSegment();

                IsReady = true;
            }
        }
    }

    private void searchClosestRailSegment()
    {
        RailSegment[] allRailSegments = railroad.AllRailSegments;

        float closestDistance = float.MaxValue;
        int closestIndex = -1;
        for (int i = 0; i < allRailSegments.Length; i++)
        {
            for (int j = 0; j < allRailSegments[i].Spline.Length; j += 1)
            {
                float s = j;
                CurveSample sample = allRailSegments[i].Spline.GetSampleAtDistance(s);

                float distance = Vector3.Distance(transform.position, sample.location + GlobalOffsetManager.Inst.GlobalOffset);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }
        }

        railSegmentID = allRailSegments[closestIndex].ID;

        closestDistance = float.MaxValue;
        int splineLen = (int)allRailSegments[closestIndex].Spline.Length;

        for (int j = 0; j < splineLen; j += 5)
        {
            CurveSample sample = allRailSegments[closestIndex].Spline.GetSampleAtDistance(j);

            float distance = Vector3.Distance(transform.position, sample.location + GlobalOffsetManager.Inst.GlobalOffset);
            if (distance < closestDistance)
            {
                closestDistance = distance;

                splineS = j;
            }
        }
    }

    public int CheckSideOfTrain()
    {
        if (missionInstance.PlayerTrain.TrainRailHandler.GetTrainPoses()[0].splineID != railSegmentID)
        {
            return 0;
        }
        else
        {
            return (missionInstance.PlayerTrain.TrainRailHandler.GetTrainPoses()[0].splineS > splineS) ? 1 : -1;
        }
    }

    public bool IsReady
    {
        get; protected set;
    } = false;
}
