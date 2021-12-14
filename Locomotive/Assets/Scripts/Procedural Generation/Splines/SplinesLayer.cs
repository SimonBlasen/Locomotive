using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SplinesLayer : MonoBehaviour
{
    [Header("Run")]
    [SerializeField]
    private bool generateSpline = false;

    [Space]

    [Header("Settings")]
    [SerializeField]
    private float maxAngle = 90f;
    [SerializeField]
    private int circleStepAngle = 5;
    [SerializeField]
    private float cpDistance = 300f;
    [SerializeField]
    private float distanceFromOuterBorders = 300f;
    [SerializeField]
    private float maxHeightDiffPerCP = 10f;
    [SerializeField]
    private float smoothDirDistanceFac = 0.8f;
    [SerializeField]
    private int cpsAmount = 10;

    [Space]

    [Header("References")]
    [SerializeField]
    private Spline toAdjustSpline = null;
    [SerializeField]
    private Transform startPositionTrans = null;
    [SerializeField]
    private Vector2 startDirection = Vector2.one;

    [Space]

    [Header("Debug")]
    [SerializeField]
    private Transform[] circlePosDebug;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generateSpline)
        {
            generateSpline = false;

            genSpline();
        }
    }


    private void genSpline()
    {
        Vector3 startHitPoint = Vector3.zero;
        RaycastHit[] startHits = Physics.RaycastAll(new Ray(new Vector3(startPositionTrans.position.x, 10000f, startPositionTrans.position.z), Vector3.down), 10000f);
        for (int k = 0; k < startHits.Length; k++)
        {
            if (startHits[k].transform.name.Contains("Terrain"))
            {
                startHitPoint = startHits[k].point;
            }
        }
        TSConPoint startPoint = new TSConPoint(startHitPoint, (new Vector3(startDirection.x, 0f, startDirection.y)).normalized + startHitPoint);

        List<TSConPoint> cps = new List<TSConPoint>();
        cps.Add(startPoint);

        for (int i = 0; i < cpsAmount + 1; i++)
        {
            makeNextStep(cps);
        }

        smoothSpline(cps);

        cps.RemoveAt(cps.Count - 1);








        while (toAdjustSpline.nodes.Count > 2)
        {
            toAdjustSpline.RemoveNode(toAdjustSpline.nodes[0]);
        }
        toAdjustSpline.nodes[0].Position = cps[0].pos;
        toAdjustSpline.nodes[0].Direction = cps[0].dir;
        toAdjustSpline.nodes[1].Position = cps[1].pos;
        toAdjustSpline.nodes[1].Direction = cps[1].dir;
        for (int i = 2; i < cps.Count; i++)
        {
            toAdjustSpline.AddNode(new SplineNode(cps[i].pos, cps[i].dir));
        }
        toAdjustSpline.RefreshCurves();
    }

    private void makeNextStep(List<TSConPoint> cps)
    {
        TSConPoint curPoint = cps[cps.Count - 1];

        List<Vector3> circlePoints = new List<Vector3>();

        int multiAngle = 0;
        while (multiAngle < maxAngle)
        {
            multiAngle += circleStepAngle;
        }
        multiAngle -= circleStepAngle;

        float heightTendency = 0f;

        int debugCounter = 0;
        for (int angleUp = -multiAngle; angleUp < maxAngle; angleUp += circleStepAngle)
        {
            Vector3 circlePoint = new Vector3(curPoint.pos.x, 10000f, curPoint.pos.z);
            circlePoint += Quaternion.Euler(0f, angleUp, 0f) * (curPoint.DirVec.normalized * cpDistance);


            RaycastHit[] hits = Physics.RaycastAll(new Ray(circlePoint, Vector3.down), 10000f);
            for (int k = 0; k < hits.Length; k++)
            {
                if (hits[k].transform.name.Contains("Terrain"))
                {
                    circlePoint = hits[k].point;
                    break;
                }
            }
            /*if (cps.Count == 2)
            {
                circlePosDebug[debugCounter].position = circlePoint;
                debugCounter++;
            }*/

            if (isInsideGlobalBorders(circlePoint))
            {
                circlePoints.Add(circlePoint);

                heightTendency += circlePoint.y;
            }
        }

        heightTendency /= circlePoints.Count;

        heightTendency = Mathf.Clamp(heightTendency, curPoint.pos.y - maxHeightDiffPerCP, curPoint.pos.y + maxHeightDiffPerCP);






        float minHeightDiff = float.MaxValue;
        int minCircleIndex = -1;
        for (int i = 0; i < circlePoints.Count; i++)
        {
            if (Mathf.Abs(circlePoints[i].y - heightTendency) < minHeightDiff)
            {
                minHeightDiff = Mathf.Abs(circlePoints[i].y - heightTendency);
                minCircleIndex = i;
            }
        }




        Vector3 dirVec = circlePoints[minCircleIndex] - curPoint.pos;
        dirVec.y = 0f;
        Vector3 dir = dirVec + circlePoints[minCircleIndex];
        //dir.y = 0f;
        //dir.Normalize();
        TSConPoint nextPoint = new TSConPoint(circlePoints[minCircleIndex], dir);
        cps.Add(nextPoint);
    }

    private bool isInsideGlobalBorders(Vector3 vec)
    {
        return vec.x >= distanceFromOuterBorders && vec.z >= distanceFromOuterBorders && vec.x <= 100000f - distanceFromOuterBorders && vec.z <= 100000f - distanceFromOuterBorders;
    }

    private void smoothSpline(List<TSConPoint> cps)
    {
        for (int i = 1; i < cps.Count - 1; i++)
        {
            Vector3 vecFromTo = cps[i + 1].pos - cps[i - 1].pos;

            float summedDistance = (Vector3.Distance(cps[i].pos, cps[i - 1].pos) + Vector3.Distance(cps[i].pos, cps[i + 1].pos));

            cps[i].dir = vecFromTo.normalized * summedDistance * 0.5f * smoothDirDistanceFac + cps[i].pos;
        }
    }
}
