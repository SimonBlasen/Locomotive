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

    private RailSegment[] allRailSegments = null;

    private int runningRailSegIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        allRailSegments = FindObjectsOfType<RailSegment>();
        for (int i = 0; i < allRailSegments.Length; i++)
        {
            allRailSegments[i].CalculateFollowingPrevious(allRailSegments);
        }

        runningRailSegIndex = 0;
        assignRailsegmentIDs();

        IsReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public RailSegment FirstSegment
    {
        get
        {
            return firstSegment;
        }
    }

    public bool IsReady
    {
        get; protected set;
    } = false;

    private void assignRailsegmentIDs()
    {
        Vector3 min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        int minIndex = -1;

        for (int i = 0; i < allRailSegments.Length; i++)
        {
            Vector3 location0 = allRailSegments[i].Spline.GetSample(0f).location + GlobalOffsetManager.Inst.GlobalOffset;
            Vector3 location1 = allRailSegments[i].Spline.GetSample(1f).location + GlobalOffsetManager.Inst.GlobalOffset;
            if (location0.x + location1.x < min.x && allRailSegments[i].ID == -1)
            {
                min = new Vector3(location0.x + location1.x, location0.y, location0.z);
                minIndex = i;
            }
        }

        assignRailsegIDRec(allRailSegments[minIndex]);

        if (haveAllRailsegmentsIDs() == false)
        {
            assignRailsegmentIDs();
        }
    }

    private void assignRailsegIDRec(RailSegment railSegment)
    {
        if (railSegment.ID != -1)
        {
            return;
        }

        railSegment.ID = runningRailSegIndex;
        runningRailSegIndex++;

        for (int i = 0; i < railSegment.FollowingSegments.Length; i++)
        {
            assignRailsegIDRec(railSegment.FollowingSegments[i]);
        }
    }

    private bool haveAllRailsegmentsIDs()
    {
        for (int i = 0; i < allRailSegments.Length; i++)
        {
            if (allRailSegments[i].ID == -1)
            {
                return false;
            }
        }

        return true;
    }

    public RailSegment[] AllRailSegments
    {
        get
        {
            return allRailSegments;
        }
    }

    public RailSegment GetRailSegment(int id)
    {
        for (int i = 0; i < allRailSegments.Length; i++)
        {
            if (allRailSegments[i].ID == id)
            {
                return allRailSegments[i];
            }
        }

        return null;
    }
}
