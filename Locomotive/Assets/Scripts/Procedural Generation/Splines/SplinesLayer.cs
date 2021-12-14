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
    [SerializeField]
    private float circleRandHeightInfluence = 0.8f;

    [Space]

    [SerializeField]
    private bool useEndSpline = false;

    [Space]

    [Header("References")]
    [SerializeField]
    private Spline toAdjustSpline = null;
    [SerializeField]
    private Spline startSpline = null;
    [SerializeField]
    private bool startAtBeginning = false;
    [SerializeField]
    private Spline endSpline = null;
    [SerializeField]
    private bool endAtBeginning = false;

    [Space]

    [SerializeField]
    private Transform startPositionTrans = null;
    [SerializeField]
    private Vector2 startDirection = Vector2.one;

    [Space]

    [Header("Debug")]
    [SerializeField]
    private Transform[] circlePosDebug;

    private float fadingHeightTend = 0f;

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
        List<TSConPoint> cps = new List<TSConPoint>();
        
        

        if (useEndSpline)
        {
            Vector3 startPos = startSpline.nodes[0].Position;
            Vector3 startDir = (startSpline.nodes[0].Direction - startSpline.nodes[0].Position) * -1f + startSpline.nodes[0].Position;
            if (!startAtBeginning)
            {
                startPos = startSpline.nodes[startSpline.nodes.Count - 1].Position;
                startDir = startSpline.nodes[startSpline.nodes.Count - 1].Direction;
            }

            TSConPoint startPoint = new TSConPoint(startPos, startDir);
            cps.Add(startPoint);
        }
        else
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
            cps.Add(startPoint);
        }

        for (int i = 0; i < cpsAmount + 1; i++)
        {
            makeNextStep(cps, true);
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

    private void makeNextStep(List<TSConPoint> cps, bool targetEndSpline)
    {
        TSConPoint curPoint = cps[cps.Count - 1];

        List<Vector3> circlePoints = new List<Vector3>();

        int multiAngle = 0;
        while (multiAngle < maxAngle)
        {
            multiAngle += circleStepAngle;
        }
        multiAngle -= circleStepAngle;



        if (useEndSpline == false)
        {
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

            //heightTendency = Mathf.Clamp(heightTendency, curPoint.pos.y - maxHeightDiffPerCP, curPoint.pos.y + maxHeightDiffPerCP);




            // Random circle point for height
            int randCircleIndex = Random.Range(0, circlePoints.Count);
            float circleHeightTend = circlePoints[randCircleIndex].y;
            circleHeightTend = Mathf.Clamp((circleHeightTend - curPoint.pos.y) / maxHeightDiffPerCP, -1f, 1f);
            fadingHeightTend += circleHeightTend * circleRandHeightInfluence;
            fadingHeightTend = Mathf.Clamp(fadingHeightTend, -1f, 1f);

            heightTendency += fadingHeightTend * maxHeightDiffPerCP;
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
        else
        {
            Vector3 targetPos = endSpline.nodes[0].Position;
            Vector3 startPos = startSpline.nodes[0].Position;
            if (targetEndSpline)
            {
                if (endAtBeginning == false)
                {
                    targetPos = endSpline.nodes[endSpline.nodes.Count - 1].Position;
                }

                if (startAtBeginning == false)
                {
                    startPos = startSpline.nodes[startSpline.nodes.Count - 1].Position;
                }
            }
            else
            {
                targetPos = startSpline.nodes[0].Position;
                startPos = endSpline.nodes[0].Position;
                if (startAtBeginning == false)
                {
                    targetPos = startSpline.nodes[startSpline.nodes.Count - 1].Position;
                }

                if (endAtBeginning == false)
                {
                    startPos = endSpline.nodes[endSpline.nodes.Count - 1].Position;
                }
            }

            float distanceStart = Vector3.Distance(startPos, cps[cps.Count - 1].pos);
            float distanceTarget = Vector3.Distance(targetPos, cps[cps.Count - 1].pos);
            float lerpSToTarget = (distanceStart) / (distanceStart + distanceTarget);

            float weightHeight = lerpSToTarget;
            float weightDirection = 1f - lerpSToTarget;





            
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

                if (isInsideGlobalBorders(circlePoint))
                {
                    circlePoints.Add(circlePoint);
                }
            }




            // Throw away all circle points, which have too much slope
            // Keep at least one circle points though
            while (circlePoints.Count > 0)
            {
                float maxHeightDiff = 0f;
                int maxIndex = -1;
                for (int i = 0; i < circlePoints.Count; i++)
                {
                    if (Mathf.Abs(circlePoints[i].y - curPoint.pos.y) > maxHeightDiff)
                    {
                        maxHeightDiff = Mathf.Abs(circlePoints[i].y - curPoint.pos.y);
                        maxIndex = i;
                    }
                }

                if (maxHeightDiff <= maxHeightDiffPerCP)
                {
                    break;
                }
                else
                {
                    circlePoints.RemoveAt(maxIndex);
                }
            }
            for (int i = 0; i < circlePoints.Count; i++)
            {
                circlePoints[i] = new Vector3(circlePoints[i].x, Mathf.Clamp(circlePoints[i].y, curPoint.pos.y - maxHeightDiffPerCP, curPoint.pos.y + maxHeightDiffPerCP), circlePoints[i].z);
            }




            List<float> toTargetDistanceReduction = new List<float>();
            float maxDistanceImprovement = 0f;
            for (int i = 0; i < circlePoints.Count; i++)
            {
                toTargetDistanceReduction.Add(Vector3.Distance(curPoint.pos, targetPos) - Vector3.Distance(circlePoints[i], targetPos));
                if (Mathf.Abs(toTargetDistanceReduction[toTargetDistanceReduction.Count - 1]) > maxDistanceImprovement)
                {
                    maxDistanceImprovement = Mathf.Abs(toTargetDistanceReduction[toTargetDistanceReduction.Count - 1]);
                }
            }

            List<float> directionImprovements = new List<float>();
            for (int i = 0; i < circlePoints.Count; i++)
            {
                directionImprovements.Add(toTargetDistanceReduction[i] / maxDistanceImprovement);
            }







            List<float> heightsImprovements = new List<float>();
            for (int i = 0; i < circlePoints.Count; i++)
            {
                float heightDiffNow = Mathf.Abs(targetPos.y - circlePoints[i].y);
                float heightDiffBefore = Mathf.Abs(targetPos.y - curPoint.pos.y);

                heightsImprovements.Add((heightDiffBefore - heightDiffNow) / maxHeightDiffPerCP);
            }


            float bestScore = float.MinValue;
            int bestIndex = -1;

            for (int i = 0; i < circlePoints.Count; i++)
            {
                float score = directionImprovements[i] * (1f - lerpSToTarget) + heightsImprovements[i] * lerpSToTarget;

                if (score > bestScore)
                {
                    bestIndex = i;
                    bestScore = score;
                }
            }






            if (bestIndex == -1)
            {
                Debug.LogError("Best index is -1");
            }


            Vector3 dirVec = circlePoints[bestIndex] - curPoint.pos;
            dirVec.y = 0f;
            Vector3 dir = dirVec + circlePoints[bestIndex];
            //dir.y = 0f;
            //dir.Normalize();
            TSConPoint nextPoint = new TSConPoint(circlePoints[bestIndex], dir);
            cps.Add(nextPoint);
        }

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
