using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSegment : MonoBehaviour
{
    [SerializeField]
    private RailSegment[] followingSegments = null;
    [SerializeField]
    private bool[] followingSegmentsReversed = null;

    private Spline spline = null;

    private RailSegment[] previousSegments = null;

    // Start is called before the first frame update
    void Awake()
    {
        spline = GetComponentInChildren<Spline>();
        Length = spline.Length;

        RailSegment[] allRailSegments = FindObjectsOfType<RailSegment>();

        List<RailSegment> prevRailSegments = new List<RailSegment>();
        for (int i = 0; i < allRailSegments.Length; i++)
        {
            for (int j = 0; j < allRailSegments[i].followingSegments.Length; j++)
            {
                if (allRailSegments[i].followingSegments[j].transform.GetInstanceID() == transform.GetInstanceID())
                {
                    prevRailSegments.Add(allRailSegments[i]);
                }
            }
        }

        previousSegments = prevRailSegments.ToArray();




        // TODO
        // Check, which way is right and which way is left

        //CurveSample endSpline = spline.GetSampleAtDistance(spline.Length - 1f);
        //Plane planeEnd = new Plane(Vector3.Cross(endSpline.tangent, Vector3.up), endSpline.location);
    }

    private void Start()
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

            if (yPos0 <= yPos1)
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
            return spline;
        }
    }

    public float Length
    {
        get; protected set;
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
