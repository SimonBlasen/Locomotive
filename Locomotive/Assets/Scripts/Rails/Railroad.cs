using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railroad : MonoBehaviour
{
    [SerializeField]
    private RailSegment firstSegment = null;

    [Space]

    [Header("References")]
    [SerializeField]
    private SwitchSetting switchSetting = null;

    private List<float> summedDistances = new List<float>();
    private List<RailSegment> railSegments = new List<RailSegment>();

    // Start is called before the first frame update
    void Start()
    {
        railSegments.Add(null);
        summedDistances.Add(0f);
        railSegments.Add(firstSegment);
        summedDistances.Add(firstSegment.Spline.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public CurveSample GetRailAt(RailSegment prevSeg, RailSegment curSeg, RailSegment nextSeg, float localDistance, out int usedSegment)
    {
        // Previous Segment
        if (localDistance < 0f)
        {
            float splineDist = prevSeg.Length + localDistance;
            usedSegment = -1;
            return prevSeg.Spline.GetSampleAtDistance(splineDist);
        }

        // Current Segment
        else if (localDistance < curSeg.Length)
        {
            usedSegment = 0;
            return curSeg.Spline.GetSampleAtDistance(localDistance);
        }

        // Next Segment
        else
        {
            float splineDist = localDistance - curSeg.Length;
            usedSegment = 1;
            return nextSeg.Spline.GetSampleAtDistance(splineDist);
        }
    }

    public CurveSample GetRailAt(float distance)
    {
        for (int i = 1; i < summedDistances.Count; i++)
        {
            if (distance < summedDistances[i]
                && distance >= summedDistances[i - 1])
            {
                return railSegments[i].Spline.GetSampleAtDistance(distance - summedDistances[i - 1]);
            }
        }

        // Too far
        bool reachedEnd = appendNewSegment();

        if (!reachedEnd)
        {
            return GetRailAt(distance);
        }

        return new CurveSample();
    }

    private bool appendNewSegment()
    {
        if (railSegments[railSegments.Count - 1].FollowingSegments.Length > 0)
        {
            int curSwitch = switchSetting.CurrentSetting;
            curSwitch = Mathf.Clamp(curSwitch, 0, railSegments[railSegments.Count - 1].FollowingSegments.Length - 1);

            RailSegment followSegment = railSegments[railSegments.Count - 1].FollowingSegments[curSwitch];

            railSegments.Add(followSegment);
            summedDistances.Add(summedDistances[summedDistances.Count - 1] + followSegment.Spline.Length);

            Debug.Log("Added new segment");

            return false;
        }
        else
        {
            Debug.Log("Train reached end");

            return true;
        }
    }

    public RailSegment FirstSegment
    {
        get
        {
            return firstSegment;
        }
    }
}
