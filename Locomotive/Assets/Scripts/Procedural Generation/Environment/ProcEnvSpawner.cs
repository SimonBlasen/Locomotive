using ProcEnvXNode;
using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[ExecuteInEditMode]
public class ProcEnvSpawner : MonoBehaviour
{
    public bool active = false;

    [Space]
    [Header("Generate")]
    public bool generateObjects = false;
    public int seed = 0;
    public int maxObjects = 0;
    public Transform generateAreaMin = null;
    public Transform generateAreaMax = null;
    [Space]
    [SerializeField]
    private ProcEnvGraph[] envObjects;

    [Space]
    [Header("Generate")]
    public Spline[] toConsiderSplines = null;
    public bool computeDistancesToRails = false;
    public bool writeoutDistancefield = false;
    public bool loadDistanceToRailsFromFile = false;

    [Space]
    [Header("Store grid")]
    public bool storeInFile = false;
    public int fileID = -1;


    private Spline[] railSegmentsCached = null;

    private EnvObjectsManager envObjectsManager;

    private ProcEnvRailsDistance procEnvRailsDistance = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (generateObjects)
            {
                generateObjects = false;

                envObjectsManager = FindObjectOfType<EnvObjectsManager>();

                RailSegment[] railSegmentsCachedRS = FindObjectsOfType<RailSegment>();
                railSegmentsCached = new Spline[railSegmentsCachedRS.Length];
                for (int i = 0; i < railSegmentsCachedRS.Length; i++)
                {
                    railSegmentsCached[i] = railSegmentsCachedRS[i].GetComponentInChildren<Spline>();
                }
                genObjects(false);

                railSegmentsCached = null;
            }

            if (computeDistancesToRails)
            {
                computeDistancesToRails = false;

                procEnvRailsDistance = new ProcEnvRailsDistance();
                RailSegment[] railSegments = FindObjectsOfType<RailSegment>();
                List<Spline> splines = new List<Spline>();
                for (int i = 0; i < railSegments.Length; i++)
                {
                    if (railSegments[i].GetComponentInChildren<Spline>() != null)
                    {
                        Spline spline = railSegments[i].GetComponentInChildren<Spline>();
                        if (spline.gameObject.activeInHierarchy)
                        {
                            splines.Add(spline);
                        }
                    }
                }

                if (toConsiderSplines == null || toConsiderSplines.Length <= 0)
                {
                    procEnvRailsDistance.ComputeDistancefield(splines.ToArray());
                }
                else
                {
                    procEnvRailsDistance.ComputeDistancefield(toConsiderSplines);
                }

                //byte[] bytes = procEnvRailsDistance.ToBytes();
                //File.WriteAllBytes("./envobjects/railsDistances.perd", bytes);

                Debug.Log("Computed distance field");
            }
            if (writeoutDistancefield)
            {
                writeoutDistancefield = false;

                byte[] bytes = procEnvRailsDistance.ToBytes();
                File.WriteAllBytes("./envobjects/railsDistances.perd", bytes);

                Debug.Log("Written out distance to rails file");
            }
            if (loadDistanceToRailsFromFile)
            {
                loadDistanceToRailsFromFile = false;

                procEnvRailsDistance = ProcEnvRailsDistance.FromBytes(File.ReadAllBytes("./envobjects/railsDistances.perd"));

                Debug.Log("Loaded distance to rails file");
            }

