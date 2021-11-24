using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TerrainLevelerSpline : MonoBehaviour
{
    [SerializeField]
    private bool calculate = false;
    [SerializeField]
    private bool resetTerrain = false;

    [Space]

    [Header("References")]
    [SerializeField]
    private Terrain terrain;
    [SerializeField]
    private Spline spline;

    [Space]

    [Header("Settings")]
    [SerializeField]
    private int stepsPerSpline = 30;
    [SerializeField]
    private float widthExtendOutside = 5f;
    [SerializeField]
    private int stepsOutside = 30;
    [SerializeField]
    private int stepsInsideTrack = 50;
    [SerializeField]
    private float shapeXOutside = 1f;
    [SerializeField]
    private float shapeXInside = 0.9f;
    [SerializeField]
    private float shapeXHeight = 0.03f;
    [SerializeField]
    private float epsilon = 0.04f;
    [SerializeField]
    private float epsilonTiltedFactor = 0.2f;
    [SerializeField]
    private AnimationCurve weightCurve;
    [SerializeField]
    private float positiveYOffset = 0.03f;
    [SerializeField]
    private TerrainLevelerExclude[] excludes = new TerrainLevelerExclude[0];

    [SerializeField]
    private GameObject cubeDebug;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private Vector3 terrainMin;
    private Vector3 terrainMax;

    private int[,] samplesAmount;
    private float[,] terrainHeights;
    private float[,] originTerrainHeights;
    private float[,] weights;
    float xStretchFactor;
    float yStretchFactor;
    float zStretchFactor;

    // Update is called once per frame
    void Update()
    {
        if (resetTerrain)
        {
            resetTerrain = false;

            terrain.terrainData.SetHeights(0, 0, originTerrainHeights);

        }

        if (calculate)
        {
            calculate = false;

            LevelTerrain(spline, terrain);
        }
    }

    public float[,] LevelTerrain(Spline spline, Terrain terrain)
    {
        //terrain.transform.position = Vector3.zero;

        int nodeCount = spline.nodes.Count;
        float splineScale = spline.transform.localScale.x;

        Debug.Log("HeightMapRes: " + terrain.terrainData.heightmapResolution.ToString());
        Debug.Log("Size: " + terrain.terrainData.size.ToString());

        terrainMin = terrain.transform.position;
        terrainMax = terrain.transform.position + terrain.terrainData.size;

        xStretchFactor = terrain.terrainData.heightmapResolution / (terrain.terrainData.size.x);
        zStretchFactor = terrain.terrainData.heightmapResolution / (terrain.terrainData.size.z);
        yStretchFactor = 1f / (terrain.terrainData.size.y);

        terrainHeights = new float[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];
        weights = new float[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];
        samplesAmount = new int[terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution];
        for (int x = 0; x < terrainHeights.GetLength(0); x++)
        {
            for (int y = 0; y < terrainHeights.GetLength(1); y++)
            {
                terrainHeights[x, y] = 1000000000f;
                weights[x, y] = 0f;
                samplesAmount[x, y] = 0;
            }
        }


        for (int node = 0; node < nodeCount; node++)
        {
            for (int i = 0; i < stepsPerSpline; i++)
            {
                float s = ((float)i) / stepsPerSpline;

                bool excluded = false;
                for (int j = 0; j < excludes.Length; j++)
                {
                    if (((excludes[j].nodeBegin <= node && excludes[j].begin <= s) || (excludes[j].nodeBegin < node))
                        && ((excludes[j].nodeEnd >= node && excludes[j].end >= s) || (excludes[j].nodeEnd > node)))
                    {
                        excluded = true;
                        break;
                    }
                }

                if (!excluded)
                {
                    Vector3 splinePos = spline.GetCurve(Mathf.Clamp(s + node, 0f, nodeCount - 1)).GetSample(s).location * splineScale + spline.transform.position;
                    Vector3 vecUp = spline.GetCurve(Mathf.Clamp(s + node, 0f, nodeCount - 1)).GetSample(s).up;

                    Vector3 toLeft = Vector3.Cross(spline.GetCurve(Mathf.Clamp(s + node, 0f, nodeCount - 1)).GetSample(s).tangent, spline.GetCurve(Mathf.Clamp(s + node, 0f, nodeCount - 1)).GetSample(s).up).normalized;
                    Vector3 toRight = -Vector3.Cross(spline.GetCurve(Mathf.Clamp(s + node, 0f, nodeCount - 1)).GetSample(s).tangent, spline.GetCurve(Mathf.Clamp(s + node, 0f, nodeCount - 1)).GetSample(s).up).normalized;

                    Vector3 splineOutLeft = splinePos + toLeft * splineScale;
                    Vector3 splineOutRight = splinePos + toRight * splineScale;


                    float rightLeftDistance = Vector3.Distance(splineOutLeft, splineOutRight);
                    for (int j = 0; j <= stepsInsideTrack; j++)
                    {
                        float sIn = (j / ((float)stepsInsideTrack));
                        Vector3 destVect = splineOutLeft + toRight * rightLeftDistance * sIn;

                        float offsetDown = epsilon + epsilonTiltedFactor * (1f - Mathf.Cos(Vector3.Angle(Vector3.up, vecUp)));

                        setTerrainHeight(destVect.x - terrain.transform.position.x, destVect.z - terrain.transform.position.z, destVect.y - offsetDown, 1f);
                    }


                    for (int j = 0; j < stepsOutside; j++)
                    {
                        float weight = 1f - (j / ((float)stepsOutside));
                        float distanceOut = widthExtendOutside * (1f - weight);

                        Vector3 destVectLeft = splineOutLeft + toLeft * distanceOut;
                        Vector3 destVectRight = splineOutRight + toRight * distanceOut;

                        setTerrainHeight(destVectLeft.x - terrain.transform.position.x, destVectLeft.z - terrain.transform.position.z, destVectLeft.y, weight);
                        setTerrainHeight(destVectRight.x - terrain.transform.position.x, destVectRight.z - terrain.transform.position.z, destVectRight.y, weight);
                    }
                    //GameObject go = Instantiate(cubeDebug, transform);
                    //go.transform.position = splineOutLeft;
                    //GameObject go2 = Instantiate(cubeDebug, transform);
                    //go2.transform.position = splinePos;
                }

            }
        }


        float[,] deltaHeights = applyTerrain(terrain);
        return deltaHeights;
    }

    private float[,] applyTerrain(Terrain terrain)
    {
        float[,] deltaHeights = new float[terrainHeights.GetLength(0), terrainHeights.GetLength(1)];

        float[,] finalHeights = new float[terrainHeights.GetLength(0), terrainHeights.GetLength(1)];
        originTerrainHeights = terrain.terrainData.GetHeights(0, 0, finalHeights.GetLength(0), finalHeights.GetLength(1));


        for (int x = 0; x < terrainHeights.GetLength(0); x++)
        {
            for (int y = 0; y < terrainHeights.GetLength(1); y++)
            {
                finalHeights[y, x] = originTerrainHeights[y, x] * (1f - weights[x, y]) + terrainHeights[x, y] * weights[x, y];

                if (weights[x, y] == 0f)
                {
                    deltaHeights[y, x] = -1f;
                }
                else
                {
                    deltaHeights[y, x] = originTerrainHeights[y, x];
                }
            }
        }

        terrain.terrainData.SetHeights(0, 0, finalHeights);

        return deltaHeights;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x">X-Coordinate in world coordinates</param>
    /// <param name="y">Y-Coordinate in world coordinates</param>
    /// <param name="height">Height in world coordinates</param>
    private void setTerrainHeight(float x, float z, float height, float weight = 1f)
    {
        weight = weightCurve.Evaluate(weight);
        height += positiveYOffset;

        int arrayX = (int)(x * xStretchFactor + 0.5f);
        int arrayZ = (int)(z * zStretchFactor + 0.5f);

        if (arrayX >= 0 && arrayX < terrainHeights.GetLength(0) && arrayZ >= 0 && arrayZ < terrainHeights.GetLength(1))
        {
            if (weights[arrayX, arrayZ] < weight)
            {
                float oldTerrainHeight = terrainHeights[arrayX, arrayZ];
                float oldWeight = weights[arrayX, arrayZ];
                int samplesYet = samplesAmount[arrayX, arrayZ];

                terrainHeights[arrayX, arrayZ] = Mathf.Clamp(height * yStretchFactor, 0f, 1f) * (1f / (samplesYet + 1f)) + oldTerrainHeight * (samplesYet / (samplesYet + 1f));
                weights[arrayX, arrayZ] = weight * (1f / (samplesYet + 1f)) + oldWeight * (samplesYet / (samplesYet + 1f));

                samplesAmount[arrayX, arrayZ] = samplesYet + 1;
            }
            else if (weights[arrayX, arrayZ] == weight && weight == 1f)
            {
                if (height + 0.1f < terrainHeights[arrayX, arrayZ])
                {
                    float oldTerrainHeight = terrainHeights[arrayX, arrayZ];
                    float oldWeight = weights[arrayX, arrayZ];
                    int samplesYet = samplesAmount[arrayX, arrayZ];

                    terrainHeights[arrayX, arrayZ] = Mathf.Clamp(height * yStretchFactor, 0f, 1f) * (1f / (samplesYet + 1f)) + oldTerrainHeight * (samplesYet / (samplesYet + 1f));
                    weights[arrayX, arrayZ] = weight * (1f / (samplesYet + 1f)) + oldWeight * (samplesYet / (samplesYet + 1f));

                    samplesAmount[arrayX, arrayZ] = samplesYet + 1;
                }
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < excludes.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(spline.GetCurve(excludes[i].begin + excludes[i].nodeBegin).GetSample(excludes[i].begin).location + GlobalOffsetManager.Inst.GlobalOffset, 20f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spline.GetCurve(excludes[i].end + excludes[i].nodeEnd).GetSample(excludes[i].end).location + GlobalOffsetManager.Inst.GlobalOffset, 20f);
        }
    }
}


[Serializable]
public class TerrainLevelerExclude
{
    public int nodeBegin;
    public int nodeEnd;
    public float begin;
    public float end;
}