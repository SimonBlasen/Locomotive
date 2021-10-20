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
    private bool generatePreview = false;
    [SerializeField]
    public ProcAreaType areaPreview = ProcAreaType.MOUNTAINS;
    [SerializeField]
    private bool applyTerrain = false;
    [SerializeField]
    public float perlinFrequency = 0.4f;
    [SerializeField]
    public float perlinAmplitude = 0.5f;
    [SerializeField]
    public float mountainPerlinFrequency = 0.000045f;
    [SerializeField]
    public float mountainPerlinAmplitude = 0.2f;
    public AnimationCurve mountainCurve;
    public ProcTerrainInputTexture inputTextureHeight = null;
    [SerializeField]
    public float areaFrequency = 0.000045f;

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
        if (generatePreview)
        {
            generatePreview = false;

            previewRender();
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

    private void previewRender()
    {
        terrainAccessor.OpenData();

        inputTextureHeight.OpenData();

        for (int i = 0; i < areaBorders.Length; i++)
        {
            areaBorders[i].position = areaBorders[i].transform.position;
        }


        jobsRunning = true;

        //PerlinNoise perlin = new PerlinNoise(0);

        int steps = 5000;
        long seed = 0;


        for (int x = 0; x < 50000; x += steps)
        {
            for (int y = 0; y < 50000; y += steps)
            {
                JobProcGen jobProcGen = new JobProcGen();
                jobProcGen.startPos = new Vector2Int(x, y);
                jobProcGen.endPos = new Vector2Int(x + steps, y + steps);
                jobProcGen.procTerrainGen = this;
                jobProcGen.seed = seed;
                jobProcGen.terrainAccessor = terrainAccessor;

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

                float height = JobProcGen.calcAreaWeights(perlin, this, (int)globalPos.x, (int)globalPos.y)[(int)areaPreview];
                textureArea.SetPixel(x, y, new Color(height, height, height));
            }
        }

        textureArea.Apply();

        matArea.mainTexture = textureArea;
        //mat.SetTexture("_MainTex", texture);
    }
}