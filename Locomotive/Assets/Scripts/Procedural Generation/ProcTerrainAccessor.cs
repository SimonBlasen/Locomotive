using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProcTerrainAccessor : MonoBehaviour
{
    [SerializeField]
    private int terrainsSpacing = 1;

    private Terrain[] terrains = null;

    private Terrain[,] terrains2D = null;
    private TerrainChunkHeights[,] chunks = null;

    private int heightmapRes = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OpenData()
    {
        terrains = FindObjectsOfType<Terrain>();

        terrains2D = new Terrain[(int)Mathf.Sqrt(terrains.Length), (int)Mathf.Sqrt(terrains.Length)];
        chunks = new TerrainChunkHeights[(int)Mathf.Sqrt(terrains.Length), (int)Mathf.Sqrt(terrains.Length)];

        Debug.Log("Terrains size: (" + terrains2D.GetLength(0).ToString() + ", " + terrains2D.GetLength(1).ToString() + ")");

        for (int i = 0; i < terrains.Length; i++)
        {
            heightmapRes = terrains[i].terrainData.heightmapResolution;
            Vector2Int pos2D = new Vector2Int((int)((terrains[i].transform.position.x + terrainsSpacing * 0.5f) / terrainsSpacing), (int)((terrains[i].transform.position.z + terrainsSpacing * 0.5f) / terrainsSpacing));

            terrains2D[pos2D.x, pos2D.y] = terrains[i];
            chunks[pos2D.x, pos2D.y] = new TerrainChunkHeights(heightmapRes);
        }

        Debug.Log("All terrains ordered in 2D");


    }

    public int HeightmapRes
    {
        get
        {
            return terrains[0].terrainData.heightmapResolution;
        }
    }

    public int TerrainsSpacing
    {
        get
        {
            return terrainsSpacing;
        }
    }

    public void CloseData()
    {
        for (int x = 0; x < terrains2D.GetLength(0); x++)
        {
            for (int y = 0; y < terrains2D.GetLength(1); y++)
            {
                if (chunks[x, y].isDirty)
                {
                    terrains2D[x, y].terrainData.SetHeights(0, 0, chunks[x, y].heights);
                }
            }
        }
    }

    public void SetHeight(Vector2 pos, float height)
    {
        Vector2Int chunkPos2D = new Vector2Int((int)(pos.x / terrainsSpacing), (int)(pos.y / terrainsSpacing));
        Vector2Int heightmapPos = new Vector2Int(   Mathf.Clamp((int)(((pos.x - chunkPos2D.x * terrainsSpacing) / terrainsSpacing) * heightmapRes), 0, heightmapRes - 1), 
                                                    Mathf.Clamp((int)(((pos.y - chunkPos2D.y * terrainsSpacing) / terrainsSpacing) * heightmapRes), 0, heightmapRes - 1));

        chunks[chunkPos2D.x, chunkPos2D.y].heights[heightmapPos.y, heightmapPos.x] = height;
        chunks[chunkPos2D.x, chunkPos2D.y].isDirty = true;
    }


    public void SetHeight(Vector2Int terrainIndex, Vector2Int terrainHeightmapPos, float height)
    {
        Vector2Int chunkPos2D = terrainIndex;
        Vector2Int heightmapPos = terrainHeightmapPos;

        chunks[chunkPos2D.x, chunkPos2D.y].heights[heightmapPos.y, heightmapPos.x] = height;
        chunks[chunkPos2D.x, chunkPos2D.y].isDirty = true;
    }

    public float GetHeight(Vector2 pos)
    {
        Vector2Int chunkPos2D = new Vector2Int((int)(pos.x / terrainsSpacing), (int)(pos.y / terrainsSpacing));
        Vector2Int heightmapPos = new Vector2Int(Mathf.Clamp((int)(((pos.x - chunkPos2D.x * terrainsSpacing) / terrainsSpacing) * heightmapRes), 0, heightmapRes - 1),
                                                    Mathf.Clamp((int)(((pos.y - chunkPos2D.y * terrainsSpacing) / terrainsSpacing) * heightmapRes), 0, heightmapRes - 1));

        return chunks[chunkPos2D.x, chunkPos2D.y].heights[heightmapPos.y, heightmapPos.x];
    }
}


public class TerrainChunkHeights
{
    public float[,] heights;
    public bool isDirty = false;

    public TerrainChunkHeights(int heightmapResolution)
    {
        heights = new float[heightmapResolution, heightmapResolution];
    }
}