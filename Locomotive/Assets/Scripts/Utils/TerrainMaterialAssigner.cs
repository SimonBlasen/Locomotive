using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TerrainMaterialAssigner : MonoBehaviour
{
    public Material toAssignMaterial = null;
    public float pixelError = 1f;

    public bool assign = false;
    public bool stayRefresh = false;

    public bool paintTextures = false;
    public float baseMapDistance = 10000f;
    public Terrain[] paintTerrains = null;
    public int layersAmount = 3;

    [Space]

    public ProcTerrainTextureCurve[] curvesLayers = null;

    private float refreshCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stayRefresh)
        {
            refreshCounter -= Time.deltaTime;
            if (refreshCounter <= 0f)
            {
                refreshCounter = 3f;
                paintTextures = true;
            }
        }

        if (assign)
        {
            assign = false;

            Terrain[] terrains = FindObjectsOfType<Terrain>();

            for (int i = 0; i < terrains.Length; i++)
            {
                terrains[i].materialTemplate = toAssignMaterial;
                terrains[i].heightmapPixelError = pixelError;
            }
        }

        if (paintTextures)
        {
            paintTextures = false;

            TerrainLayer[] terrainLayers = paintTerrains[0].terrainData.terrainLayers;

            for (int t = 0; t < paintTerrains.Length; t++)
            {
                Terrain paintTerrain = paintTerrains[t];

                paintTerrain.basemapDistance = baseMapDistance;

                if (t > 0)
                {
                    paintTerrain.terrainData.terrainLayers = terrainLayers;
                }

                float[,] terrainHeights = paintTerrain.terrainData.GetHeights(0, 0, paintTerrain.terrainData.heightmapResolution, paintTerrain.terrainData.heightmapResolution);

                float[,,] alphaMap = paintTerrain.terrainData.GetAlphamaps(0, 0, paintTerrain.terrainData.alphamapWidth, paintTerrain.terrainData.alphamapHeight);

                for (int x = 0; x < paintTerrain.terrainData.alphamapWidth; x++)
                {
                    for (int y = 0; y < paintTerrain.terrainData.alphamapHeight; y++)
                    {
                        Vector2Int heightmapPos = new Vector2Int((int)((((float)x) / paintTerrain.terrainData.alphamapWidth) * paintTerrain.terrainData.heightmapResolution),
                                                                 (int)((((float)y) / paintTerrain.terrainData.alphamapHeight) * paintTerrain.terrainData.heightmapResolution));

                        heightmapPos = new Vector2Int(Mathf.Clamp(heightmapPos.x, 1, paintTerrain.terrainData.heightmapResolution - 2),
                                                    Mathf.Clamp(heightmapPos.y, 1, paintTerrain.terrainData.heightmapResolution - 2));

                        float heightHere = terrainHeights[heightmapPos.x, heightmapPos.y] * 6000f;

                        float heightX_0 = terrainHeights[heightmapPos.x - 1, heightmapPos.y] * 6000f;
                        float heightX_1 = terrainHeights[heightmapPos.x + 1, heightmapPos.y] * 6000f;
                        float heightY_0 = terrainHeights[heightmapPos.x, heightmapPos.y - 1] * 6000f;
                        float heightY_1 = terrainHeights[heightmapPos.x, heightmapPos.y + 1] * 6000f;

                        float slope = Mathf.Max(Mathf.Abs((heightX_0 - heightX_1) / 2f), Mathf.Abs((heightY_0 - heightY_1) / 2f));

                        float angle = Mathf.Atan(slope) / Mathf.PI;

                        float[] layerWeights = new float[curvesLayers.Length];

                        float weightSum = 0f;

                        for (int i = 0; i < layerWeights.Length; i++)
                        {
                            layerWeights[i] = 1f;

                            for (int j = 0; j < curvesLayers[i].curves.Length; j++)
                            {
                                if (curvesLayers[i].curves[j].property == TexturePropType.SLOPE)
                                {
                                    layerWeights[i] *= curvesLayers[i].curves[j].curve.Evaluate(angle);
                                }
                                else if (curvesLayers[i].curves[j].property == TexturePropType.ABS_HEIGHT)
                                {
                                    layerWeights[i] *= curvesLayers[i].curves[j].curve.Evaluate(heightHere / 6000f);
                                }
                            }

                            weightSum += layerWeights[i];
                        }

                        for (int i = 0; i < layerWeights.Length; i++)
                        {
                            alphaMap[x, y, i] = layerWeights[i] / weightSum;
                        }


                        /*
                        float rocksWeight = slope / slopeFullRocks;

                        rocksWeight = Mathf.Clamp(rocksWeight, 0f, 1f);

                        rocksWeight = 1f - Mathf.Cos(rocksWeight);

                        alphaMap[x, y, 0] = 1f - rocksWeight;
                        alphaMap[x, y, 2] = rocksWeight;*/
                    }
                }


                paintTerrain.terrainData.SetAlphamaps(0, 0, alphaMap);
                paintTerrain.Flush();
            }

        }
    }
}
