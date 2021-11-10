using noise.module;
using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ProcAreaType
{
    MOUNTAINS = 0, SNOW_MOUNTAINS = 1, DESERT = 2, PLANE = 3, FORREST = 4, MIXED = 5
}


[ExecuteInEditMode]
public class ProcTerrainGen : MonoBehaviour
{
    [SerializeField]
    private long seed = 0;

    [Space]

    [SerializeField]
    private bool generatePreview = false;
    [SerializeField]
    public ProcAreaType areaPreview = ProcAreaType.MOUNTAINS;
    [SerializeField]
    public Color[] areaColors = null;


    [Space]

    [SerializeField]
    private bool generateCurve = false;
    [SerializeField]
    public ProcAreaType areaTypeCurve = ProcAreaType.MOUNTAINS;
    [SerializeField]
    public int metersAmount = 100;
    [SerializeField]
    public AnimationCurve animCurve;


    [Space]

    [SerializeField]
    private bool computePreview = false;
    [SerializeField]
    private bool showAreaPreview = false;
    [SerializeField]
    public ProcAreaType areaPreviewBlending = ProcAreaType.MOUNTAINS;
    [SerializeField]
    private bool applyTerrain = false;
    [SerializeField]
    public float perlinFrequency = 0.4f;
    [SerializeField]
    public float perlinAmplitude = 0.5f;
    [SerializeField]
    public float perlinMountainFrequency = 0.4f;
    [SerializeField]
    public float perlinMountainAmplitude = 0.5f;
    [SerializeField]
    public float perlinSnowMountainFrequency = 0.4f;
    [SerializeField]
    public float perlinSnowMountainAmplitude = 0.5f;
    [SerializeField]
    public float ridgedMultiAmplitude = 0.2f;
    [SerializeField]
    public float ridgedMultiAmplitudeSnow = 0.2f;
    [SerializeField]
    public float billowAmplitude = 0.2f;
    [SerializeField]
    public float mountainPerlinFrequency = 0.000045f;
    public AnimationCurve mountainCurve;
    public ProcTerrainInputTexture inputTextureHeight = null;
    [SerializeField]
    public float areaFrequency = 0.000045f;

    [Space]

    [Header("Forrest")]

    [SerializeField]
    public float aTanX = 0.5f;
    [SerializeField]
    public float aTanXOffset = 0.5f;
    [SerializeField]
    public float aTanY = 0.5f;
    [SerializeField]
    public float forrestPerlinFreq = 0.5f;
    [SerializeField]
    public float forrestPerlinAmpl = 0.5f;
    [SerializeField]
    public float forrestRigFreq = 0.5f;
    [SerializeField]
    public float forrestRigAmpl = 0.5f;
    [SerializeField]
    public float forrestRigOffset = 0.5f;
    [SerializeField]
    public float forrestLowFreqPerlinFreq = 0.5f;
    [SerializeField]
    public float forrestLowFreqPerlinAmpl = 0.5f;
    [SerializeField]
    public float forrestLowFreqPerlinAmplOffset = 0.5f;
    [SerializeField]
    public float forrestLowFreqInfluence = 1f;

    [Space]

    [Header("Planes")]

    [SerializeField]
    public float aTanPlanesX = 0.5f;
    [SerializeField]
    public float aTanPlanesXOffset = 0.5f;
    [SerializeField]
    public float aTanPlanesY = 0.5f;
    [SerializeField]
    public float planesPerlinFreq = 0.5f;
    [SerializeField]
    public float planesPerlinAmpl = 0.5f;
    [SerializeField]
    public float planesRigFreq = 0.5f;
    [SerializeField]
    public float planesRigAmpl = 0.5f;
    [SerializeField]
    public float planesRigOffset = 0.5f;
    [SerializeField]
    public float planesLowFreqPerlinFreq = 0.5f;
    [SerializeField]
    public float planesLowFreqPerlinAmpl = 0.5f;
    [SerializeField]
    public float planesLowFreqPerlinAmplOffset = 0.5f;
    [SerializeField]
    public float planesLowFreqInfluence = 1f;

    [Space]

    [Header("Desert")]

