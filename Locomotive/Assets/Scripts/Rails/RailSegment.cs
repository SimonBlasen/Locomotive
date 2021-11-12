using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSegment : MonoBehaviour
{
    public string checkString = "";

    [SerializeField]
    private RailSegment[] followingSegments = null;

    private Spline spline = null;

    [SerializeField]
    private RailSegment[] previousSegments = null;


    public void CalculateFollowingPrevious(RailSegment[] allRailSegments)
    {
        float epsilon = 2.3f;
        float angleEpsilon = 20f;
        Vector3 beginPos = Spline.GetSampleAtDistance(0.1f).location + GlobalOffsetManager.Inst.GlobalOffset;
        Vector3 endPos = Spline.GetSampleAtDistance(spline.Length - 0.1f).location + GlobalOffsetManager.Inst.GlobalOffset;

        List<RailSegment> followingSegs = new List<RailSegment>();
        List<RailSegment> previousSegs = new List<RailSegment>();

        if (checkString == "Debug0" || checkString == "Debug1")
        {
            Debug.Log("Debug");
        }

        for (int i = 0; i < allRailSegments.Length; i++)
        {
            if (allRailSegments[i].transform.GetInstanceID() != transform.GetInstanceID())
            {
                float dist0 = Vector3.Distance(beginPos, allRailSegments[i].Spline.GetSampleAtDistance(0.1f).location + GlobalOffsetManager.Inst.GlobalOffset);
                float dist1 = Vector3.Distance(beginPos, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).location + GlobalOffsetManager.Inst.GlobalOffset);
                float dist2 = Vector3.Distance(endPos, allRailSegments[i].Spline.GetSampleAtDistance(0.1f).location + GlobalOffsetManager.Inst.GlobalOffset);
                float dist3 = Vector3.Distance(endPos, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).location + GlobalOffsetManager.Inst.GlobalOffset);

                float angle0 = Vector3.Angle(-Spline.GetSampleAtDistance(0.1f).tangent, -allRailSegments[i].Spline.GetSampleAtDistance(0.1f).tangent);
                float angle1 = Vector3.Angle(-Spline.GetSampleAtDistance(0.1f).tangent, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).tangent);
                float angle2 = Vector3.Angle(Spline.GetSampleAtDistance(Spline.Length - 0.1f).tangent, -allRailSegments[i].Spline.GetSampleAtDistance(0.1f).tangent);
                float angle3 = Vector3.Angle(Spline.GetSampleAtDistance(Spline.Length - 0.1f).tangent, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).tangent);


                if ((Vector3.Distance(beginPos, allRailSegments[i].Spline.GetSampleAtDistance(0.1f).location + GlobalOffsetManager.Inst.GlobalOffset) <= epsilon
                        && (angle0 <= angleEpsilon || (180f - angle0) <= angleEpsilon))
                    || (Vector3.Distance(beginPos, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).location + GlobalOffsetManager.Inst.GlobalOffset) <= epsilon
                        && (angle1 <= angleEpsilon || (180f - angle1) <= angleEpsilon)))
                {
                    previousSegs.Add(allRailSegments[i]);
                }
                else if ((Vector3.Distance(endPos, allRailSegments[i].Spline.GetSampleAtDistance(0.1f).location + GlobalOffsetManager.Inst.GlobalOffset) <= epsilon
                        && (angle2 <= angleEpsilon || (180f - angle2) <= angleEpsilon))
                    || (Vector3.Distance(endPos, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).location + GlobalOffsetManager.Inst.GlobalOffset) <= epsilon
                        && (angle3 <= angleEpsilon || (180f - angle3) <= angleEpsilon)))
                {
                    followingSegs.Add(allRailSegments[i]);
                }
            }
        }

        followingSegments = followingSegs.ToArray();
        previousSegments = previousSegs.ToArray();

        checkLeftRight();
    }

    private void checkLeftRight()
    {
        if (followingSegments.Length >= 2)
        {
            GameObject tempTrans = new GameObject("Temp Trans");
            CurveSample curveEnd = spline.GetSampleAtDistance(spline.Length - 1f);
            tempTrans.transform.position = curveEnd.location + GlobalOffsetManager.Inst.GlobalOffset;
            tempTrans.transform.up = Vector3.Cross(Vector3.up, curveEnd.tangent);

            float yPos0 = tempTrans.transform.InverseTransformPoint(followingSegments[0].Spline.GetSampleAtDistance(5f).location + GlobalOffsetManager.Inst.GlobalOffset).y;
            float yPos1 = tempTrans.transform.InverseTransformPoint(followingSegments[1].Spline.GetSampleAtDistance(5f).location + GlobalOffsetManager.Inst.GlobalOffset).y;

            if (yPos0 <= yPos1)
            {
                Debug.Log("Switched segments");
                RailSegment cached = followingSegments[1];
                followingSegments[1] = followingSegments[0];
                followingSegments[0] = cached;
            }

            Destroy(tempTrans);
        }


        if (previousSegments.Length >= 2)
        {
            GameObject tempTrans = new GameObject("Temp Trans");
            CurveSample curveEnd = spline.GetSampleAtDistance(1f);
            tempTrans.transform.position = curveEnd.location + GlobalOffsetManager.Inst.GlobalOffset;
            tempTrans.transform.up = Vector3.Cross(Vector3.up, curveEnd.tangent);

            float yPos0 = tempTrans.transform.InverseTransformPoint(previousSegments[0].Spline.GetSampleAtDistance(previousSegments[0].Spline.Length - 5f).location + GlobalOffsetManager.Inst.GlobalOffset).y;
            float yPos1 = tempTrans.transform.InverseTransformPoint(previousSegments[1].Spline.GetSampleAtDistance(previousSegments[1].Spline.Length - 5f).location + GlobalOffsetManager.Inst.GlobalOffset).y;

            if (yPos0 >= yPos1)
            {
                Debug.Log("Switched segments");
                RailSegment cached = previousSegments[1];
                previousSegments[1] = previousSegments[0];
                previousSegments[0] = cached;
            }

            Destroy(tempTrans);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Spline Spline
    {
        get
        {
            if (spline == null)
            {
                spline = GetComponentInChildren<Spline>();
            }
            return spline;
        }
    }

    /*public int ID
    {
        get; set;
    } = -1;*/

    public int ID
    {
        get; set;
    } = -1;

    public float Length
    {
        get
        {
            return Spline.Length;
        }
    }

    public RailSegment[] FollowingSegments
    {
        get
        {
            return followingSegments;
        }
    }

    public RailSegment[] PreviousSegments
    {
        get
        {
            return previousSegments;
        }
    }

    public RailSegment[] FlippedSegments(bool flipped)
    {
        return flipped ? previousSegments : followingSegments;
    }
}
