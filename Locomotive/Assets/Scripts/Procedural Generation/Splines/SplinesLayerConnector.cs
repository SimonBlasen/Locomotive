using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SplineMesh;

[ExecuteInEditMode]
public class SplinesLayerConnector : MonoBehaviour
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
    [SerializeField]
    private float minDistanceToTargetSpline = 100f;

    [Space]

    [Header("References")]
    [SerializeField]
    private Spline toAdjustSpline = null;
    [SerializeField]
    private Spline fromSpline = null;
    [SerializeField]
    private int fromSplineCPIndex = 0;
    [SerializeField]
    private bool fromSplineForward = false;
    [SerializeField]
    private Spline toSpline = null;



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
        Vector3 startHitPoint = fromSpline.nodes[fromSplineCPIndex].Position;
        Vector3 startDir = fromSpline.nodes[fromSplineCPIndex].Direction;
        if (fromSplineForward == false)
        {
            startDir = startHitPoint + (startHitPoint - startDir);
        }

        TSConPoint startPoint = new TSConPoint(startHitPoint, startDir);

        List<TSConPoint> cps = new List<TSConPoint>();
        cps.Add(startPoint);

        for (int i = 0; i < cpsAmount + 1; i++)
        {
            bool done = makeNextStep(cps);
            if (done)
            {
                break;
            }
        }

        finalConnectToSPline(cps);

        smoothSpline(cps);

        //cps.RemoveAt(cps.Count - 1);








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

    private void finalConnectToSPline(List<TSConPoint> cps)
    {
        TSConPoint curPoint = cps[cps.Count - 1];

        List<Vector3> circlePoints = new List<Vector3>();

        int multiAngle = 0;
        while (multiAngle < maxAngle)
        {
            multiAngle += circleStepAngle;
        }
        multiAngle -= circleStepAngle;

        int debugCounter = 0;

        float closestOnSplineDistance = float.MaxValue;
        int closestOnSplineCircleIndex = -1;
        float closestSplineY = -1f;
        for (int angleUp = -multiAngle; angleUp < maxAngle; angleUp += circleStepAngle)
        {
            Vector3 circlePoint = new Vector3(curPoint.pos.x, 10000f, curPoint.pos.z);
            circlePoint += Quaternion.Euler(0f, angleUp, 0f) * (curPoint.DirVec.normalized * cpDistance * 1.3f);


            RaycastHit[] hits = Physics.RaycastAll(new Ray(circlePoint, Vector3.down), 10000f);
            for (int k = 0; k < hits.Length; k++)
            {
                if (hits[k].transform.name.Contains("Terrain"))
                {
                    circlePoint = hits[k].point;
                    break;
                }
            }

            if (isInsideGlobalBorders(circlePoint)/* && Mathf.Abs(circlePoint.y - curPoint.pos.y) <= maxHeightDiffPerCP*/)
            {
                circlePoints.Add(circlePoint);

                CurveSample closest = toSpline.GetProjectionSample(new Vector2(circlePoint.x, circlePoint.z));

                if (Vector3.Distance(closest.location, circlePoint) < closestOnSplineDistance)
                {
                    closestSplineY = closest.location.y;
                    closestOnSplineDistance = Vector3.Distance(closest.location, circlePoint);
                    closestOnSplineCircleIndex = circlePoints.Count - 1;
                }
            }
        }

        float minDistToNode = float.MaxValue;
        int nodeIndex = -1;
        for (int i = 0; i < toSpline.nodes.Count; i++)
        {
            if (Vector3.Distance(toSpline.nodes[i].Position, circlePoints[closestOnSplineCircleIndex]) < minDistToNode)
            {
                minDistToNode = Vector3.Distance(toSpline.nodes[i].Position, circlePoints[closestOnSplineCircleIndex]);
                nodeIndex = i;
            }
        }

        Vector3 dirForw = toSpline.nodes[nodeIndex].Direction;
        Vector3 dirBackw = (toSpline.nodes[nodeIndex].Direction - toSpline.nodes[nodeIndex].Position) * -1f + toSpline.nodes[nodeIndex].Position;

        Vector3 takeDir = dirForw;

        if (Vector3.Distance(dirForw, cps[cps.Count - 1].pos) > Vector3.Distance(dirBackw, cps[cps.Count - 1].pos))
        {
            takeDir = dirBackw;
        }


        TSConPoint endNode = new TSConPoint(toSpline.nodes[nodeIndex].Position, takeDir);
        cps.Add(endNode);
    }

    private bool makeNextStep(List<TSConPoint> cps)
    {
        TSConPoint curPoint = cps[cps.Count - 1];

        List<Vector3> circlePoints = new List<Vector3>();

        int multiAngle = 0;
        while (multiAngle < maxAngle)
        {
            multiAngle += circleStepAngle;
        }
        multiAngle -= circleStepAngle;

        int debugCounter = 0;

        float closestOnSplineDistance = float.MaxValue;
        int closestOnSplineCircleIndex = -1;
        float closestSplineY = -1f;
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

            if (isInsideGlobalBorders(circlePoint) && Mathf.Abs(circlePoint.y - curPoint.pos.y) <= maxHeightDiffPerCP)
            {
                circlePoints.Add(circlePoint);

                CurveSample closest = toSpline.GetProjectionSample(new Vector2(circlePoint.x, circlePoint.z));

                if (Vector3.Distance(closest.location, circlePoint) < closestOnSplineDistance)
                {
                    closestSplineY = closest.location.y;
                    closestOnSplineDistance = Vector3.Distance(closest.location, circlePoint);
                    closestOnSplineCircleIndex = circlePoints.Count - 1;
                }
            }
        }




        float minHeightDiff = float.MaxValue;
        int minCircleIndex = closestOnSplineCircleIndex;
        /*for (int i = 0; i < circlePoints.Count; i++)
        {
            if (Mathf.Abs(circlePoints[i].y - heightTendency) < minHeightDiff)
            {
                minHeightDiff = Mathf.Abs(circlePoints[i].y - heightTendency);
                minCircleIndex = i;
            }
        }*/


        if (minCircleIndex == -1)
        {
            return true;
        }

        Vector3 dirVec = circlePoints[minCircleIndex] - curPoint.pos;
        dirVec.y = 0f;
        Vector3 dir = dirVec + circlePoints[minCircleIndex];
        //dir.y = 0f;
        //dir.Normalize();
        TSConPoint nextPoint = new TSConPoint(circlePoints[minCircleIndex], dir);
        cps.Add(nextPoint);

        if (closestOnSplineDistance <= minDistanceToTargetSpline && Mathf.Abs(nextPoint.pos.y - closestSplineY) <= maxHeightDiffPerCP)
        {
            return true;
        }
        return false;
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
