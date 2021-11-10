using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class ProcKilometersPlacer : MonoBehaviour
{
    public bool placeKilometers = false;
    public bool rightSide = false;
    public int startKMOffset = 0;
    public int endKMOffset = 0;
    public int meterStepSize;
    public int dividerForSign;
    public float signSideOffset = 0f;

    public Spline splineToPlace = null;

    [Space]
    [Header("References")]
    public GameObject prefabKilometerSign;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (placeKilometers)
        {
            placeKilometers = false;

            placeKilometersOnSpline();
        }
    }

    private void placeKilometersOnSpline()
    {
        float splineS = 0f;

        float step = meterStepSize;

        float splineLengthClamped = (int)(splineToPlace.Length / meterStepSize);
        splineLengthClamped *= meterStepSize;
        splineLengthClamped /= dividerForSign;

        while (splineS >= 0f && splineS < splineToPlace.Length)
        {
            float nextSplineS = splineS + step;

            int clamped = (int)(splineS / meterStepSize);
            int clampedNext = (int)(nextSplineS / meterStepSize);

            if (clamped != clampedNext)
            {
                int toTake = Mathf.Max(clamped, clampedNext);
                toTake *= meterStepSize;

                float signValue = toTake / ((float)dividerForSign);
                float distanceToStart = signValue + startKMOffset;
                float distanceToEnd = (splineLengthClamped - signValue) + endKMOffset;

                GameObject instSign = spawnSign(splineS, distanceToStart, distanceToEnd);
            }

            splineS = nextSplineS;
        }
    }

    private GameObject spawnSign(float splineS, float frontValue, float backValue)
    {
        CurveSample curveSample = splineToPlace.GetSampleAtDistance(splineS);

        GameObject instSign = Instantiate(prefabKilometerSign, transform);
        instSign.transform.position = curveSample.location;

        Vector3 sideVec = new Vector3(curveSample.tangent.z, 0f, -curveSample.tangent.x);
        if (rightSide == false)
        {
            sideVec = new Vector3(-curveSample.tangent.z, 0f, curveSample.tangent.x);
        }

        instSign.transform.position += sideVec.normalized * signSideOffset;

        RaycastHit hit; 
        if (Physics.Raycast(new Ray(instSign.transform.position + new Vector3(0f, 100f, 0f), Vector3.down), out hit, 200f))
        {
            instSign.transform.position = hit.point;
        }

        instSign.transform.forward = curveSample.tangent;

        TextMeshPro[] textMeshes = instSign.GetComponentsInChildren<TextMeshPro>();

        TextMeshPro textFront = textMeshes[0];
        TextMeshPro textBack = textMeshes[1];

        if (textFront.transform.localPosition.z < textBack.transform.localPosition.z)
        {
            textFront = textMeshes[1];
            textBack = textMeshes[0];
        }

        textFront.text = frontValue.ToString("n1");
        textBack.text = backValue.ToString("n1");


        return instSign;
    }
}
