using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainPart : MonoBehaviour
{
    [SerializeField]
    private float weight = 0f;

    private Railroad railroad;
    private SwitchSetting switchSetting;

    private RailSegment prevRailSeg = null;
    private RailSegment curRailSeg = null;
    private RailSegment nextRailSeg = null;


    // Start is called before the first frame update
    protected virtual void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
    /*
    public void Initialize(Railroad railRoad, RailSegment startSegment, SwitchSetting switchSetting)
    {
        this.switchSetting = switchSetting;
        this.railroad = railRoad;

        if (startSegment == null)
        {
            startSegment = railRoad.FirstSegment;
        }

        curRailSeg = startSegment;
        prevRailSeg = startSegment.PreviousSegments[0];
        nextRailSeg = startSegment.FollowingSegments[0];

        switchSetting.SwitchChange += SwitchSetting_SwitchChange;
    }

    private void SwitchSetting_SwitchChange(int oldSwitchPos, int newSwitchPos)
    {

    }

    public float StepNextSpline()
    {
        prevRailSeg = curRailSeg;
        curRailSeg = nextRailSeg;

        int curSwitch = switchSetting.CurrentSetting;
        curSwitch = Mathf.Clamp(curSwitch, 0, curRailSeg.FollowingSegments.Length - 1);

        nextRailSeg = curRailSeg.FollowingSegments[curSwitch];

        return prevRailSeg.Length;
    }

    public float StepPreviousSpline()
    {
        nextRailSeg = curRailSeg;
        curRailSeg = prevRailSeg;

        int curSwitch = switchSetting.CurrentSetting;
        curSwitch = Mathf.Clamp(curSwitch, 0, curRailSeg.PreviousSegments.Length - 1);

        prevRailSeg = curRailSeg.PreviousSegments[curSwitch];

        return curRailSeg.Length;
    }

    public void LocomotiveStepNextSpline(RailSegment railSegment)
    {

    }

    public void LocomotiveStepPreviousSpline(RailSegment railSegment)
    {

    }

    public RailSegment RailSegmentPrev
    {
        get
        {
            return prevRailSeg;
        }
    }

    public RailSegment RailSegmentCur
    {
        get
        {
            return curRailSeg;
        }
    }

    public RailSegment RailSegmentNext
    {
        get
        {
            return nextRailSeg;
        }
    }
    */


    public float Weight
    {
        get
        {
            return weight;
        }
    }
}
