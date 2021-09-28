using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainRailHandler
{
    private Railroad railRoad = null;
    private RailSegment startSegment = null;
    private SwitchSetting switchSetting = null;
    private float[] distancesBetween = null;

    private float[] summedDistances = null;
    private float distanceTotalTrain = 0f;

    private float curPos = 0f;

    private List<RailSegment> runningSegments = new List<RailSegment>();
    private List<bool> segmentsFlippsd = new List<bool>();

    private TrainPartPose[] curTrainPartPoses;

    public TrainRailHandler(float[] distancesBetween, Railroad railRoad, RailSegment startSegment, SwitchSetting switchSetting)
    {
        this.distancesBetween = distancesBetween;
        this.railRoad = railRoad;
        this.startSegment = startSegment;
        this.switchSetting = switchSetting;

        summedDistances = new float[distancesBetween.Length];

        for (int i = 0; i < distancesBetween.Length; i++)
        {
            if (i == 0)
            {
                summedDistances[i] = distancesBetween[i];
            }
            else
            {
                summedDistances[i] = summedDistances[i - 1] + distancesBetween[i];
            }
            distanceTotalTrain += distancesBetween[i];
        }

        curPos = 0.1f;

        if (startSegment == null)
        {
            startSegment = railRoad.FirstSegment;
        }

        switchSetting.SwitchChange += SwitchSetting_SwitchChange;


        runningSegments.Add(startSegment);
        segmentsFlippsd.Add(false);
        float runningPos = curPos;

        for (int i = 0; i < 1000; i++)
        {
            float stepBack = (i / 1000f) * distanceTotalTrain;
            runningPos -= (1f / 1000f) * distanceTotalTrain;

            if (runningPos < 0f)
            {
                RailSegment prev = runningSegments[runningSegments.Count - 1].PreviousSegments[UnityEngine.Random.Range(0, runningSegments[runningSegments.Count - 1].PreviousSegments.Length)];
                runningSegments.Add(prev);

                float distance0 = Vector3.Distance(flippedAcc(runningSegments.Count - 2, 1f).location, prev.Spline.GetSampleAtDistance(1f).location);
                float distance1 = Vector3.Distance(flippedAcc(runningSegments.Count - 2, 1f).location, prev.Spline.GetSampleAtDistance(prev.Spline.Length - 1f).location);

                if (distance0 < distance1)
                {
                    segmentsFlippsd.Add(true);
                }
                else
                {
                    segmentsFlippsd.Add(false);
                }

                runningPos += prev.Spline.Length;
            }
        }

        curTrainPartPoses = new TrainPartPose[distancesBetween.Length + 1];
        for (int i = 0; i < curTrainPartPoses.Length; i++)
        {
            curTrainPartPoses[i] = new TrainPartPose();
        }

        Debug.Log("Initial running segments: " + runningSegments.Count.ToString());
    }

    private CurveSample flippedAcc(int index, float sDistance)
    {
        if (segmentsFlippsd[index])
        {
            CurveSample curveSample = runningSegments[index].Spline.GetSampleAtDistance(runningSegments[index].Spline.Length - sDistance);
            return new CurveSample(curveSample.location, -curveSample.tangent, curveSample.up, curveSample.scale, curveSample.roll, curveSample.distanceInCurve, curveSample.timeInCurve, curveSample.curve);
        }
        else
        {
            return runningSegments[index].Spline.GetSampleAtDistance(sDistance);
        }
    }

    public float CurPosFlipped
    {
        get
        {
            if (segmentsFlippsd[0])
            {
                return runningSegments[0].Spline.Length - curPos;
            }
            else
            {
                return curPos;
            }
        }
    }

    public float CurPosFlippedLastWaggon
    {
        get
        {
            float waggonOffset = summedDistances[summedDistances.Length - 1];
            if (segmentsFlippsd[0])
            {
                return CurPosFlipped + waggonOffset;
            }
            else
            {
                return CurPosFlipped - waggonOffset;
            }
        }
    }

    private void SwitchSetting_SwitchChange(int oldSwitchPos, int newSwitchPos)
    {

    }

    public CurveSample[] GetCurves(float curVelocity)
    {
        CurveSample[] curveSamples = new CurveSample[distancesBetween.Length + 1];

        float oldPos = curPos;
        curPos += curVelocity;

        if (curPos >= runningSegments[0].Length)
        {
            float length = addNewSegmentFront();
            Debug.Log("Added new segment front locomotive");
            curPos -= runningSegments[1].Length;
        }
        else if (curPos < 0f)
        {
            float length = removeSegmentFront();
            Debug.Log("Removed segment front");

            curPos += length;
        }

        curveSamples[0] = flippedAcc(0, curPos);
        curTrainPartPoses[0].splineS = curPos;
        curTrainPartPoses[0].flipped = segmentsFlippsd[0];
        curTrainPartPoses[0].splineID = runningSegments[0].ID;

        for (int i = 0; i < distancesBetween.Length; i++)
        {
            float offsetPos = curPos - summedDistances[i];

            int runningIndex = 0;

            while (offsetPos < 0f)
            {
                runningIndex++;
                if (runningIndex >= runningSegments.Count)
                {
                    addNewSegmentBack();
                    Debug.Log("Added segment back for wagon");
                }

                offsetPos += runningSegments[runningIndex].Length;
            }

            curveSamples[i + 1] = flippedAcc(runningIndex, offsetPos);
            curTrainPartPoses[i + 1].splineS = offsetPos;
            curTrainPartPoses[i + 1].flipped = segmentsFlippsd[runningIndex];
            curTrainPartPoses[i + 1].splineID = runningSegments[runningIndex].ID;

            // Last segment is not used anymore
            if (i == distancesBetween.Length - 1 && runningIndex < runningSegments.Count - 1)
            {
                removeSegmentBack();
                Debug.Log("Removed last segment in the back");
            }
        }

        return curveSamples;
    }

    public TrainPartPose[] GetTrainPoses()
    {
        return curTrainPartPoses;
    }

    private float addNewSegmentFront()
    {
        int curSwitch = switchSetting.CurrentSetting;
        curSwitch = Mathf.Clamp(curSwitch, 0, runningSegments[0].FlippedSegments(segmentsFlippsd[0]).Length - 1);

        RailSegment nextSegment = runningSegments[0].FlippedSegments(segmentsFlippsd[0])[curSwitch];

        List<RailSegment> newRunningSegments = new List<RailSegment>();
        newRunningSegments.Add(nextSegment);
        newRunningSegments.AddRange(runningSegments);
        runningSegments = newRunningSegments;

        List<bool> newFlipped = new List<bool>();
        newFlipped.Add(false);
        newFlipped.AddRange(segmentsFlippsd);
        segmentsFlippsd = newFlipped;

        float distance0 = Vector3.Distance(flippedAcc(1, runningSegments[1].Length - 1f).location, nextSegment.Spline.GetSampleAtDistance(1f).location);
        float distance1 = Vector3.Distance(flippedAcc(1, runningSegments[1].Length - 1f).location, nextSegment.Spline.GetSampleAtDistance(nextSegment.Spline.Length - 1f).location);

        if (distance0 > distance1)
        {
            segmentsFlippsd[0] = true;
        }
        else
        {
            segmentsFlippsd[0] = false;
        }

        return nextSegment.Length;
    }

    private float removeSegmentFront()
    {
        if (runningSegments.Count == 1)
        {
            addNewSegmentBack();
        }

        float length = runningSegments[1].Length;

        runningSegments.RemoveAt(0);
        segmentsFlippsd.RemoveAt(0);

        return length;
    }

    private float addNewSegmentBack()
    {
        int curSwitch = switchSetting.CurrentSetting;
        curSwitch = Mathf.Clamp(curSwitch, 0, runningSegments[runningSegments.Count - 1].FlippedSegments(!segmentsFlippsd[runningSegments.Count - 1]).Length - 1);

        RailSegment nextSegment = runningSegments[runningSegments.Count - 1].FlippedSegments(!segmentsFlippsd[runningSegments.Count - 1])[curSwitch];

        runningSegments.Add(nextSegment);

        float distance0 = Vector3.Distance(flippedAcc(runningSegments.Count - 2, 1f).location, nextSegment.Spline.GetSampleAtDistance(1f).location);
        float distance1 = Vector3.Distance(flippedAcc(runningSegments.Count - 2, 1f).location, nextSegment.Spline.GetSampleAtDistance(nextSegment.Spline.Length - 1f).location);

        if (distance0 < distance1)
        {
            segmentsFlippsd.Add(true);
        }
        else
        {
            segmentsFlippsd.Add(false);
        }

        return nextSegment.Length;
    }

    private float removeSegmentBack()
    {
        runningSegments.RemoveAt(runningSegments.Count - 1);
        segmentsFlippsd.RemoveAt(segmentsFlippsd.Count - 1);

        return runningSegments[runningSegments.Count - 1].Length;
    }

    public RailSegment CurrentRailSegment
    {
        get
        {
            return runningSegments[0];
        }
    }
}
