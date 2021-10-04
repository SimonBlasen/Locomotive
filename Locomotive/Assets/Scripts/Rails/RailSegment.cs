using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSegment : MonoBehaviour
{
    [SerializeField]
    private RailSegment[] followingSegments = null;

    private Spline spline = null;

    [SerializeField]
    private RailSegment[] previousSegments = null;


    public void CalculateFollowingPrevious(RailSegment[] allRailSegments)
    {
        float epsilon = 2.3f;
        Vector3 beginPos = Spline.GetSampleAtDistance(0.1f).location;
        Vector3 endPos = Spline.GetSampleAtDistance(spline.Length - 0.1f).location;

        List<RailSegment> followingSegs = new List<RailSegment>();
        List<RailSegment> previousSegs = new List<RailSegment>();

        for (int i = 0; i < allRailSegments.Length; i++)
        {
            if (allRailSegments[i].transform.GetInstanceID() != transform.GetInstanceID())
            {
                if ((Vector3.Distance(beginPos, allRailSegments[i].Spline.GetSampleAtDistance(0.1f).location) <= epsilon
                        && Vector3.Angle(-Spline.GetSampleAtDistance(0.1f).tangent, -allRailSegments[i].Spline.GetSampleAtDistance(0.1f).tangent) > 90f)
                    || (Vector3.Distance(beginPos, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).location) <= epsilon
                        && Vector3.Angle(-Spline.GetSampleAtDistance(0.1f).tangent, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).tangent) > 90f))
                {
                    previousSegs.Add(allRailSegments[i]);
                }
                else if ((Vector3.Distance(endPos, allRailSegments[i].Spline.GetSampleAtDistance(0.1f).location) <= epsilon
                        && Vector3.Angle(Spline.GetSampleAtDistance(Spline.Length - 0.1f).tangent, -allRailSegments[i].Spline.GetSampleAtDistance(0.1f).tangent) > 90f)
                    || (Vector3.Distance(endPos, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).location) <= epsilon
                        && Vector3.Angle(Spline.GetSampleAtDistance(Spline.Length - 0.1f).tangent, allRailSegments[i].Spline.GetSampleAtDistance(allRailSegments[i].Spline.Length - 0.1f).tangent) > 90f))
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
            tempTrans.transform.position = curveEnd.location;
            tempTrans.transform.up = Vector3.Cross(Vector3.up, curveEnd.tangent);

            float yPos0 = tempTrans.transform.InverseTransformPoint(followingSegments[0].Spline.GetSampleAtDistance(5f).location).y;
            float yPos1 = tempTrans.transform.InverseTransformPoint(followingSegments[1].Spline.GetSampleAtDistance(5f).location).y;

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
            tempTrans.transform.position = curveEnd.location;
            tempTrans.transform.up = Vector3.Cross(Vector3.up, curveEnd.tangent);

            float yPos0 = tempTrans.transform.InverseTransformPoint(previousSegments[0].Spline.GetSampleAtDistance(previousSegments[0].Spline.Length - 5f).location).y;
            float yPos1 = tempTrans.transform.InverseTransformPoint(previousSegments[1].Spline.GetSampleAtDistance(previousSegments[1].Spline.Length - 5f).location).y;

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
