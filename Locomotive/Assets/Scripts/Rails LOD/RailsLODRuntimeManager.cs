using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailsLODRuntimeManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float cycleTime = 5f;
    [SerializeField]
    private int renderDistance = 500;

    [Space]

    [Header("References")]
    [SerializeField]
    private Train train = null;
    [SerializeField]
    private RailsLODManager railsLODManager = null;

    private float waitTime = 0f;
    private PairedRailSegmentsGrid[,] grid;


    private int gridSize = 500;


    private void Awake()
    {
        ExtrusionSegment[] extrusionSegments = FindObjectsOfType<ExtrusionSegment>();
        for (int i = 0; i < extrusionSegments.Length; i++)
        {
            Destroy(extrusionSegments[i]);
        }

        MeshBender[] meshBenders = FindObjectsOfType<MeshBender>();
        for (int i = 0; i < meshBenders.Length; i++)
        {
            Destroy(meshBenders[i]);
        }

        SplineMeshTiling[] splineMeshTilings = FindObjectsOfType<SplineMeshTiling>();
        for (int i = 0; i < splineMeshTilings.Length; i++)
        {
            Destroy(splineMeshTilings[i]);
        }

        SplineExtrusion[] splineExtrusions = FindObjectsOfType<SplineExtrusion>();
        for (int i = 0; i < splineExtrusions.Length; i++)
        {
            Destroy(splineExtrusions[i]);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gridSize = renderDistance * 2;

        int maxPos = 0;
        for (int i = 0; i < railsLODManager.PairedRailSegmentMeshes.Length; i++)
        {
            int posHere = (int)(Mathf.Max(railsLODManager.PairedRailSegmentMeshes[i].worldPos.x, railsLODManager.PairedRailSegmentMeshes[i].worldPos.z) / gridSize);
            if (posHere > maxPos)
            {
                maxPos = posHere;
            }
        }

        grid = new PairedRailSegmentsGrid[maxPos + 1, maxPos + 1];
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                grid[x, y] = new PairedRailSegmentsGrid();
            }
        }

        for (int i = 0; i < railsLODManager.PairedRailSegmentMeshes.Length; i++)
        {
            Vector2Int clampedPos = new Vector2Int((int)(railsLODManager.PairedRailSegmentMeshes[i].worldPos.x / gridSize), (int)(railsLODManager.PairedRailSegmentMeshes[i].worldPos.z / gridSize));
            grid[clampedPos.x, clampedPos.y].tempList.Add(railsLODManager.PairedRailSegmentMeshes[i]);
        }

        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                grid[x, y].pairedRailSegments = grid[x, y].tempList.ToArray();
                grid[x, y].tempList = null;


                for (int i = 0; i < grid[x, y].pairedRailSegments.Length; i++)
                {
                    grid[x, y].pairedRailSegments[i].lodMesh.SetActive(true);
                    grid[x, y].pairedRailSegments[i].railMesh.SetActive(false);
                    grid[x, y].pairedRailSegments[i].railMeshWood.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0f)
        {
            waitTime = cycleTime;
            refreshRailMeshLODs();
        }
    }

    private void refreshRailMeshLODs()
    {
        Vector3 trainPos = train.Locomotive.transform.position - GlobalOffsetManager.Inst.GlobalOffset;

        Vector2Int clampedPos = new Vector2Int((int)(trainPos.x / gridSize), (int)(trainPos.z / gridSize));


        for (int y = clampedPos.y - 1; y <= clampedPos.y + 1; y++)
        {
            for (int x = clampedPos.x - 1; x <= clampedPos.x + 1; x++)
            {
                if (x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1))
                {
                    for (int i = 0; i < grid[x, y].pairedRailSegments.Length; i++)
                    {
                        float distance = Vector3.Distance(trainPos, grid[x, y].pairedRailSegments[i].worldPos);

                        if (distance <= renderDistance && grid[x, y].pairedRailSegments[i].lodMesh.activeSelf)
                        {
                            grid[x, y].pairedRailSegments[i].lodMesh.SetActive(false);
                            grid[x, y].pairedRailSegments[i].railMesh.SetActive(true);
                            grid[x, y].pairedRailSegments[i].railMeshWood.SetActive(true);
                        }
                        else if (distance > renderDistance && grid[x, y].pairedRailSegments[i].lodMesh.activeSelf == false)
                        {
                            grid[x, y].pairedRailSegments[i].lodMesh.SetActive(true);
                            grid[x, y].pairedRailSegments[i].railMesh.SetActive(false);
                            grid[x, y].pairedRailSegments[i].railMeshWood.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
