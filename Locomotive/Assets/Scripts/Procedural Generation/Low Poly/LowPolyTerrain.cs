using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPolyTerrain : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject prefabTerrainChunk = null;

    [Space]

    [Header("References")]
    [SerializeField]
    private Transform playerTransform = null;

    [Space]

    [Header("Settings")]
    [SerializeField]
    private float maxChunkSpawnDistance = 10000f;
    [SerializeField]
    private Vector2Int chunkSize = new Vector2Int(100, 100);
    [SerializeField]
    private float chunkRefreshRate = 5f;
    [SerializeField]
    private int chunksRefreshAmount = 20;

    [Space]

    [SerializeField]
    private int maxDivisionPotency = 4;
    [SerializeField]
    private AnimationCurve divisionDistanceCurve = null;
    [SerializeField]
    private AnimationCurve refreshTessellationCurveDistance = null;
    [SerializeField]
    private float refreshTessellationTime = 10f;

    [Space]

    [Header("Debug")]
    [SerializeField]
    private bool reInitialize = false;


    private List<LPTerrainChunk> spawnedChunks = new List<LPTerrainChunk>();

    private float checkPlayerPosCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkPlayerPosCounter += Time.deltaTime;

        tickTessellations();

        if (checkPlayerPosCounter >= chunkRefreshRate)
        {
            checkPlayerPosCounter = 0f;
            refreshSpawnedChunks();
        }

        if (reInitialize)
        {
            reInitialize = false;
            reInitializeChunks();
        }
    }

    private void tickTessellations()
    {
        Vector2 playerPosFlat = new Vector2((playerTransform.position - GlobalOffsetManager.Inst.GlobalOffset).x, (playerTransform.position - GlobalOffsetManager.Inst.GlobalOffset).z);
        Vector2 playerPosFlatChunkOffset = playerPosFlat - new Vector2(chunkSize.x * 0.5f, chunkSize.y * 0.5f);

        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            Vector2 chunkPosFlat = spawnedChunks[i].WorldPos;
            float distance = Vector2.Distance(playerPosFlatChunkOffset, chunkPosFlat);

            float timeImpactFactor = refreshTessellationCurveDistance.Evaluate(distance);
            spawnedChunks[i].RefreshTessellationIn -= Time.deltaTime * timeImpactFactor;

            if (spawnedChunks[i].RefreshTessellationIn <= 0f)
            {
                spawnedChunks[i].RefreshTessellationIn = refreshTessellationTime;
                spawnedChunks[i].RefreshTessellation(playerPosFlat);
            }
        }
    }


    private void refreshSpawnedChunks()
    {
        Vector2 playerPosFlat = new Vector2((playerTransform.position - GlobalOffsetManager.Inst.GlobalOffset).x, (playerTransform.position - GlobalOffsetManager.Inst.GlobalOffset).z);
        Vector2 playerPosFlatChunkOffset = playerPosFlat - new Vector2(chunkSize.x * 0.5f, chunkSize.y * 0.5f);
        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            Vector2 chunkPosFlat = spawnedChunks[i].WorldPos;
            float distance = Vector2.Distance(playerPosFlatChunkOffset, chunkPosFlat);

            if (distance > maxChunkSpawnDistance)
            {
                despawnChunk(spawnedChunks[i]);
                i--;
            }
        }

        // If no chunks are loaded, create initial chunk
        if (spawnedChunks.Count == 0)
        {
            Debug.Log("Spawning first initial chunk");

            Vector2Int playerChunk = clampWorldPos(playerPosFlat);

            spawnChunk(playerChunk);
        }


        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            if (spawnedChunks[i].NeighbourChunks[0] == null)
            {
                Vector2 flatChunkPos = spawnedChunks[i].WorldPos + new Vector2(chunkSize.x, 0f);

                if (Vector2.Distance(playerPosFlatChunkOffset, flatChunkPos) <= maxChunkSpawnDistance)
                {
                    spawnChunk(spawnedChunks[i].ChunkPos + new Vector2Int(1, 0));
                }
            }
            if (spawnedChunks[i].NeighbourChunks[1] == null)
            {
                Vector2 flatChunkPos = spawnedChunks[i].WorldPos + new Vector2(0f, -chunkSize.y);

                if (Vector2.Distance(playerPosFlatChunkOffset, flatChunkPos) <= maxChunkSpawnDistance)
                {
                    spawnChunk(spawnedChunks[i].ChunkPos + new Vector2Int(0, -1));
                }
            }
            if (spawnedChunks[i].NeighbourChunks[2] == null)
            {
                Vector2 flatChunkPos = spawnedChunks[i].WorldPos + new Vector2(-chunkSize.x, 0f);

                if (Vector2.Distance(playerPosFlatChunkOffset, flatChunkPos) <= maxChunkSpawnDistance)
                {
                    spawnChunk(spawnedChunks[i].ChunkPos + new Vector2Int(-1, 0));
                }
            }
            if (spawnedChunks[i].NeighbourChunks[3] == null)
            {
                Vector2 flatChunkPos = spawnedChunks[i].WorldPos + new Vector2(0f, chunkSize.y);

                if (Vector2.Distance(playerPosFlatChunkOffset, flatChunkPos) <= maxChunkSpawnDistance)
                {
                    spawnChunk(spawnedChunks[i].ChunkPos + new Vector2Int(0, 1));
                }
            }
        }
    }

    private void reInitializeChunks()
    {
        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            despawnChunk(spawnedChunks[i]);
            i--;
        }

        refreshSpawnedChunks();
    }

    private Vector2Int clampWorldPos(Vector2 pos)
    {
        pos = new Vector2(pos.x / chunkSize.x, pos.y / chunkSize.y);
        if (pos.x < 0f)
        {
            pos.x -= 1f;
        }
        if (pos.y < 0f)
        {
            pos.y -= 1f;
        }

        return new Vector2Int((int)pos.x, (int)pos.y);
    }

    private void spawnChunk(Vector2Int chunkPos)
    {
        GameObject instChunk = Instantiate(prefabTerrainChunk, transform);
        instChunk.transform.position = new Vector3(chunkPos.x * chunkSize.x, 0f, chunkPos.y * chunkSize.y);

        LPTerrainChunk lpTerrainChunk = instChunk.GetComponent<LPTerrainChunk>();
        lpTerrainChunk.LowPolyTerrain = this;
        lpTerrainChunk.ChunkSize = chunkSize;
        lpTerrainChunk.ChunkPos = chunkPos;
        lpTerrainChunk.NeighbourChunks = new LPTerrainChunk[4];

        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            if (spawnedChunks[i].ChunkPos.x + 1 == chunkPos.x && spawnedChunks[i].ChunkPos.y == chunkPos.y)
            {
                spawnedChunks[i].NeighbourChunks[0] = lpTerrainChunk;
                lpTerrainChunk.NeighbourChunks[2] = spawnedChunks[i];
            }
            if (spawnedChunks[i].ChunkPos.x - 1 == chunkPos.x && spawnedChunks[i].ChunkPos.y == chunkPos.y)
            {
                spawnedChunks[i].NeighbourChunks[2] = lpTerrainChunk;
                lpTerrainChunk.NeighbourChunks[0] = spawnedChunks[i];
            }
            if (spawnedChunks[i].ChunkPos.x == chunkPos.x && spawnedChunks[i].ChunkPos.y + 1 == chunkPos.y)
            {
                spawnedChunks[i].NeighbourChunks[3] = lpTerrainChunk;
                lpTerrainChunk.NeighbourChunks[1] = spawnedChunks[i];
            }
            if (spawnedChunks[i].ChunkPos.x == chunkPos.x && spawnedChunks[i].ChunkPos.y - 1 == chunkPos.y)
            {
                spawnedChunks[i].NeighbourChunks[1] = lpTerrainChunk;
                lpTerrainChunk.NeighbourChunks[3] = spawnedChunks[i];
            }
        }

        GlobalOffsetTransform got = instChunk.AddComponent<GlobalOffsetTransform>();

        spawnedChunks.Add(lpTerrainChunk);
    }

    public int MaxDivisionPotency
    {
        get
        {
            return maxDivisionPotency;
        }
    }

    public AnimationCurve DivisionDistanceCurve
    {
        get
        {
            return divisionDistanceCurve;
        }
    }


    private void despawnChunk(LPTerrainChunk chunk)
    {
        // Set all neighbour chunks neighbours to null, where the chunk was referenced
        for (int i = 0; i < chunk.NeighbourChunks.Length; i++)
        {
            if (chunk.NeighbourChunks[i] != null)
            {
                for (int j = 0; j < chunk.NeighbourChunks[i].NeighbourChunks.Length; j++)
                {
                    if (chunk.NeighbourChunks[i].NeighbourChunks[j] == chunk)
                    {
                        chunk.NeighbourChunks[i].NeighbourChunks[j] = null;
                    }
                }
            }
        }

        spawnedChunks.Remove(chunk);
        Destroy(chunk.gameObject);
    }
}
