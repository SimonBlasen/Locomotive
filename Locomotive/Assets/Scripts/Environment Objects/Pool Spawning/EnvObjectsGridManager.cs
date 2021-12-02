using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnvObjectsGridManager : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform = null;
    [SerializeField]
    private EnvObjectsManager envObjectsManager = null;
    [SerializeField]
    private int gridsCheckPerTick = 10;
    [SerializeField]
    private int gridsSearchPerTick = 10;
    [SerializeField]
    private float tickInterval = 0.2f;
    [SerializeField]
    private float checkDistance = 1000f;

    private EnvObjectsGridInfo[] grids = null;

    private Dictionary<int, EnvObjectsGrid> cachedGrids = new Dictionary<int, EnvObjectsGrid>();

    private float tickCounter = 0f;
    private Vector3 playerPos = Vector3.zero;

    private int runningGridIndex = 0;

    private List<JobCacheGrid> runningCacheJobs = new List<JobCacheGrid>();

    private void Start()
    {
        loadFiles();
    }

    private void Update()
    {
        tickCounter += Time.deltaTime;

        if (tickCounter >= tickInterval)
        {
            tickCounter = 0f;

            playerPos = playerTransform.position - GlobalOffsetManager.Inst.GlobalOffset;
            tickElements();

            tickRunningCacheJobs();
        }
    }

    private void loadFiles()
    {
        string[] files = Directory.GetFiles("./envobjects");

        List<EnvObjectsGridInfo> gridsList = new List<EnvObjectsGridInfo>();

        for (int i = 0; i < files.Length; i++)
        {
            EnvObjectsGridInfo eogi = new EnvObjectsGridInfo(files[i], envObjectsManager.SqrtElementsPerFile);
            gridsList.Add(eogi);
        }

        grids = gridsList.ToArray();

        Debug.Log("[EnvObjGridMan]: Grid files loaded: " + grids.Length.ToString());
    }

    private void tickRunningCacheJobs()
    {
        for (int i = 0; i < runningCacheJobs.Count; i++)
        {
            if (runningCacheJobs[i].IsDone)
            {
                cachedGrids.Add(runningCacheJobs[i].index, runningCacheJobs[i].envObjectsGrid);
                runningCacheJobs.RemoveAt(i);
                i--;
            }
        }
    }

    private void tickElements()
    {
        int searchesCount = 0;
        for (int c = 0; c < gridsCheckPerTick; c++)
        {
            runningGridIndex++;
            runningGridIndex = runningGridIndex % grids.Length;

            if (grids[runningGridIndex].DistanceToClosestBorder(playerPos) <= checkDistance)
            {
                checkGrid(runningGridIndex, grids[runningGridIndex]);
                searchesCount++;

                if (searchesCount >= gridsSearchPerTick)
                {
                    break;
                }
            }
            else
            {
                deCacheGrid(runningGridIndex);
            }
        }
    }

    private void checkGrid(int index, EnvObjectsGridInfo grid)
    {
        EnvObjectsGrid envObjects = getCachedGrid(index);

        if (envObjects != null)
        {
            for (int i = 0; i < envObjects.spawnObjects1D.Length; i++)
            {
                EnvSpawnObjectInfo objInfo = envObjects.spawnObjects1D[i];

                float lod0Distance = envObjectsManager.ObjectPrefabs[objInfo.objectID].distanceLOD0;
                float lod0DistanceMin = envObjectsManager.ObjectPrefabs[objInfo.objectID].minDistanceLOD0;

                float distanceToPlayer = Vector2.Distance(new Vector2(playerPos.x, playerPos.z), new Vector2(objInfo.pos.x, objInfo.pos.z));
                if (distanceToPlayer <= lod0Distance
                    && distanceToPlayer >= lod0DistanceMin)
                {
                    envObjectsManager.SpawnObject(objInfo, index, i);
                }
                else
                {
                    envObjectsManager.DespawnObject(index, i);
                }
            }
        }
    }

    private void deCacheGrid(int index)
    {
        if (cachedGrids.ContainsKey(index))
        {
            Debug.Log("[EnvObjGridMan]: De-Cached grid [" + index.ToString() + "]");
            cachedGrids.Remove(index);
        }
    }

    private EnvObjectsGrid getCachedGrid(int index)
    {
        if (cachedGrids.ContainsKey(index))
        {
            return cachedGrids[index];
        }
        else
        {
            for (int i = 0; i < runningCacheJobs.Count; i++)
            {
                if (runningCacheJobs[i].index == index)
                {
                    return null;
                }
            }

            JobCacheGrid jobCacheGrid = new JobCacheGrid();
            jobCacheGrid.filePath = grids[index].FilePath;
            jobCacheGrid.index = index;
            jobCacheGrid.Start();
            runningCacheJobs.Add(jobCacheGrid);

            Debug.Log("[EnvObjGridMan]: Cached grid [" + index.ToString() + "]");

            return null;
            //EnvObjectsGrid envObjectsGrid = EnvObjectsGrid.FromBytes(File.ReadAllBytes(grids[index].FilePath));
            //cachedGrids.Add(index, envObjectsGrid);
            //return cachedGrids[index];
        }
    }
}

public class EnvObjectsGridInfo
{
    private string filePath;
    private int gridSize = 0;
    private int sqrtObjects = 0;
    private Vector2Int gridOffset = Vector2Int.zero;

    private Vector2 midWorldPos = Vector2.zero;

    private float diagonalDistance = 0f;

    public EnvObjectsGridInfo(string filepath, int sqrtElementsPerFile)
    {
        this.filePath = filepath;
        sqrtObjects = sqrtElementsPerFile;

        string[] filenameSplit = filepath.Split('_');

        if (filenameSplit.Length >= 2)
        {
            gridOffset = new Vector2Int(System.Convert.ToInt32(filenameSplit[filenameSplit.Length - 3]), System.Convert.ToInt32(filenameSplit[filenameSplit.Length - 2]));
            gridSize = System.Convert.ToInt32(filenameSplit[filenameSplit.Length - 1].Split('.')[0]);

            diagonalDistance = sqrtObjects * gridSize * Mathf.Sqrt(2f);

            midWorldPos = gridOffset * sqrtObjects * gridSize + new Vector2(sqrtObjects * gridSize * 0.5f, sqrtObjects * gridSize * 0.5f);
        }

    }

    public Vector2Int GridOffset
    {
        get
        {
            return gridOffset;
        }
    }

    public int SqrtObjects
    {
        get
        {
            return sqrtObjects;
        }
    }

    public int GridSize
    {
        get
        {
            return gridSize;
        }
    }

    public string FilePath
    {
        get
        {
            return filePath;
        }
    }

    public float DistanceToClosestBorder(Vector3 playerPos)
    {
        Vector2 playerPos2D = new Vector2(playerPos.x, playerPos.z);

        return Mathf.Max(0f, Vector2.Distance(playerPos2D, midWorldPos) - diagonalDistance);
    }
}