    [SerializeField]
    public float desertPerlinFreq = 0.5f;
    [SerializeField]
    public float desertPerlinAmpl = 0.5f;
    [SerializeField]
    public float desertRigFreq = 0.5f;
    [SerializeField]
    public float desertRigAmpl = 0.5f;
    [SerializeField]
    public float desertRigOffset = 0.5f;
    [SerializeField]
    public float desertLowFreqPerlinFreq = 0.5f;
    [SerializeField]
    public float desertLowFreqPerlinAmpl = 0.5f;
    [SerializeField]
    public float desertLowFreqPerlinAmplOffset = 0.5f;
    [SerializeField]
    public float desertLowFreqInfluence = 1f;

    public float minDistanceToBorder = 50f;
    public int amountOfAreas = 6;
    public AreaBorder[] areaBorders = new AreaBorder[0];

    [Space]

    [Header("References")]
    [SerializeField]
    private MeshRenderer rendererPlane = null;
    [SerializeField]
    private MeshRenderer areaRenderPlane = null;
    [SerializeField]
    private ProcTerrainAccessor terrainAccessor = null;

    private List<JobProcGen> runningJobs = new List<JobProcGen>();

    private bool jobsRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showAreaPreview)
        {
            showAreaPreview = false;

            showOnlyAreaPreview();
        }


        if (computePreview)
        {
            computePreview = false;

            previewRender(false);
        }

        if (generateCurve)
        {
            generateCurve = false;

            showAnimGraph();
        }

        if (generatePreview)
        {
            generatePreview = false;


            renderSmallChunk();

            /*
            noise.module.RidgedMulti ridgedMulti = new noise.module.RidgedMulti();

            ridgedMulti.Frequency = 1.0;
            ridgedMulti.Lacunarity = 2.0;
            ridgedMulti.OctaveCount = 6;
            ridgedMulti.NoiseQuality = noise.NoiseQuality.QUALITY_STD;
            ridgedMulti.CalculateSpectralWeights();
            Debug.Log(ridgedMulti.GetValue(50, 70, 60).ToString("n2"));
            Debug.Log(ridgedMulti.GetValue(50.02, 70, 60).ToString("n2"));
            Debug.Log(ridgedMulti.GetValue(0.1, 2, -80).ToString("n2"));

            */
            //previewRender(true);
        }
        if (applyTerrain)
        {
            applyTerrain = false;

            actuallyApplyTerrain();
        }

        if (jobsRunning)
        {
            for (int i = 0; i < runningJobs.Count; i++)
            {
                if (runningJobs[i].IsDone)
                {
                    runningJobs.RemoveAt(i);
                    break;
                }
            }

            if (runningJobs.Count == 0)
            {
                Debug.Log("Finished running jobs");
                jobsRunning = false;

                finalizeRunningJobs();
            }
            else
            {
                Debug.Log("Progress: " + (runningJobs[0].Progress * 100f).ToString("n2") + "%");
            }
        }
    }
    private void actuallyApplyTerrain()
    {
        terrainAccessor.CloseData();
    }

    private void showAnimGraph()
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

        Keyframe[] keyframes = new Keyframe[2000];
        for (int i = 0; i < 2000; i++)
        {
            float height = 0f;
            if (areaTypeCurve == ProcAreaType.FORREST)
            {
                height = JobProcGen.forrest_height(this, perlinLib, perlin, billow, ridgedMulti, (int)((i / 2000f) * metersAmount), 0);
            }
            keyframes[i] = new Keyframe(i, height);
        }

        animCurve.keys = keyframes;
    }

    private void renderSmallChunk()
    {
        terrainAccessor.OpenData();

        inputTextureHeight.OpenData();

        for (int i = 0; i < areaBorders.Length; i++)
        {
            areaBorders[i].position = areaBorders[i].transform.position;
        }


        jobsRunning = true;

        List<int> onlyLowResSteps = new List<int>();
        for (int i = 0; i < 4096; i++)
        {
            onlyLowResSteps.Add((int)((i / 4096f) * 100000f));
        }

        //PerlinNoise perlin = new PerlinNoise(0);

        int steps = 2500;


        for (int x = 0; x < 10000 * 1; x += steps)
        {
            for (int y = 0; y < 10000 * 1; y += steps)
            {
                JobProcGen jobProcGen = new JobProcGen();
                jobProcGen.startPos = new Vector2Int(x, y);
                jobProcGen.endPos = new Vector2Int(x + steps, y + steps);
                jobProcGen.procTerrainGen = this;
                jobProcGen.seed = seed;
                jobProcGen.terrainAccessor = terrainAccessor;
                jobProcGen.onlyMakeOneAreaType = true;

                jobProcGen.Start();
                runningJobs.Add(jobProcGen);


            }
        }
    }

    private void previewRender(bool onlyPreview)
    {
        refreshAreaBorders();

        terrainAccessor.OpenData();

        inputTextureHeight.OpenData();

        for (int i = 0; i < areaBorders.Length; i++)
        {
            areaBorders[i].position = areaBorders[i].transform.position;
        }


        jobsRunning = true;

        List<int> onlyLowResSteps = new List<int>();
        for (int i = 0; i < 4096; i++)
        {
            onlyLowResSteps.Add((int)((i / 4096f) * 100000f));
        }

        //PerlinNoise perlin = new PerlinNoise(0);

        int steps = 10000;


        for (int x = 50000; x < 50000 * 2; x += steps)
        {
            for (int y = 0; y < 50000 * 1; y += steps)
            {
                JobProcGen jobProcGen = new JobProcGen();
                jobProcGen.useTerrainIndices = true;
                //jobProcGen.startPos = new Vector2Int(x, y);
                //jobProcGen.endPos = new Vector2Int(x + steps, y + steps);
                jobProcGen.terrainIndex = new Vector2Int(x / steps, y / steps);
                jobProcGen.procTerrainGen = this;
                jobProcGen.seed = seed;
                jobProcGen.terrainAccessor = terrainAccessor;
                if (onlyPreview)
                {
                    jobProcGen.onlyLowResSteps = onlyLowResSteps.ToArray();
                }

                jobProcGen.Start();
                runningJobs.Add(jobProcGen);

                
            }
        }
    }

    private void finalizeRunningJobs()
    {
        PerlinNoise perlin = new PerlinNoise(0);

        Material mat = rendererPlane.sharedMaterial;

        Texture2D texture = new Texture2D(4096 * 1, 4096 * 1);

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                Vector2 globalPos = new Vector2((x / ((float)texture.width)) * 100000f, (y / ((float)texture.width)) * 100000f);

                float height = terrainAccessor.GetHeight(globalPos);
                texture.SetPixel(x, y, new Color(height, height, height));
            }
        }

        texture.Apply();

        mat.mainTexture = texture;
        //mat.SetTexture("_MainTex", texture);






        Material matArea = areaRenderPlane.sharedMaterial;

        Texture2D textureArea = new Texture2D(4096 * 1, 4096 * 1);

        for (int x = 0; x < textureArea.width; x++)
        {
            for (int y = 0; y < textureArea.height; y++)
            {
                Vector2 globalPos = new Vector2((x / ((float)textureArea.width)) * 100000f, (y / ((float)textureArea.width)) * 100000f);

                float height = JobProcGen.calcAreaWeights(perlin, this, (int)globalPos.x, (int)globalPos.y)[(int)areaPreviewBlending];
                textureArea.SetPixel(x, y, new Color(height, height, height));
            }
        }

        textureArea.Apply();

        matArea.mainTexture = textureArea;
        //mat.SetTexture("_MainTex", texture);
    }

    private void showOnlyAreaPreview()
    {
        refreshAreaBorders();

        PerlinNoise perlin = new PerlinNoise(0);
        Material matArea = areaRenderPlane.sharedMaterial;

        Texture2D textureArea = new Texture2D(4096 * 1, 4096 * 1);

        for (int x = 0; x < textureArea.width; x++)
        {
            for (int y = 0; y < textureArea.height; y++)
            {
                Vector2 globalPos = new Vector2((x / ((float)textureArea.width)) * 100000f, (y / ((float)textureArea.width)) * 100000f);

                Vector3 colorVec = Vector3.zero;

                float[] heights = JobProcGen.calcAreaWeights(perlin, this, (int)globalPos.x, (int)globalPos.y);
                for (int i = 0; i < areaColors.Length; i++)
                {
                    colorVec += (new Vector3(areaColors[i].r, areaColors[i].g, areaColors[i].b)) * heights[i];
                }

                //colorVec /= areaColors.Length;

                textureArea.SetPixel(x, y, new Color(colorVec.x, colorVec.y, colorVec.z));
            }
        }

        textureArea.Apply();

        matArea.mainTexture = textureArea;
        matArea.mainTexture = textureArea;
    }

    private void refreshAreaBorders()
    {
        for (int i = 0; i < areaBorders.Length; i++)
        {
            areaBorders[i].position = areaBorders[i].transform.position;
        }
    }
}