using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [Header("Rails")]
    [SerializeField]
    private Railroad railRoad = null;

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


    public float curVelocity = 0f;
    public float curPos = 0f;

    private float distanceTotalTrain = 0f;

    private float[] summedDistances = null;


    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        curPos += curVelocity * Time.deltaTime;

        CurveSample curveSample = railRoad.GetRailAt(curPos);

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
                CurveSample curveSampleWagon = railRoad.GetRailAt(curPos - summedDistances[i]);
                wagons[i].transform.position = curveSampleWagon.location;
                wagons[i].transform.rotation = Quaternion.LookRotation(curveSampleWagon.tangent, curveSampleWagon.up);
            }
        }


        // Accelerating
        float curAccStep = PressureWheels * Time.deltaTime * accelerationCurve.Evaluate(curVelocity);

        curVelocity = Mathf.MoveTowards(curVelocity, topSpeed, curAccStep);

        // Braking
        float curDeceleration = BrakeStrength * Time.deltaTime * deceleration;
        curVelocity = Mathf.MoveTowards(curVelocity, 0f, curDeceleration);


        /*if (TargetSpeed > curVelocity)
        {
            curVelocity = Mathf.MoveTowards(curVelocity, TargetSpeed, Time.deltaTime * acceleration);
        }
        else
        {
            curVelocity = Mathf.MoveTowards(curVelocity, TargetSpeed, Time.deltaTime * deceleration);
        }*/
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

    public float CurrentSpeed
    {
        get
        {
            return curVelocity;
        }
    }
}
