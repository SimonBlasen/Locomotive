using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSegment : MonoBehaviour
{
    [SerializeField]
    private RailSegment[] followingSegments = null;

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
}
