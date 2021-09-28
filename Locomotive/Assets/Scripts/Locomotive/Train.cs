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
    [SerializeField]
    private float gravitySlopeStrength = 0.3f;

    [Space]

    [Header("References")]
    [SerializeField]
    private SwitchSetting switchSetting = null;
    [SerializeField]
    private FMODUnity.StudioEventEmitter tunnelEmitter = null;

    [FMODUnity.EventRef]
    public string fmodEventTrainSound;


    public delegate void RailHandlerInitEvent(TrainRailHandler railHandler);
    public event RailHandlerInitEvent RailHandlerInit;


    public float curVelocity = 0f;
    public float curPos = 0f;

    private float totalWeight = 0f;

    private float distanceTotalTrain = 0f;

    private FMOD.Studio.EventInstance instanceTrainSound;

    private TrainRailHandler railHandler = null;

    private bool inited = false;



    // Start is called before the first frame update
    void Start()
    {
        instanceTrainSound = FMODUnity.RuntimeManager.CreateInstance(fmodEventTrainSound);
        instanceTrainSound.start();


        // Register in train stations
        TrainStation[] trainStations = FindObjectsOfType<TrainStation>();
        for (int i = 0; i < trainStations.Length; i++)
        {
            trainStations[i].RegisterTrain(this);
        }

        totalWeight += locomotive.Weight;
        for (int i = 0; i < wagons.Length; i++)
        {
            totalWeight += wagons[i].Weight;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (tunnelEmitter.IsPlaying())
            {
                tunnelEmitter.Stop();
            }
            else
            {
                tunnelEmitter.Play();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!inited && railRoad.IsReady)
        {
            inited = true;
            railHandler = new TrainRailHandler(distancesBetween, railRoad, startRailSegment, switchSetting);
            RailHandlerInit?.Invoke(railHandler);
        }

        if (inited)
        {
            float velocityStep = curVelocity * Time.fixedDeltaTime * actualPhysicalSpeedCorrection;

            float slopedGravityMass = 0f;

            CurveSample[] curveSamples = railHandler.GetCurves(velocityStep);
            CurveSample curveSample = curveSamples[0];


            if (curveSample == null)
            {
                curVelocity = 0f;
            }
            else
            {
                locomotive.transform.position = curveSample.location;
                locomotive.transform.rotation = Quaternion.LookRotation(curveSample.tangent, curveSample.up);

                float xAngle = Vector3.Angle(Vector3.up, locomotive.transform.forward) - 90f;
                slopedGravityMass += xAngle * locomotive.Weight;

                for (int i = 0; i < wagons.Length; i++)
                {
                    CurveSample curveSampleWagon = curveSamples[i + 1];
                    wagons[i].transform.position = curveSampleWagon.location;
                    wagons[i].transform.rotation = Quaternion.LookRotation(curveSampleWagon.tangent, curveSampleWagon.up);

                    xAngle = Vector3.Angle(Vector3.up, wagons[i].transform.forward) - 90f;
                    slopedGravityMass += xAngle * wagons[i].Weight;
                }
            }


            // Accelerating
            float curAccStep = PressureWheels * Time.fixedDeltaTime * accelerationCurve.Evaluate(curVelocity);

            curVelocity = Mathf.MoveTowards(curVelocity, DriveDirectionForward ? topSpeed : -topSpeed, curAccStep);


            Debug.Log("SlopedGravMass: " + slopedGravityMass.ToString("n2"));

            // Slopes Gravity
            curVelocity += slopedGravityMass * gravitySlopeStrength * Time.fixedDeltaTime;

            // Braking
            float curDeceleration = BrakeStrength * Time.fixedDeltaTime * deceleration;
            curVelocity = Mathf.MoveTowards(curVelocity, 0f, curDeceleration);

            instanceTrainSound.setParameterByName("RPM", Mathf.Abs((CurrentSpeed / topSpeed) * 100f * audioFactor));
        }
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
            return railHandler.CurPosFlipped;
            //return curPos;
        }
    }

    public float PosOfLastWagon
    {
        get
        {
            return railHandler.CurPosFlippedLastWaggon;// curPos - LengthOfWholeTrain;
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
            return railHandler.CurrentRailSegment;
        }
    }

    public TrainRailHandler TrainRailHandler
    {
        get
        {
            return railHandler;
        }
    }

    public float CurrentSpeed
    {
        get
        {
            return curVelocity;
        }
    }

    public bool DriveDirectionForward
    {
        get; set;
    } = true;
}