            if (storeInFile)
            {
                storeInFile = false;

                envObjectsManager = FindObjectOfType<EnvObjectsManager>();

                if (fileID == -1)
                {
                    Debug.LogError("File ID was -1");
                }
                else
                {
                    if (generateAreaMin.position.x > 0.01f || generateAreaMin.position.y > 0.01f || generateAreaMin.position.z > 0.01f)
                    {
                        Debug.LogError("Min pos is not at (0,0,0)");
                    }
                    else
                    {
                        if (File.Exists("./envobjects/envobjectsgrid" + fileID.ToString() + ".eog"))
                        {
                            Debug.LogError("File already exsits");
                        }
                        else
                        {
                            genObjects(true);
                        }
                    }
                }
            }
        }
    }

    private void genObjects(bool onlyWriteDatastructure)
    {

        int maxObjectsCounter = 0;
        ProcTerrainGen procTerrainGen = FindObjectOfType<ProcTerrainGen>();

        if (procTerrainGen == null)
        {
            Debug.LogError("ProcTerrainGen not found");
        }

        Transform[] children = new Transform[transform.childCount];
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = transform.GetChild(i);
        }

        for (int i = 0; i < children.Length; i++)
        {
            DestroyImmediate(children[i].gameObject);
        }

        //TOOD
        // AreaType.areaWeights
        // Slope.slopeAngle
        /*
        for (int g = 0; g < envObjects.Length; g++)
        {
            ProcEnvGraph graph = envObjects[g];

            for (int i = 0; i < graph.nodes.Count; i++)
            {
                if (graph.nodes[i].GetType() == typeof(AreaType))
                {
                    AreaType nodeAreaType = (AreaType)graph.nodes[i];
                    
                    nodeAreaType.areaWeights
                }
            }

            Debug.Log("Output val: " + outputProb);
        }*/


        for (int g = 0; g < envObjects.Length; g++)
        {
            ProcEnvGraph graph = envObjects[g];

            int gridSize = 0;
            float randomInCell = 0f;

            for (int i = 0; i < graph.nodes.Count; i++)
            {
                if (graph.nodes[i].GetType() == typeof(Spawn))
                {
                    Spawn nodeSpawn = (Spawn)graph.nodes[i];

                    gridSize = nodeSpawn.cellSize;
                    randomInCell = nodeSpawn.randomOffset;

                    break;
                }
            }


            int sizeX = (int)((generateAreaMax.position.x - generateAreaMin.position.x) / gridSize);
            int sizeZ = (int)((generateAreaMax.position.z - generateAreaMin.position.z) / gridSize);


            UnityEngine.Random.InitState(seed);

            for (int zOffset = 0; zOffset * envObjectsManager.SqrtElementsPerFile < sizeZ; zOffset++)
            {
                for (int xOffset = 0; xOffset * envObjectsManager.SqrtElementsPerFile < sizeX; xOffset++)
                {
                    List<EnvSpawnObjectInfo> objectsInfoList = new List<EnvSpawnObjectInfo>();

                    EnvObjectsGrid eog = new EnvObjectsGrid();
                    eog.gridSize = gridSize;
                    //eog.spawnObjects = new EnvSpawnObjectInfo[envObjectsManager.SqrtElementsPerFile, envObjectsManager.SqrtElementsPerFile];
                    eog.gridOffsetX = xOffset;
                    eog.gridOffsetZ = zOffset;


                    for (int z = 0; z < envObjectsManager.SqrtElementsPerFile; z++)
                    {
                        for (int x = 0; x < envObjectsManager.SqrtElementsPerFile; x++)
                        {
                            float randVal = UnityEngine.Random.value;
                            float randVal2 = UnityEngine.Random.value;
                            float randVal3 = UnityEngine.Random.value;
                            float randVal4 = UnityEngine.Random.value;

                            bool hasSpawned = spawnObject(onlyWriteDatastructure, objectsInfoList, eog, new Vector2Int(x, z), graph,
                                new Vector2((x + xOffset * envObjectsManager.SqrtElementsPerFile) * gridSize + generateAreaMin.position.x, (z + zOffset * envObjectsManager.SqrtElementsPerFile) * gridSize + generateAreaMin.position.z),
                                            randVal, randVal2, randVal3, randVal4, gridSize, randomInCell, procTerrainGen);

                            if (hasSpawned)
                            {
                                if (!onlyWriteDatastructure)
                                {
                                    maxObjectsCounter++;
                                    if (maxObjectsCounter > maxObjects)
                                    {
                                        Debug.LogError("Max objects reached");
                                        return;
                                    }
                                }

                            }
                        }
                    }

                    eog.spawnObjects1D = objectsInfoList.ToArray();

                    File.WriteAllBytes("./envobjects/envobjectsgrid" + fileID.ToString()
                                                                    + "_" + xOffset.ToString() + "_" + zOffset.ToString()
                                                                    + "_" + gridSize.ToString()
                                                                    + ".eog", eog.ToBytes());
                }
            }

            fileID++;

            float outputProb = 0f;

            for (int i = 0; i < graph.nodes.Count; i++)
            {
                if (graph.nodes[i].GetType() == typeof(Spawn))
                {
                    outputProb = (float)graph.nodes[i].GetValue(graph.nodes[i].GetOutputPort("output"));
                    //break;
                }
            }

            Debug.Log("Output val: " + outputProb);
        }
    }

    private bool spawnObject(bool onlyWriteDataStructure, List<EnvSpawnObjectInfo> objectsInfoList, EnvObjectsGrid eog, Vector2Int intPos, ProcEnvGraph graph, Vector2 gridPosition, float randVal, float randVal2, float randVal3, float randVal4, float gridSize, float randomnessInCell, ProcTerrainGen procTerrainGen)
    {
        Vector2 random2DPos = new Vector2(gridPosition.x, gridPosition.y);
        random2DPos += new Vector2(randVal3 * gridSize, randVal4 * gridSize);
        Vector2 midPos = new Vector2(gridPosition.x + gridSize * 0.5f, gridPosition.y + gridSize * 0.5f);
        Vector2 pos2D = Vector2.Lerp(midPos, random2DPos, randomnessInCell);

        float surfaceHeight = 0f;
        Vector3 surfaceNormal = Vector3.zero;

        Vector3 raycastHitPos = Vector3.zero;


        RaycastHit hit;
        if (Physics.Raycast(new Ray(new Vector3(pos2D.x, 10000f, pos2D.y), Vector3.down), out hit, 11000f))
        {
            // Always make raycast
            //nodeSlope.slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
            raycastHitPos = hit.point;
            surfaceHeight = hit.point.y;
            surfaceNormal = hit.normal;
        }
        else
        {
            Debug.LogError("Terrain not hit at: " + pos2D.ToString());
            //nodeSlope.slopeAngle = 0f;
        }

        for (int i = 0; i < graph.nodes.Count; i++)
        {
            if (graph.nodes[i].GetType() == typeof(AreaType))
            {
                AreaType nodeAreaType = (AreaType)graph.nodes[i];

                nodeAreaType.areaWeights = procTerrainGen.GetAreaWeights(pos2D);
            }
            else if (graph.nodes[i].GetType() == typeof(Slope))
            {
                Slope nodeSlope = (Slope)graph.nodes[i];

                nodeSlope.slopeAngle = Vector3.Angle(surfaceNormal, Vector3.up);
            }
            else if (graph.nodes[i].GetType() == typeof(ProcEnvXNode.Texture))
            {
                ProcEnvXNode.Texture nodeTexture = (ProcEnvXNode.Texture)graph.nodes[i];

                nodeTexture.gridPos = gridPosition;
            }
            else if (graph.nodes[i].GetType() == typeof(RailsDistance))
            {
                RailsDistance nodeRailDistance = (RailsDistance)graph.nodes[i];

                float distance = getDistanceToRailSpline(gridPosition);

                if (distance <= 1000f)
                {
                    int fdsfew = 0;
                    fdsfew++;
                }

                nodeRailDistance.distanceFromRail = distance;
            }
        }

        bool hasSpawned = false;
        for (int i = 0; i < graph.nodes.Count; i++)
        {
            if (graph.nodes[i].GetType() == typeof(Spawn))
            {
                float outputProb = (float)graph.nodes[i].GetValue(graph.nodes[i].GetOutputPort("output"));
                ObjectVariantData[] objectVariants = (ObjectVariantData[])graph.nodes[i].GetValue(graph.nodes[i].GetOutputPort("outputObjectVariants"));

                float occSum = 0f;
                float[] occurencesSummed = new float[objectVariants.Length];
                for (int j = 0; j < objectVariants.Length; j++)
                {
                    occSum += objectVariants[j].occurence;
                    occurencesSummed[j] = occSum;
                }

                randVal2 *= occSum;

                int takeVariant = 0;
                for (int j = 1; j < objectVariants.Length; j++)
                {
                    if (randVal2 >= occurencesSummed[j - 1] && randVal2 < occurencesSummed[j])
                    {
                        takeVariant = j;
                        break;
                    } 
                }

                ObjectVariantData variant = objectVariants[takeVariant];


                if (randVal <= outputProb)
                {
                    hasSpawned = true;

                    if (!onlyWriteDataStructure)
                    {
                        GameObject instObject = Instantiate(variant.prefab, transform);
                        instObject.transform.position = new Vector3(pos2D.x, surfaceHeight, pos2D.y);
                        instObject.transform.up = Vector3.Lerp(Vector3.up, surfaceNormal, variant.adjustToSlope);
                        instObject.transform.Rotate(0f, variant.rotY, 0f, Space.Self);
                        instObject.transform.localScale = new Vector3(variant.scaleX, variant.scaleY, variant.scaleZ);
                        instObject.transform.position += instObject.transform.up.normalized * variant.offsetY;

                        if (variant.randomRot)
                        {
                            instObject.transform.rotation = Quaternion.Euler(randVal * 360f, randVal2 * 360f, randVal3 * 360f);
                        }
                    }
                    else
                    {
                        EnvSpawnObjectInfo esoi = new EnvSpawnObjectInfo();

                        esoi.objectID = envObjectsManager.GetObjectID(variant.prefab);
                        esoi.pos = new Vector3(pos2D.x, surfaceHeight, pos2D.y);
                        esoi.upVec = Vector3.Lerp(Vector3.up, surfaceNormal, variant.adjustToSlope);
                        esoi.yRot = variant.rotY;
                        esoi.scale = new Vector3(variant.scaleX, variant.scaleY, variant.scaleZ);
                        esoi.pos += esoi.upVec.normalized * variant.offsetY;
                        if (variant.randomRot)
                        {
                            esoi.rot = new Vector3(randVal * 360f, randVal2 * 360f, randVal3 * 360f);
                            esoi.yRot = 0f;
                            esoi.upVec = Vector3.zero;
                        }
                        else
                        {
                            esoi.rot = Vector3.zero;
                        }
                        objectsInfoList.Add(esoi);
                    }
                }

            }
        }

        return hasSpawned;
    }

    private float getDistanceToRailSpline(Vector2 pos)
    {
        return procEnvRailsDistance.DistanceToRails(pos);
        /*
        for (int i = 0; i < railSegmentsCached.Length; i++)
        {
            for (int n = 0; n < railSegmentsCached[i].nodes.Count; n++)
            {

            }
        }

        return 0f;*/
    }
}
