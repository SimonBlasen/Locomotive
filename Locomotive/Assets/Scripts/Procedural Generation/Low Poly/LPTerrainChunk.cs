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
        rootChunkDiv = new LPChunkDiv(WorldPos, WorldPos + ChunkSize);
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

    public void RefreshTessellation(Vector2 playerPos)
    {
        refreshTessellationOnLevel(0, playerPos);
    }

    private void refreshTessellationOnLevel(LPChunkDiv chunkDiv, Vector2 playerPos)
    {
        // Check desired levels for all 4 potential children

        float distanceToChunk = Vector2.Distance(playerPos, chunkDiv.MidPos);
        int minLevel = (int)LowPolyTerrain.DivisionDistanceCurve.Evaluate(Mathf.Max(0f, distanceToChunk - chunkDiv.MaxRadius)) * LowPolyTerrain.MaxDivisionPotency;
        int maxLevel = (int)LowPolyTerrain.DivisionDistanceCurve.Evaluate(Mathf.Max(0f, distanceToChunk + chunkDiv.MaxRadius)) * LowPolyTerrain.MaxDivisionPotency;
        
        // 
        if (minLevel > chunkDiv.Level)
        {
            chunkDiv.Level = minLevel;
            if (chunkDiv.Level > chunkDiv.Depth)
            {

            }
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

    public LPChunkDiv(Vector2 minPos, Vector2 maxPos)
    {
        this.minPos = minPos;
        this.maxPos = maxPos;
        MidPos = minPos + (maxPos - minPos) * 0.5f;

        IsBottomLevel = true;
        Level = 0;
    }


    public void CreateChildren()
    {
        if (IsBottomLevel)
        {
            IsBottomLevel = false;
            div00 = new LPChunkDiv(minPos, minPos + (maxPos - minPos) * 0.5f);
            div01 = new LPChunkDiv( new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.5f), Mathf.Lerp(minPos.y, maxPos.y, 0f)),
                                    new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 1f), Mathf.Lerp(minPos.y, maxPos.y, 0.5f)));
            div10 = new LPChunkDiv(new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0f), Mathf.Lerp(minPos.y, maxPos.y, 0.5f)),
                                    new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.5f), Mathf.Lerp(minPos.y, maxPos.y, 1f)));
            div11 = new LPChunkDiv(new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 0.5f), Mathf.Lerp(minPos.y, maxPos.y, 0.5f)),
                                    new Vector2(Mathf.Lerp(minPos.x, maxPos.x, 1f), Mathf.Lerp(minPos.y, maxPos.y, 1f)));
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

    public float MaxRadius
    {
        get
        {
            return Vector2.Distance(maxPos, minPos) * 0.5f;
        }
    }
}