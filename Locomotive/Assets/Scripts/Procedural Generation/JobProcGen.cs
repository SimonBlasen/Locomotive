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

    public bool onlyMakeOneAreaType = false;

    public ProcTerrainGen procTerrainGen;


    protected override void ThreadFunction()
    {
        PerlinNoise perlin = new PerlinNoise(0);

        Billow billow = new Billow();
        billow.Frequency = 1.0;
        billow.Lacunarity = 2.0;
        billow.OctaveCount = 6;
        billow.NoiseQuality = noise.NoiseQuality.QUALITY_STD;
        billow.Persistence = 0.5;

        RidgedMulti ridgedMulti = new RidgedMulti();
        ridgedMulti.Frequency = 1.0;
        ridgedMulti.Lacunarity = 2.0;
        ridgedMulti.OctaveCount = 6;
        ridgedMulti.NoiseQuality = noise.NoiseQuality.QUALITY_STD;
        ridgedMulti.CalculateSpectralWeights();
        ScaleBias scaleBias = new ScaleBias();
        Select select = new Select();
        Perlin perlinLib = new Perlin();

        for (int x = startPos.x; x < endPos.x; x++)
        {
            Progress = (x - startPos.x) / ((float)(endPos.x - startPos.x));

            for (int y = startPos.y; y < endPos.y; y++)
            {
                if (onlyLowResSteps == null || onlyLowResSteps.Length == 0
                    || (Utils.IsInIntArray(onlyLowResSteps, x) && Utils.IsInIntArray(onlyLowResSteps, y)))
                {
                    float height = 0f;

                    /*float height = (perlin.noise2(x * procTerrainGen.perlinFrequency, y * procTerrainGen.perlinFrequency) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude;
                    height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 2f, y * procTerrainGen.perlinFrequency * 2f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.5f;
                    height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 4f, y * procTerrainGen.perlinFrequency * 4f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.25f;
                    height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 8f, y * procTerrainGen.perlinFrequency * 8f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.125f;
                    height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 16f, y * procTerrainGen.perlinFrequency * 16f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.125f * 0.5f;

                    float mountain = perlin.noise2(x * procTerrainGen.mountainPerlinFrequency, y * procTerrainGen.mountainPerlinFrequency) * 0.5f + 0.5f;
                    mountain = mountain * mountain * mountain * mountain;
                    mountain *= procTerrainGen.mountainPerlinAmplitude;

                    height += mountain;

                    //height += procTerrainGen.inputTextureHeight.GetValue(new Vector2(x, y));

                    height = Mathf.Clamp(height, 0f, 1f);*/











                    /*
                    float closestDistance = float.MaxValue;
                    AreaBorder closestArea = null;
                    for (int i = 0; i < procTerrainGen.areaBorders.Length; i++)
                    {
                        float distance = 0f;// distanceToBorder(procTerrainGen.areaBorders[i], new Vector2(x, y));

                        if (Mathf.Abs(distance) < closestDistance)
                        {
                            closestDistance = distance;
                            closestArea = procTerrainGen.areaBorders[i];
                        }
                    }

                    List<ProcAreaType> areas = new List<ProcAreaType>();
                    List<float> areaWeights = new List<float>();

                    if (Mathf.Abs(closestDistance) >= procTerrainGen.minDistanceToBorder)
                    {
                        areas.Add(closestDistance >= 0f ? closestArea.areaLeft : closestArea.areaRight);
                        areaWeights.Add(1f);
                    }
                    else
                    {
                        float interpol = Mathf.InverseLerp(procTerrainGen.minDistanceToBorder, -procTerrainGen.minDistanceToBorder, closestDistance);

                        areas.Add(closestArea.areaLeft);
                        areaWeights.Add(1f - interpol);
                        areas.Add(closestArea.areaRight);
                        areaWeights.Add(interpol);
                    }



                    for (int i = 0; i < areas.Count; i++)
                    {
                        if (areas[i] == ProcAreaType.MOUNTAINS)
                        {
                            height += mountain_height(perlin, x, y) * areaWeights[i];
                        }
                        else if (areas[i] == ProcAreaType.PLANE)
                        {
                            height += plane_height(perlin, x, y) * areaWeights[i];
                        }
                    }*/

                    float[] areaWeights = calcAreaWeights(perlin, procTerrainGen, x, y);




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
                                height += mountain_height(perlin, ridgedMulti, billow, x, y) * areaWeights[i];
                            }
                            else if (i == (int)ProcAreaType.PLANE)
                            {
                                height += plane_height(perlin, x, y) * areaWeights[i];
                            }
                            else if (i == (int)ProcAreaType.FORREST)
                            {
                                height += forrest_height(procTerrainGen, perlinLib, perlin, billow, ridgedMulti, x, y) * areaWeights[i];
                            }
                            else if (i == (int)ProcAreaType.SNOW_MOUNTAINS)
                            {
                                height += snow_mountain_height(perlin, ridgedMulti, billow, x, y) * areaWeights[i];
                            }
                        }

                    }



                    terrainAccessor.SetHeight(new Vector2(x, y), height);
                }
            }
        }
    }

    public static float forrest_height(ProcTerrainGen procTerrainGen, Perlin perlinLib, PerlinNoise perlin, Billow billow, RidgedMulti ridgedMulti, int x, int y)
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

    public static float planes_height(ProcTerrainGen procTerrainGen, Perlin perlinLib, PerlinNoise perlin, Billow billow, RidgedMulti ridgedMulti, int x, int y)
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


    public static float[] calcAreaWeights(PerlinNoise perlin, ProcTerrainGen procTerrainGen, int x, int y)
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

        val = val * val * val * val;

        return val;
    }

    private float snow_mountain_height(PerlinNoise perlin, RidgedMulti ridgedMulti, Billow billow, int x, int y)
    {

        float height = 0f;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency, y * procTerrainGen.perlinFrequency) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude;
        //height += (perlin.noise2(x * procTerrainGen.perlinFrequency * 2f, y * procTerrainGen.perlinFrequency * 2f) * 0.5f + 0.5f) * procTerrainGen.perlinAmplitude * 0.5f;

        height += (perlin.noise2(x * procTerrainGen.perlinSnowMountainFrequency * 4f, y * procTerrainGen.perlinSnowMountainFrequency * 4f) * 0.5f + 0.5f) * procTerrainGen.perlinSnowMountainAmplitude * 0.25f;
        height += (perlin.noise2(x * procTerrainGen.perlinSnowMountainFrequency * 8f, y * procTerrainGen.perlinSnowMountainFrequency * 8f) * 0.5f + 0.5f) * procTerrainGen.perlinSnowMountainAmplitude * 0.125f;
        height += (perlin.noise2(x * procTerrainGen.perlinSnowMountainFrequency * 16f, y * procTerrainGen.perlinSnowMountainFrequency * 16f) * 0.5f + 0.5f) * procTerrainGen.perlinSnowMountainAmplitude * 0.125f * 0.5f;

        //float mountain = perlin.noise2(x * procTerrainGen.mountainPerlinFrequency, y * procTerrainGen.mountainPerlinFrequency) * 0.5f + 0.5f;
        //mountain = mountain * mountain * mountain * mountain;
        //mountain *= procTerrainGen.mountainPerlinAmplitude;

        //height += mountain;


        height += ((float)ridgedMulti.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * procTerrainGen.ridgedMultiAmplitudeSnow;

        //height += ((float)billow.GetValue(x * 0.000054987312, y * 0.000054987312, 0.0) * 0.4f + 0.5f) * procTerrainGen.billowAmplitude;


        height = Mathf.Clamp(height, 0f, 1f);







        return height;
    }

    private float mountain_height(PerlinNoise perlin, RidgedMulti ridgedMulti, Billow billow, int x, int y)
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
