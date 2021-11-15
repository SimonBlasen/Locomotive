using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class TrainstationsConnector : MonoBehaviour
{
    [Header("Run")]
    [SerializeField]
    private bool generateSpline = false;

    [Space]

    [Header("References")]
    [SerializeField]
    private float slopeAngleLimit = 20f;
    [SerializeField]
    private float maxSlopeAngleUntilCatch = 20f;
    [SerializeField]
    private float slopeImportance = 20f;
    [SerializeField]
    private float stepDistance = 100f;
    [SerializeField]
    private float smoothYHeightsSelfWeight = 0.5f;
    [SerializeField]
    private int smoothYHeightsSteps = 1;

    // Between 0 and 1. If is equal 1, then offset target is always the same distance away from train station, as current pos is away from train station
    // If is equal to 0, the target is always equal the train station
    [SerializeField]
    private float strengthOfTargetDirection = 0.75f;

    [SerializeField]
    private int maxAnglePerStep = 35;
    [SerializeField]
    private int angleStepSize = 3;
    [SerializeField]
    private float splineDirStrengthRatio = 0.3f;
    [SerializeField]
    private float howCloseHasNewDirBe = 0.8f;
    [SerializeField]
    private int maxSplineNodes = 10;
    [SerializeField]
    private float smoothDirFactor = 0.5f;

    [Space]

    [Header("References")]
    [SerializeField]
    private Spline toAdjustSpline = null;

    [Space]

    [SerializeField]
    private Spline trainStationA = null;
    [SerializeField]
    private bool trainStationABeginSpline = false;
    [SerializeField]
    private Spline trainStationB = null;
    [SerializeField]
    private bool trainStationBBeginSpline = false;



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
        TSConPoint finalTarget = new TSConPoint(trainStationBBeginSpline ? trainStationB.nodes[0].Position : trainStationB.nodes[trainStationB.nodes.Count - 1].Position,
                                             trainStationBBeginSpline ? trainStationB.nodes[0].Direction : trainStationB.nodes[trainStationB.nodes.Count - 1].Position + (trainStationB.nodes[trainStationB.nodes.Count - 1].Position - trainStationB.nodes[trainStationB.nodes.Count - 1].Direction));

        List<TSConPoint> points = new List<TSConPoint>();

        TSConPoint curPoint = new TSConPoint(trainStationABeginSpline ? trainStationA.nodes[0].Position : trainStationA.nodes[trainStationA.nodes.Count - 1].Position,
                                             trainStationABeginSpline ? trainStationA.nodes[0].Position + (trainStationA.nodes[0].Position - trainStationA.nodes[0].Direction) : trainStationA.nodes[trainStationA.nodes.Count - 1].Direction);

        points.Add(curPoint);


        while (points.Count < maxSplineNodes)
        {
            float distanceToFinalTarget = Vector3.Distance(curPoint.pos, finalTarget.pos);

            Vector3 curOffsetedTarget = finalTarget.pos + Mathf.Min(5f * stepDistance, distanceToFinalTarget * strengthOfTargetDirection) * -1f * finalTarget.DirVec.normalized;

            Vector2 vec2FromCurPosToOffsetTarget = new Vector2(curOffsetedTarget.x, curOffsetedTarget.z) - curPoint.Pos2;

            Vector2 desiredDirVec = ((curPoint.DirVec2.normalized + vec2FromCurPosToOffsetTarget.normalized) * 0.5f).normalized;

            float remainingHeightDiff = finalTarget.pos.y - curPoint.pos.y;

            float bestVal = float.MaxValue;
            float bestValHeightOnly = float.MaxValue;
            float bestAngle = 0f;
            Vector3 nextPointVec = Vector3.zero;
            Vector3 nextPointVecHeightOnly = Vector3.zero;
            for (int angle = 0; angle < maxAnglePerStep; angle += angleStepSize)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (angle != 0 || i == 0)
                    {
                        int actualAngle = i == 0 ? angle : -angle;

                        Vector2 nextCP2 = Rotate(desiredDirVec * stepDistance, actualAngle) + curPoint.Pos2;

                        float weightAngle = Mathf.Sin((angle * Mathf.PI * 90f) / (180f * maxAnglePerStep));

                        Vector3 hitPoint = Vector3.zero;
                        RaycastHit[] hits = Physics.RaycastAll(new Ray(new Vector3(nextCP2.x, 10000f, nextCP2.y), Vector3.down), 10000f);
                        for (int k = 0; k < hits.Length; k++)
                        {
                            if (hits[k].transform.name.Contains("Terrain"))
                            {
                                hitPoint = hits[k].point;
                            }
                        }

                        if (hitPoint == Vector3.zero)
                        {
                            Debug.LogError("Raycast not hit terrain");
                            return;
                        }


                        float angleHeight = Mathf.Atan((hitPoint.y - curPoint.pos.y) / (Vector2.Distance(curPoint.Pos2, nextCP2)));

                        angleHeight = Mathf.Min(slopeAngleLimit * Mathf.Deg2Rad, Mathf.Abs(angleHeight));
                        //angleHeight = Mathf.Abs(angleHeight);
                        float weightHeight = Mathf.Sin(Mathf.Abs(angleHeight) * 90f / slopeAngleLimit) * slopeImportance;

                        /*float weightHeightDifference = 0f;
                        if (angleHeight < slopeAngleLimit)
                        {
                            weightHeight = 0f;
                            weightHeightDifference = Mathf.Sign(angleHeight) == Mathf.Sign(remainingHeightDiff) ? 1f : 0f;
                        }*/

                        float weight = weightAngle + weightHeight;

                        if (weight < bestVal && angleHeight < maxSlopeAngleUntilCatch * Mathf.Deg2Rad)
                        {
                            bestVal = weight;
                            bestAngle = actualAngle;
                            nextPointVec = hitPoint;
                        }
                    }
                }
            }

            float diffAngleDirCurPos = Vector2.SignedAngle(curPoint.DirVec2, new Vector2(nextPointVec.x, nextPointVec.z) - curPoint.Pos2);

            Vector2 newDir2D = (new Vector2(nextPointVec.x, nextPointVec.z) - curPoint.Pos2);
            newDir2D = Rotate(newDir2D, diffAngleDirCurPos * howCloseHasNewDirBe);

            TSConPoint newPoint = new TSConPoint(nextPointVec, nextPointVec + (new Vector3(newDir2D.x, 0f, newDir2D.y)).normalized * splineDirStrengthRatio * Vector3.Distance(nextPointVec, curPoint.pos));

            points.Add(newPoint);

            curPoint = newPoint;
        }


        while (toAdjustSpline.nodes.Count > 2)
        {
            toAdjustSpline.RemoveNode(toAdjustSpline.nodes[0]);
        }



        toAdjustSpline.nodes[0].Position = points[0].pos;
        toAdjustSpline.nodes[0].Direction = points[0].dir;
        toAdjustSpline.nodes[1].Position = points[1].pos;
        toAdjustSpline.nodes[1].Direction = points[1].dir;
        for (int i = 2; i < points.Count; i++)
        {
            toAdjustSpline.AddNode(new SplineNode(points[i].pos, points[i].dir));
        }

        for (int steps = 0; steps < smoothYHeightsSteps; steps++)
        {
            for (int i = 1; i < toAdjustSpline.nodes.Count - 1; i++)
            {
                float newHeight = (toAdjustSpline.nodes[i - 1].Position.y + toAdjustSpline.nodes[i + 1].Position.y) * 0.5f;
                newHeight = (newHeight * (1f - smoothYHeightsSelfWeight)) + (toAdjustSpline.nodes[i].Position.y * smoothYHeightsSelfWeight);

                toAdjustSpline.nodes[i].Position = new Vector3(toAdjustSpline.nodes[i].Position.x, newHeight, toAdjustSpline.nodes[i].Position.z);
            }
        }


        // Smooth directions
        for (int i = 1; i < toAdjustSpline.nodes.Count - 1; i++)
        {
            Vector3 dirFromTo = toAdjustSpline.nodes[i + 1].Position - toAdjustSpline.nodes[i - 1].Position;
            Vector2 smoothDir = (new Vector2(dirFromTo.x, dirFromTo.z)).normalized;

            Vector3 curDir3D = toAdjustSpline.nodes[i].Direction - toAdjustSpline.nodes[i].Position;
            Vector2 curDir = (new Vector2(curDir3D.x, curDir3D.z)).normalized;

            Vector2 smoothedDir = (smoothDirFactor * smoothDir + (1f - smoothDirFactor) * curDir).normalized;


            toAdjustSpline.nodes[i].Direction = toAdjustSpline.nodes[i].Position + (new Vector3(smoothedDir.x, 0f, smoothedDir.y)) * stepDistance * 0.3f;
        }


        for (int i = 1; i < toAdjustSpline.nodes.Count - 1; i++)
        {
            float targetSlope = toAdjustSpline.nodes[i + 1].Position.y - toAdjustSpline.nodes[i - 1].Position.y;
            targetSlope /= Vector2.Distance(new Vector2(toAdjustSpline.nodes[i + 1].Position.x, toAdjustSpline.nodes[i + 1].Position.z),
                new Vector2(toAdjustSpline.nodes[i - 1].Position.x, toAdjustSpline.nodes[i - 1].Position.z));

            float dirY = Vector2.Distance(new Vector2(toAdjustSpline.nodes[i].Direction.x, toAdjustSpline.nodes[i].Direction.z),
                                    new Vector2(toAdjustSpline.nodes[i].Position.x, toAdjustSpline.nodes[i].Position.z)) * targetSlope;

            toAdjustSpline.nodes[i].Direction = new Vector3(toAdjustSpline.nodes[i].Direction.x, toAdjustSpline.nodes[i].Position.y + dirY, toAdjustSpline.nodes[i].Direction.z);
        }

        toAdjustSpline.RefreshCurves();
    }

    public static Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }
}


public class TSConPoint
{
    public Vector3 pos;
    public Vector3 dir;

    public Vector2 Pos2
    {
        get
        {
            return new Vector2(pos.x, pos.z);
        }
    }

    public Vector3 DirVec
    {
        get
        {
            return dir - pos;
        }
    }

    public Vector2 DirVec2
    {
        get
        {
            return new Vector2(DirVec.x, DirVec.z);
        }
    }

    public TSConPoint()
    {
        pos = Vector3.zero;
        dir = Vector3.zero;
    }

    public TSConPoint(Vector3 pos, Vector3 dir)
    {
        this.pos = pos;
        this.dir = dir;
    }
}