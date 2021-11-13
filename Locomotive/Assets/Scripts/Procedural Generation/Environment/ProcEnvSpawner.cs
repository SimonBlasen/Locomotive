using ProcEnvXNode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProcEnvSpawner : MonoBehaviour
{
    public bool active = false;

    [Space]
    [Header("Generate")]
    public bool generateObjects = false;
    public int seed = 0;
    public Transform generateAreaMin = null;
    public Transform generateAreaMax = null;
    [Space]
    [SerializeField]
    private ProcEnvGraph[] envObjects;


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

                genObjects();
            }
        }
    }


    private void genObjects()
    {
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

            float gridSize = 0f;
            float randomInCell = 0f;

            for (int i = 0; i < graph.nodes.Count; i++)
            {
                if (graph.nodes[i].GetType() == typeof(Spawn))
                {
                    Spawn nodeSpawn = (Spawn)graph.nodes[i];

                    gridSize = nodeSpawn.cellSize;
                    randomInCell = nodeSpawn.randomInCell;

                    break;
                }
            }

            int sizeX = (int)((generateAreaMax.position.x - generateAreaMin.position.x) / gridSize);
            int sizeZ = (int)((generateAreaMax.position.z - generateAreaMin.position.z) / gridSize);

            UnityEngine.Random.InitState(seed);

            for (int z = 0; z < sizeZ; z++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    float randVal = UnityEngine.Random.value;
                    float randVal2 = UnityEngine.Random.value;
                    float randVal3 = UnityEngine.Random.value;
                    float randVal4 = UnityEngine.Random.value;

                    spawnObject(graph, new Vector2(x * gridSize + generateAreaMin.position.x, z * gridSize + generateAreaMin.position.z),
                                    randVal, randVal2, randVal3, randVal4, gridSize, randomInCell, procTerrainGen);
                }
            }


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

    private void spawnObject(ProcEnvGraph graph, Vector2 gridPosition, float randVal, float randVal2, float randVal3, float randVal4, float gridSize, float randomnessInCell, ProcTerrainGen procTerrainGen)
    {
        Vector2 random2DPos = new Vector2(gridPosition.x, gridPosition.y);
        random2DPos += new Vector2(randVal3 * gridSize, randVal4 * gridSize);
        Vector2 midPos = new Vector2(gridPosition.x + gridSize * 0.5f, gridPosition.y + gridSize * 0.5f);
        Vector2 pos2D = Vector2.Lerp(midPos, random2DPos, randomnessInCell);

        float surfaceHeight = 0f;
        Vector3 surfaceNormal = Vector3.zero;

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

                RaycastHit hit;
                if (Physics.Raycast(new Ray(new Vector3(pos2D.x, 10000f, pos2D.y), Vector3.down), out hit, 11000f))
                {
                    nodeSlope.slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
                    surfaceHeight = hit.point.y;
                    surfaceNormal = hit.normal;
                }
                else
                {
                    Debug.LogError("Terrain not hit at: " + pos2D.ToString());
                    nodeSlope.slopeAngle = 0f;
                }
            }
        }

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

            }
        }
    }
}
