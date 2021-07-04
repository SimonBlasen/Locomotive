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


    // Start is called before the first frame update
    void Start()
    {
        allRailSegments = FindObjectsOfType<RailSegment>();
        for (int i = 0; i < allRailSegments.Length; i++)
        {
            allRailSegments[i].CalculateFollowingPrevious(allRailSegments);
        }

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
}
