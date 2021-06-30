using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [Header("Rails")]
    [SerializeField]
    private Railroad railRoad = null;
    [SerializeField]
    private RailSegment startRailSegment = null;

    [Header("Locomotive")]
    [SerializeField]
    private Locomotive locomotive = null;

    [Header("Wagons")]
    [SerializeField]
    private Wagon[] wagons = null;
    [Header("Distance InBetween")]
    [SerializeField]
    private float[] distancesBetween = null;

    [Header("Settings")]
    [SerializeField]
    private float acceleration = 1f;
    [SerializeField]
    private float deceleration = 1f;
    [SerializeField]
    private float topSpeed = 100f;
    [SerializeField]
    private AnimationCurve accelerationCurve = null;
    [SerializeField]
    private float audioFactor = 6f;
    [SerializeField]
    private float actualPhysicalSpeedCorrection = 0.3f;

    [Space]

    [Header("References")]
    [SerializeField]
    private SwitchSetting switchSetting = null;

    [FMODUnity.EventRef]
    public string fmodEventTrainSound;


    public float curVelocity = 0f;
    public float curPos = 0f;

    private float distanceTotalTrain = 0f;

    private float[] summedDistances = null;

    private FMOD.Studio.EventInstance instanceTrainSound;

    private RailSegment prevRailSeg = null;
    private RailSegment curRailSeg = null;
    private RailSegment nextRailSeg = null;

    // Start is called before the first frame update
    void Start()
    {
        instanceTrainSound = FMODUnity.RuntimeManager.CreateInstance(fmodEventTrainSound);
        instanceTrainSound.start();
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

        curPos = distanceTotalTrain + 1f;

        if (startRailSegment == null)
        {
            startRailSegment = railRoad.FirstSegment;
        }

        curRailSeg = startRailSegment;
        prevRailSeg = startRailSegment.PreviousSegments[0];
        nextRailSeg = startRailSegment.FollowingSegments[0];

        switchSetting.SwitchChange += SwitchSetting_SwitchChange;


        // Register in train stations
        TrainStation[] trainStations = FindObjectsOfType<TrainStation>();
        for (int i = 0; i < trainStations.Length; i++)
        {
            trainStations[i].RegisterTrain(this);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curPos += curVelocity * Time.fixedDeltaTime * actualPhysicalSpeedCorrection;

        //CurveSample curveSample = railRoad.GetRailAt(curPos);
        int usedSegment;
        CurveSample curveSample = railRoad.GetRailAt(prevRailSeg, curRailSeg, nextRailSeg, curPos, out usedSegment);
        if (usedSegment == 1)
        {
            stepNextSpline();
        }
        else if (usedSegment == -1)
        {
            stepPreviousSpline();
        }


        if (curveSample == null)
        {
            curVelocity = 0f;
        }
        else
        {
            locomotive.transform.position = curveSample.location;
            locomotive.transform.rotation = Quaternion.LookRotation(curveSample.tangent, curveSample.up);

            for (int i = 0; i < wagons.Length; i++)
            {
                CurveSample curveSampleWagon = railRoad.GetRailAt(prevRailSeg, curRailSeg, nextRailSeg, curPos - summedDistances[i], out usedSegment);
                //CurveSample curveSampleWagon = railRoad.GetRailAt(curPos - summedDistances[i]);
                wagons[i].transform.position = curveSampleWagon.location;
                wagons[i].transform.rotation = Quaternion.LookRotation(curveSampleWagon.tangent, curveSampleWagon.up);
            }
        }


        // Accelerating
        float curAccStep = PressureWheels * Time.fixedDeltaTime * accelerationCurve.Evaluate(curVelocity);

        curVelocity = Mathf.MoveTowards(curVelocity, topSpeed, curAccStep);

        // Braking
        float curDeceleration = BrakeStrength * Time.fixedDeltaTime * deceleration;
        curVelocity = Mathf.MoveTowards(curVelocity, 0f, curDeceleration);
        
        instanceTrainSound.setParameterByName("RPM", (CurrentSpeed / topSpeed) * 100f * audioFactor);

        /*if (TargetSpeed > curVelocity)
        {
            curVelocity = Mathf.MoveTowards(curVelocity, TargetSpeed, Time.deltaTime * acceleration);
        }
        else
        {
            curVelocity = Mathf.MoveTowards(curVelocity, TargetSpeed, Time.deltaTime * deceleration);
        }*/
    }

    private void stepNextSpline()
    {
        prevRailSeg = curRailSeg;
        curRailSeg = nextRailSeg;

        int curSwitch = switchSetting.CurrentSetting;
        curSwitch = Mathf.Clamp(curSwitch, 0, curRailSeg.FollowingSegments.Length - 1);

        nextRailSeg = curRailSeg.FollowingSegments[curSwitch];

        curPos -= prevRailSeg.Length;
    }

    private void stepPreviousSpline()
    {
        nextRailSeg = curRailSeg;
        curRailSeg = prevRailSeg;

        int curSwitch = switchSetting.CurrentSetting;
        curSwitch = Mathf.Clamp(curSwitch, 0, curRailSeg.PreviousSegments.Length - 1);

        prevRailSeg = curRailSeg.PreviousSegments[curSwitch];

        curPos += curRailSeg.Length;
    }

    private void SwitchSetting_SwitchChange(int oldSwitchPos, int newSwitchPos)
    {
        int curSwitch = newSwitchPos;
        curSwitch = Mathf.Clamp(curSwitch, 0, curRailSeg.FollowingSegments.Length - 1);

        nextRailSeg = curRailSeg.FollowingSegments[curSwitch];
    }

    private void OnDestroy()
    {
        TrainStation[] trainStations = FindObjectsOfType<TrainStation>();
        for (int i = 0; i < trainStations.Length; i++)
        {
            trainStations[i].DeregisterTrain(this);
        }
    }


    public float TargetSpeed
    {
        get; set;
    } = 0f;

    public float PressureWheels
    {
        get; set;
    } = 0f;

    public float BrakeStrength
    {
        get; set;
    } = 0f;

    public float CurPosOnSPline
    {
        get
        {
            return curPos;
        }
    }

    public float PosOfLastWagon
    {
        get
        {
            return curPos - LengthOfWholeTrain;
        }
    }

    public float LengthOfWholeTrain
    {
        get
        {
            return distanceTotalTrain;
        }
    }

    public RailSegment CurrentRailSegment
    {
        get
        {
            return curRailSeg;
        }
    }

    public float CurrentSpeed
    {
        get
        {
            return curVelocity;
        }
    }
}
