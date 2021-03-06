using noise.module;
using Sappph;
using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobProcGen : ThreadedJob
{
    public ProcTerrainAccessor terrainAccessor;
    public long seed = 0;
    public Vector2Int startPos;
    public Vector2Int endPos;
    public int[] onlyLowResSteps = null;


    public Vector2Int terrainIndex;
    public bool useTerrainIndices = false;

    public bool onlyMakeOneAreaType = false;

    public ProcTerrainGen procTerrainGen;

    private static PerlinNoise perlin = null;
    private static Billow billow = null;
    private static RidgedMulti ridgedMulti = null;
    private static ScaleBias scaleBias = null;
    private static Select select = null;
    private static Perlin perlinLib = null;

    private static void initNoises()
    {
        if (perlin == null)
        {
            perlin = new PerlinNoise(0);

            billow = new Billow();
            billow.Frequency = 1.0;
            billow.Lacunarity = 2.0;
            billow.OctaveCount = 6;
            billow.NoiseQuality = noise.NoiseQuality.QUALITY_STD;
            billow.Persistence = 0.5;
            billow.Seed = (int)0;

            ridgedMulti = new RidgedMulti();
            ridgedMulti.Seed = (int)0;
            ridgedMulti.Frequency = 1.0;
            ridgedMulti.Lacunarity = 2.0;
            ridgedMulti.OctaveCount = 6;
            ridgedMulti.NoiseQuality = noise.NoiseQuality.QUALITY_STD;
            ridgedMulti.CalculateSpectralWeights();
            scaleBias = new ScaleBias();
            select = new Select();
            perlinLib = new Perlin();
            perlinLib.Seed = (int)0;
        }
    }


    protected override void ThreadFunction()
    {
        initNoises();
        /*perlin = new PerlinNoise(seed);

        billow = new Billow();
        billow.Frequency = 1.0;
        billow.Lacunarity = 2.0;
        billow.OctaveCount = 6;
        billow.NoiseQuality = noise.NoiseQuality.QUALITY_STD;
        billow.Persistence = 0.5;
        billow.Seed = (int)seed;

        ridgedMulti = new RidgedMulti();
        ridgedMulti.Seed = (int)seed;
        ridgedMulti.Frequency = 1.0;
        ridgedMulti.Lacunarity = 2.0;
        ridgedMulti.OctaveCount = 6;
        ridgedMulti.NoiseQuality = noise.NoiseQuality.QUALITY_STD;
        ridgedMulti.CalculateSpectralWeights();
        scaleBias = new ScaleBias();
        select = new Select();
        perlinLib = new Perlin();
        perlinLib.Seed = (int)seed;*/

        float stepSize = terrainAccessor.TerrainsSpacing / ((float)4096f);

        if (!useTerrainIndices)
        {
            for (float x = startPos.x; x < endPos.x; x += 1f)
            {
                Progress = (x - startPos.x) / ((float)(endPos.x - startPos.x));

                for (float y = startPos.y; y < endPos.y; y += 1f)
                {
                    if (true)//onlyLowResSteps == null || onlyLowResSteps.Length == 0
                             //|| (Utils.IsInIntArray(onlyLowResSteps, x) && Utils.IsInIntArray(onlyLowResSteps, y)))
                    {


                        float height = computeHeightAt(new Vector2(x, y), perlin, ridgedMulti, billow, perlinLib); 

                        terrainAccessor.SetHeight(new Vector2(x, y), height);
                    }
                }
            }
        }
        else
        {
            for (int x = 0; x < 4097; x++)
            {
                Progress = (x / ((float)4096));

                for (int y = 0; y < 4097; y++)
                {
                    Vector2 floatPos = new Vector2(x * stepSize, y * stepSize) + terrainIndex * terrainAccessor.TerrainsSpacing;

                    float height = computeHeightAt(floatPos, perlin, ridgedMulti, billow, perlinLib);

                    terrainAccessor.SetHeight(terrainIndex, new Vector2Int(x, y), height);
                }
            }
        }

    }

    private float computeHeightAt(Vector2 pos, PerlinNoise perlin, RidgedMulti ridgedMulti, Billow billow, Perlin perlinLib)
    {
        float height = 0f;
        float[] areaWeights = calcAreaWeights(procTerrainGen, pos.x, pos.y);




        for (int i = 0; i < areaWeights.Length; i++)
        {
            bool doAddHeight = true;
            if (onlyMakeOneAreaType)
            {
                doAddHeight = (i == (int)procTerrainGen.areaPreview);
                areaWeights[i] = 1f;
            }

            if (doAddHeight)
            {
                if (i == (int)ProcAreaType.MOUNTAINS)
                {
                    height += mountain_height(perlin, ridgedMulti, billow, pos.x, pos.y) * areaWeights[i];
                }
                else if (i == (int)ProcAreaType.PLANE)
                {
                    height += planes_height(procTerrainGen, perlinLib, perlin, billow, ridgedMulti, pos.x, pos.y) * areaWeights[i];
                }
                else if (i == (int)ProcAreaType.FORREST)
                {
                    height += forrest_height(procTerrainGen, perlinLib, perlin, billow, ridgedMulti, pos.x, pos.y) * areaWeights[i];
                }
                else if (i == (int)ProcAreaType.SNOW_MOUNTAINS)
                {
                    height += snow_mountain_height(pos.x, pos.y, procTerrainGen) * areaWeights[i];
                }
                else if (i == (int)ProcAreaType.DESERT)
                {
                    height += desert_height(procTerrainGen, perlinLib, perlin, billow, ridgedMulti, pos.x, pos.y) * areaWeights[i];
                }
            }

        }

        return height;
    }

    public static float forrest_height(ProcTerrainGen procTerrainGen, Perlin perlinLib, PerlinNoise perlin, Billow billow, RidgedMulti ridgedMulti, float x, float y)
    {
        perlinLib.Frequency = 1.0;
        perlinLib.Lacunarity = 2.0;
        perlinLib.Persistence = 0.5;
        perlinLib.OctaveCount = 3;
        perlinLib.NoiseQuality = noise.NoiseQuality.QUALITY_STD;


        float height = 0f;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency, y * procTerrainGen.perlinFrequency) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 2f, y * procTerrainGen.perlinFrequency * 2f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.5f;

        height += (perlin.noise2(x * procTerrainGen.forrestPerlinFreq * 4f, y * procTerrainGen.forrestPerlinFreq * 4f) * 0.5f + 0.5f) * procTerrainGen.forrestPerlinAmpl * 0.25f;
        height += (perlin.noise2(x * procTerrainGen.forrestPerlinFreq * 8f, y * procTerrainGen.forrestPerlinFreq * 8f) * 0.5f + 0.5f) * procTerrainGen.forrestPerlinAmpl * 0.125f;
        height += (perlin.noise2(x * procTerrainGen.forrestPerlinFreq * 16f, y * procTerrainGen.forrestPerlinFreq * 16f) * 0.5f + 0.5f) * procTerrainGen.forrestPerlinAmpl * 0.125f * 0.5f;

        //float mountain = perlin.noise2(x * procTerrainGen.mountainPerlinFrequency, y * procTerrainGen.mountainPerlinFrequency) * 0.5f + 0.5f;
        //mountain = mountain * mountain * mountain * mountain;
        //mountain *= procTerrainGen.mountainPerlinAmplitude;

        //height += mountain;


        // Low frequency stuff
        //height += ((float)perlinLib.GetValue(x * 0.00054987312, y * 0.00054987312, 0.0) * 0.4f + 0.5f) * 0.5f;


        // Rare spikes
        float spikes = ((float)perlinLib.GetValue(x * 0.0054987312, y * 0.0054987312, 0.0) * 0.4f + 0.5f) * 0.5f;
        float spikes2 = ((float)perlinLib.GetValue(x * 0.0064987312, y * 0.0064987312, 0.0) * 0.4f + 0.5f) * 0.5f;

        spikes = spikes * spikes2;

        spikes = (Mathf.Atan((spikes - procTerrainGen.aTanXOffset) * procTerrainGen.aTanX) * 0.3f + 0.5f) * procTerrainGen.aTanY;


        //height += spikes;





        // Low frequency stuff

        float lowFreq = ((float)ridgedMulti.GetValue(x * procTerrainGen.forrestRigFreq, y * procTerrainGen.forrestRigFreq, 0.0) * procTerrainGen.forrestRigAmpl + procTerrainGen.forrestRigOffset);
        lowFreq *= ((float)perlinLib.GetValue(x * procTerrainGen.forrestLowFreqPerlinFreq, y * procTerrainGen.forrestLowFreqPerlinFreq, 0.0) * procTerrainGen.forrestLowFreqPerlinAmpl + procTerrainGen.forrestLowFreqPerlinAmplOffset);


        height += lowFreq * procTerrainGen.forrestLowFreqInfluence;



        //height += ((float)ridgedMulti.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * procTerrainGen.ridgedMultiAmplitude;


        height = Mathf.Clamp(height, 0f, 1f); 







        return height;
    }

    public static float planes_height(ProcTerrainGen procTerrainGen, Perlin perlinLib, PerlinNoise perlin, Billow billow, RidgedMulti ridgedMulti, float x, float y)
    {
        perlinLib.Frequency = 1.0;
        perlinLib.Lacunarity = 2.0;
        perlinLib.Persistence = 0.5;
        perlinLib.OctaveCount = 3;
        perlinLib.NoiseQuality = noise.NoiseQuality.QUALITY_STD;


        float height = 0f;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency, y * procTerrainGen.perlinFrequency) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 2f, y * procTerrainGen.perlinFrequency * 2f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.5f;

        height += (perlin.noise2(x * procTerrainGen.planesPerlinFreq * 4f, y * procTerrainGen.planesPerlinFreq * 4f) * 0.5f + 0.5f) * procTerrainGen.planesPerlinAmpl * 0.25f;
        height += (perlin.noise2(x * procTerrainGen.planesPerlinFreq * 8f, y * procTerrainGen.planesPerlinFreq * 8f) * 0.5f + 0.5f) * procTerrainGen.planesPerlinAmpl * 0.125f;
        height += (perlin.noise2(x * procTerrainGen.planesPerlinFreq * 16f, y * procTerrainGen.planesPerlinFreq * 16f) * 0.5f + 0.5f) * procTerrainGen.planesPerlinAmpl * 0.125f * 0.5f;

        //float mountain = perlin.noise2(x * procTerrainGen.mountainPerlinFrequency, y * procTerrainGen.mountainPerlinFrequency) * 0.5f + 0.5f;
        //mountain = mountain * mountain * mountain * mountain;
        //mountain *= procTerrainGen.mountainPerlinAmplitude;

        //height += mountain;


        // Low frequency stuff
        //height += ((float)perlinLib.GetValue(x * 0.00054987312, y * 0.00054987312, 0.0) * 0.4f + 0.5f) * 0.5f;


        // Rare spikes
        float spikes = ((float)perlinLib.GetValue(x * 0.0054987312, y * 0.0054987312, 0.0) * 0.4f + 0.5f) * 0.5f;
        float spikes2 = ((float)perlinLib.GetValue(x * 0.0064987312, y * 0.0064987312, 0.0) * 0.4f + 0.5f) * 0.5f;

        spikes = spikes * spikes2;

        spikes = (Mathf.Atan((spikes - procTerrainGen.aTanXOffset) * procTerrainGen.aTanX) * 0.3f + 0.5f) * procTerrainGen.aTanY;


        //height += spikes;





        // Low frequency stuff

        float lowFreq = ((float)ridgedMulti.GetValue(x * procTerrainGen.planesRigFreq, y * procTerrainGen.planesRigFreq, 0.0) * procTerrainGen.planesRigAmpl + procTerrainGen.planesRigOffset);
        lowFreq *= ((float)perlinLib.GetValue(x * procTerrainGen.planesLowFreqPerlinFreq, y * procTerrainGen.planesLowFreqPerlinFreq, 0.0) * procTerrainGen.planesLowFreqPerlinAmpl + procTerrainGen.planesLowFreqPerlinAmplOffset);


        height += lowFreq * procTerrainGen.planesLowFreqInfluence;



        //height += ((float)ridgedMulti.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * procTerrainGen.ridgedMultiAmplitude;


        height = Mathf.Clamp(height, 0f, 1f);







        return height;
    }

    public static float desert_height(ProcTerrainGen procTerrainGen, Perlin perlinLib, PerlinNoise perlin, Billow billow, RidgedMulti ridgedMulti, float x, float y)
    {
        perlinLib.Frequency = 1.0;
        perlinLib.Lacunarity = 2.0;
        perlinLib.Persistence = 0.5;
        perlinLib.OctaveCount = 3;
        perlinLib.NoiseQuality = noise.NoiseQuality.QUALITY_STD;


        float height = 0f;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency, y * procTerrainGen.perlinFrequency) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 2f, y * procTerrainGen.perlinFrequency * 2f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.5f;

        height += (perlin.noise2(x * procTerrainGen.desertPerlinFreq * 4f, y * procTerrainGen.desertPerlinFreq * 4f) * 0.5f + 0.5f) * procTerrainGen.desertPerlinAmpl * 0.25f;
        height += (perlin.noise2(x * procTerrainGen.desertPerlinFreq * 8f, y * procTerrainGen.desertPerlinFreq * 8f) * 0.5f + 0.5f) * procTerrainGen.desertPerlinAmpl * 0.125f;
        height += (perlin.noise2(x * procTerrainGen.desertPerlinFreq * 16f, y * procTerrainGen.desertPerlinFreq * 16f) * 0.5f + 0.5f) * procTerrainGen.desertPerlinAmpl * 0.125f * 0.5f;

        //float mountain = perlin.noise2(x * procTerrainGen.mountainPerlinFrequency, y * procTerrainGen.mountainPerlinFrequency) * 0.5f + 0.5f;
        //mountain = mountain * mountain * mountain * mountain;
        //mountain *= procTerrainGen.mountainPerlinAmplitude;

        //height += mountain;


        // Low frequency stuff
        //height += ((float)perlinLib.GetValue(x * 0.00054987312, y * 0.00054987312, 0.0) * 0.4f + 0.5f) * 0.5f;


        // Rare spikes
        float spikes = ((float)perlinLib.GetValue(x * 0.0054987312, y * 0.0054987312, 0.0) * 0.4f + 0.5f) * 0.5f;
        float spikes2 = ((float)perlinLib.GetValue(x * 0.0064987312, y * 0.0064987312, 0.0) * 0.4f + 0.5f) * 0.5f;

        spikes = spikes * spikes2;

        spikes = (Mathf.Atan((spikes - procTerrainGen.aTanXOffset) * procTerrainGen.aTanX) * 0.3f + 0.5f) * procTerrainGen.aTanY;


        //height += spikes;





        // Low frequency stuff

        float lowFreq = ((float)ridgedMulti.GetValue(x * procTerrainGen.desertRigFreq, y * procTerrainGen.desertRigFreq, 0.0) * procTerrainGen.desertRigAmpl + procTerrainGen.desertRigOffset);
        lowFreq *= ((float)perlinLib.GetValue(x * procTerrainGen.desertLowFreqPerlinFreq, y * procTerrainGen.desertLowFreqPerlinFreq, 0.0) * procTerrainGen.desertLowFreqPerlinAmpl + procTerrainGen.desertLowFreqPerlinAmplOffset);


        height += lowFreq * procTerrainGen.desertLowFreqInfluence;



        //height += ((float)ridgedMulti.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * procTerrainGen.ridgedMultiAmplitude;


        height = Mathf.Clamp(height, 0f, 1f);







        return height;
    }


    public static float[] calcAreaWeights(ProcTerrainGen procTerrainGen, float x, float y)
    {
        int amountOfAreas = procTerrainGen.amountOfAreas;
        float[] areas = new float[amountOfAreas];
        float sum = 0f;
        for (int i = 0; i < areas.Length; i++)
        {
            areas[i] = 0f;
        }

        for (int i = 0; i < procTerrainGen.areaBorders.Length; i++)
        {
            areas[(int)procTerrainGen.areaBorders[i].areaType] += distanceToWeight(Vector2.Distance(new Vector2(x, y), new Vector2(procTerrainGen.areaBorders[i].position.x, procTerrainGen.areaBorders[i].position.z)));
        }


        for (int i = 0; i < areas.Length; i++)
        {
            sum += areas[i];
        }


        for (int i = 0; i < areas.Length; i++)
        {
            areas[i] = areas[i] / sum;
        }

        return areas;
    }

    private static float distanceDivVal = 50000f;
    private static float distanceToWeight(float distance)
    {
        float val = distance / distanceDivVal;

        val = 1f - val;
        if (val <= 0f)
        {
            val = 0f;
        }

        val = val * val * val * val;

        return val;
    }

    public static float snow_mountain_height(float x, float y, ProcTerrainGen procTerrainGen)
    {
        initNoises();

        float height = 0f;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency, y * procTerrainGen.perlinFrequency) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 2f, y * procTerrainGen.perlinFrequency * 2f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.5f;


        float perlinSnowMountainFrequency = 0.005f;
        float perlinSnowMountainAmplitude = 0.0025f;
        float ridgedMultiAmplitudeSnow = 0.8f;
        if (procTerrainGen != null)
        {
            perlinSnowMountainFrequency = procTerrainGen.perlinSnowMountainFrequency;
            perlinSnowMountainAmplitude = procTerrainGen.perlinSnowMountainAmplitude;
            ridgedMultiAmplitudeSnow = procTerrainGen.ridgedMultiAmplitudeSnow;
        }

        height += (perlin.noise2(x * perlinSnowMountainFrequency * 4f, y * perlinSnowMountainFrequency * 4f) * 0.5f + 0.5f) * perlinSnowMountainAmplitude * 0.25f;
        height += (perlin.noise2(x * perlinSnowMountainFrequency * 8f, y * perlinSnowMountainFrequency * 8f) * 0.5f + 0.5f) * perlinSnowMountainAmplitude * 0.125f;
        height += (perlin.noise2(x * perlinSnowMountainFrequency * 16f, y * perlinSnowMountainFrequency * 16f) * 0.5f + 0.5f) * perlinSnowMountainAmplitude * 0.125f * 0.5f;

        //float mountain = perlin.noise2(x * procTerrainGen.mountainPerlinFrequency, y * procTerrainGen.mountainPerlinFrequency) * 0.5f + 0.5f;
        //mountain = mountain * mountain * mountain * mountain;
        //mountain *= procTerrainGen.mountainPerlinAmplitude;

        //height += mountain;


        height += ((float)ridgedMulti.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * ridgedMultiAmplitudeSnow;

        //height += ((float)billow.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * procTerrainGen.billowAmplitude;






        height = Mathf.Clamp(height, 0f, 1f);







        return height;
    }

    private float mountain_height(PerlinNoise perlin, RidgedMulti ridgedMulti, Billow billow, float x, float y)
    {

        float height = 0f;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency, y * procTerrainGen.perlinFrequency) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 2f, y * procTerrainGen.perlinFrequency * 2f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.5f;
        
        height += (perlin.noise2(x * procTerrainGen.perlinMountainFrequency * 4f, y * procTerrainGen.perlinMountainFrequency * 4f) * 0.5f + 0.5f) * procTerrainGen.perlinMountainAmplitude * 0.25f;
        height += (perlin.noise2(x * procTerrainGen.perlinMountainFrequency * 8f, y * procTerrainGen.perlinMountainFrequency * 8f) * 0.5f + 0.5f) * procTerrainGen.perlinMountainAmplitude * 0.125f;
        height += (perlin.noise2(x * procTerrainGen.perlinMountainFrequency * 16f, y * procTerrainGen.perlinMountainFrequency * 16f) * 0.5f + 0.5f) * procTerrainGen.perlinMountainAmplitude * 0.125f * 0.5f;

        //float mountain = perlin.noise2(x * procTerrainGen.mountainPerlinFrequency, y * procTerrainGen.mountainPerlinFrequency) * 0.5f + 0.5f;
        //mountain = mountain * mountain * mountain * mountain;
        //mountain *= procTerrainGen.mountainPerlinAmplitude;

        //height += mountain;


        height += ((float)ridgedMulti.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * procTerrainGen.ridgedMultiAmplitude; 

        //height += ((float)billow.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * procTerrainGen.billowAmplitude;


        height = Mathf.Clamp(height, 0f, 1f);







        return height;
    }

    private float plane_height(PerlinNoise perlin, int x, int y)
    {
        float height = (perlin.noise2(x * procTerrainGen.perlinFrequency, y * procTerrainGen.perlinFrequency) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.2f + 0.1f;

        height = Mathf.Clamp(height, 0f, 1f);

        return height; 
    }

    /*

    private float distanceToBorder(AreaBorder border, Vector2 pos)
    {
        //CurveSample curveSample = border.spline.GetProjectionSample(new Vector3(pos.x, 0f, pos.y));
        CurveSample curveSample = closestSplinePoint(border.spline, new Vector3(pos.x, 0f, pos.y));
        bool isLeftSide = false;

        Vector2 rotatedTangent = new Vector2(curveSample.tangent.x, curveSample.tangent.z);
        rotatedTangent = new Vector2(rotatedTangent.y, -rotatedTangent.x);

        Vector2 vecToClosestPoint = (new Vector2(curveSample.location.x, curveSample.location.z)) - pos;

        if (Vector2.Angle(vecToClosestPoint, rotatedTangent) < 90f)
        {
            isLeftSide = true;
        }

        float distance = vecToClosestPoint.magnitude;

        return isLeftSide ? distance : -distance;
    }

    
    private int stepsAmount = 100;
    private float accuracy = 10f;
    private CurveSample closestSplinePoint(Spline spline, Vector3 pos)
    {
        return recClosestSplinePoint(spline, 0f, spline.nodes.Count, pos);
    }

    private CurveSample recClosestSplinePoint(Spline spline, float startDistance, float stopDistance, Vector3 pos)
    {
        CurveSample minPoint = spline.GetCurve(0).GetSample(0f);
        float minDistance = float.MaxValue;
        int minIndex = -1;
        for (int i = 0; i < stepsAmount; i++)
        {
            float distance = Mathf.Lerp(startDistance, stopDistance, ((float)i) / stepsAmount);
            int curve = (int)distance;

            CurveSample curveSample = spline.GetCurve(curve).GetSample(distance - curve);
            //CurveSample curveSample = spline.GetSampleAtDistance(distance);
            float posDistance = Vector3.Distance(curveSample.location, pos);
            if (posDistance < minDistance)
            {
                minDistance = posDistance;
                minPoint = curveSample;
                minIndex = i;
            }
        }
        

        float accuracyHere = (stopDistance - startDistance) / stepsAmount; 

        if (accuracyHere <= accuracy)
        {
            return minPoint;
        }
        else
        {
            int newMinIndex = minIndex - 5;
            int newMaxIndex = minIndex + 5;


            float newStartDistance = Mathf.Lerp(startDistance, stopDistance, ((float)newMinIndex) / stepsAmount);
            float newEndDistance = Mathf.Lerp(startDistance, stopDistance, ((float)newMaxIndex) / stepsAmount);

            if (newStartDistance < 0f)
            {
                newStartDistance = 0f;
            }
            if (newEndDistance > spline.Length)
            {
                newEndDistance = spline.Length;
            }

            return recClosestSplinePoint(spline, newStartDistance, newEndDistance, pos);
        }
    }*/

    public float Progress
    {
        get; set;
    } = 0f;
}
