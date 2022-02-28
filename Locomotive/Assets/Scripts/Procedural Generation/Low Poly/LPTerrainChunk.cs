using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPTerrainChunk : MonoBehaviour
{
    private MeshRenderer meshRenderer = null;
    private MeshFilter meshFilter = null;

    private LPChunkDiv rootChunkDiv = null;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        rootChunkDiv = new LPChunkDiv(WorldPos, WorldPos + ChunkSize, Vector2.zero, ChunkSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LowPolyTerrain LowPolyTerrain
    {
        get; set;
    } = null;

    public Vector2Int ChunkSize
    {
        get;set;
    }

    /// <summary>
    /// [0] is at (1, 0)
    /// [1] is at (0, -1)
    /// [2] is at (-1, 0)
    /// [3] is at (0, 1)
    /// 
    /// </summary>
    public LPTerrainChunk[] NeighbourChunks
    {
        get;set;
    }

    public Vector2Int ChunkPos
    {
        get;set;
    }

    public Vector2 WorldPos
    {
        get
        {
            return new Vector2(ChunkPos.x * ChunkSize.x, ChunkPos.y * ChunkSize.y);
        }
    }

    public float RefreshTessellationIn
    {
        get; set;
    } = 0f;

    public bool debugBool = false;

    public void RefreshTessellation(Vector2 playerPos)
    {
        if (debugBool)
        {
            int sdfwe = 0;
        }

        refreshTessellationOnLevel(rootChunkDiv, playerPos);

        refreshMesh();
    }

    private void refreshTessellationOnLevel(LPChunkDiv chunkDiv, Vector2 playerPos)
    {
        // Check desired levels for all 4 potential children

        float distanceToChunk = Vector2.Distance(playerPos, chunkDiv.MidPos);
        int minLevel = (int)(LowPolyTerrain.DivisionDistanceCurve.Evaluate(Mathf.Max(0f, distanceToChunk - chunkDiv.MaxRadius)) * LowPolyTerrain.MaxDivisionPotency);
        int maxLevel = (int)LowPolyTerrain.DivisionDistanceCurve.Evaluate(Mathf.Max(0f, distanceToChunk + chunkDiv.MaxRadius)) * LowPolyTerrain.MaxDivisionPotency;

        chunkDiv.Level = minLevel;
        if (chunkDiv.Level > chunkDiv.Depth)
        {
            chunkDiv.CreateChildren();

            // Needs to check recursively?
            if (chunkDiv.Level > chunkDiv.Depth + 1)
            {
                refreshTessellationOnLevel(chunkDiv.div00, playerPos);
                refreshTessellationOnLevel(chunkDiv.div01, playerPos);
                refreshTessellationOnLevel(chunkDiv.div10, playerPos);
                refreshTessellationOnLevel(chunkDiv.div11, playerPos);
            }
            else
            {
                chunkDiv.EmptyOutChildren();
            }
        }
        else if (minLevel <= chunkDiv.Depth)
        {
            chunkDiv.MakeLeaf();
        }
    }

    private void refreshMesh()
    {
        List<Vector3> verts = new List<Vector3>();
        List<int> trias = new List<int>();
        List<Vector2> uvs = new List<Vector2>();

        refreshMeshRec(rootChunkDiv, verts, trias, uvs);

        meshFilter.mesh = new Mesh();
        meshFilter.mesh.vertices = verts.ToArray();
        meshFilter.mesh.uv = uvs.ToArray();
        meshFilter.mesh.triangles = trias.ToArray();
        meshFilter.mesh.Optimize();
        meshFilter.mesh.RecalculateNormals();
    }

    private void refreshMeshRec(LPChunkDiv chunkDiv, List<Vector3> verts, List<int> trias, List<Vector2> uvs)
    {
        if (chunkDiv.IsBottomLevel)
        {
            verts.Add(new Vector3(chunkDiv.LocalMinPos.x, chunkDiv.CachedHeights[0], chunkDiv.LocalMinPos.y));
            verts.Add(new Vector3(chunkDiv.LocalMinPos.x, chunkDiv.CachedHeights[2], chunkDiv.LocalMaxPos.y));
            verts.Add(new Vector3(chunkDiv.LocalMaxPos.x, chunkDiv.CachedHeights[3], chunkDiv.LocalMaxPos.y));
            verts.Add(new Vector3(chunkDiv.LocalMaxPos.x, chunkDiv.CachedHeights[1], chunkDiv.LocalMinPos.y));

            trias.Add(verts.Count - 4);
            trias.Add(verts.Count - 3);
            trias.Add(verts.Count - 2);
            trias.Add(verts.Count - 4);
            trias.Add(verts.Count - 2);
            trias.Add(verts.Count - 1);

            uvs.Add(new Vector2(chunkDiv.WorldMinPos.x, chunkDiv.WorldMinPos.y));
            uvs.Add(new Vector2(chunkDiv.WorldMinPos.x, chunkDiv.WorldMaxPos.y));
            uvs.Add(new Vector2(chunkDiv.WorldMaxPos.x, chunkDiv.WorldMaxPos.y));
            uvs.Add(new Vector2(chunkDiv.WorldMaxPos.x, chunkDiv.WorldMinPos.y));
        }
        else
        {
            refreshMeshRec(chunkDiv.div00, verts, trias, uvs);
            refreshMeshRec(chunkDiv.div01, verts, trias, uvs);
            refreshMeshRec(chunkDiv.div10, verts, trias, uvs);
            refreshMeshRec(chunkDiv.div11, verts, trias, uvs);
        }
    }
}



/// <summary>
/// 
/// 
/// 
///   10     10
/// 
///   00     01
/// 
/// </summary>
public class LPChunkDiv
{
    public LPChunkDiv div00 = null;
    public LPChunkDiv div01 = null;
    public LPChunkDiv div10 = null;
    public LPChunkDiv div11 = null;

    private Vector2 minPos;
    private Vector2 maxPos;

    private Vector2 leftBottomLocalPos = Vector2.zero;
    private Vector2Int chunkSize;

    public LPChunkDiv(Vector2 minPos, Vector2 maxPos, Vector2 leftBottomLocalPos, Vector2Int chunkSize)
    {
        this.minPos = minPos;
        this.maxPos = maxPos;
        this.chunkSize = chunkSize;
        MidPos = minPos + (maxPos - minPos) * 0.5f;

        IsBottomLevel = true;
        Level = 0;

        this.leftBottomLocalPos = leftBottomLocalPos;
    }


    public void CreateChildren()
    {
        if (IsBottomLevel)
        {
            IsBottomLevel = false;
            div00 = new LPChunkDiv(minPos, minPos + (maxPos - minPos) * 0.5f, leftBottomLocalPos, chunkSize);
            div01 = new LPChunkDiv( new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.5f), Mathf.Lerp(minPos.y, maxPos.y, 0f)),
                                    new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 1f), Mathf.Lerp(minPos.y, maxPos.y, 0.5f)),
                                    leftBottomLocalPos + new Vector2(chunkSize.x / (Mathf.Pow(2f, Depth + 1)), 0f),
                                    chunkSize);
            div10 = new LPChunkDiv(new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0f), Mathf.Lerp(minPos.y, maxPos.y, 0.5f)),
                                    new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.5f), Mathf.Lerp(minPos.y, maxPos.y, 1f)),
                                    leftBottomLocalPos + new Vector2(0f, chunkSize.y / (Mathf.Pow(2f, Depth + 1))),
                                    chunkSize);
            div11 = new LPChunkDiv(new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.5f), Mathf.Lerp(minPos.y, maxPos.y, 0.5f)),
                                    new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 1f), Mathf.Lerp(minPos.y, maxPos.y, 1f)),
                                    leftBottomLocalPos + new Vector2(chunkSize.x / (Mathf.Pow(2f, Depth + 1)), chunkSize.y / (Mathf.Pow(2f, Depth + 1))),
                                    chunkSize);
            div00.Depth = Depth + 1;
            div01.Depth = Depth + 1;
            div10.Depth = Depth + 1;
            div11.Depth = Depth + 1;
        }
    }

    public void EmptyOutChildren()
    {
        if (!IsBottomLevel)
        {
            div00.MakeLeaf();
            div01.MakeLeaf();
            div10.MakeLeaf();
            div11.MakeLeaf();
        }
    }

    public void MakeLeaf()
    {
        IsBottomLevel = true;
        div00 = null;
        div01 = null;
        div10 = null;
        div11 = null;
    }


    public bool IsBottomLevel
    {
        get; set;
    }

    private int level = 0;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    private int depth = 0;
    public int Depth
    {
        get
        {
            return depth;
        }
        set
        {
            depth = value;
            if (!IsBottomLevel)
            {
                div00.Depth = depth + 1;
                div01.Depth = depth + 1;
                div10.Depth = depth + 1;
                div11.Depth = depth + 1;
            }
        }
    }

    public Vector2 PosDiv00
    {
        get
        {
            return new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.25f), Mathf.Lerp(minPos.y, maxPos.y, 0.25f));
        }
    }

    public Vector2 PosDiv01
    {
        get
        {
            return new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.75f), Mathf.Lerp(minPos.y, maxPos.y, 0.25f));
        }
    }

    public Vector2 PosDiv10
    {
        get
        {
            return new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.25f), Mathf.Lerp(minPos.y, maxPos.y, 0.75f));
        }
    }

    public Vector2 PosDiv11
    {
        get
        {
            return new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.75f), Mathf.Lerp(minPos.y, maxPos.y, 0.75f));
        }
    }

    public Vector2 MidPos
    {
        get;set;
    }

    public Vector2 LocalMinPos
    {
        get
        {
            return leftBottomLocalPos;
        }
    }

    public Vector2 WorldMinPos
    {
        get
        {
            return minPos;
        }
    }

    public Vector2 WorldMaxPos
    {
        get
        {
            return maxPos;
        }
    }

    public Vector2 LocalMaxPos
    {
        get
        {
            return leftBottomLocalPos + new Vector2(chunkSize.x / (Mathf.Pow(2f, Depth)), chunkSize.y / (Mathf.Pow(2f, Depth)));
        }
    }

    public float MaxRadius
    {
        get
        {
            return Vector2.Distance(maxPos, minPos) * 0.5f;
        }
    }

    private float[] cachedHeights = null;
    public float[] CachedHeights
    {
        get
        {
            if (cachedHeights == null)
            {
                cachedHeights = new float[4];

                cachedHeights[0] = JobProcGen.snow_mountain_height(minPos.x, minPos.y, null) * 6000f;
                cachedHeights[1] = JobProcGen.snow_mountain_height(maxPos.x, minPos.y, null) * 6000f;
                cachedHeights[2] = JobProcGen.snow_mountain_height(minPos.x, maxPos.y, null) * 6000f;
                cachedHeights[3] = JobProcGen.snow_mountain_height(maxPos.x, maxPos.y, null) * 6000f;
            }

            return cachedHeights;
        }
    }
}