using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailSegment : MonoBehaviour
{
    [SerializeField]
    private RailSegment[] followingSegments = null;

    private Spline spline = null;

    // Start is called before the first frame update
    void Awake()
    {
        spline = GetComponentInChildren<Spline>();
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

    public RailSegment[] FollowingSegments
    {
        get
        {
            return followingSegments;
        }
    }
}
