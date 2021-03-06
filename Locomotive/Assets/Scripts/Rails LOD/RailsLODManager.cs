using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class RailsLODManager : MonoBehaviour
{
    [Header("Re-Generate MeshBend meshes [0]")]
    [SerializeField]
    private bool regenMeshbendMeshes = false;
    [SerializeField]
    private Transform[] regenMeshbendMeshParents = null;

    [Space]

    [Header("Making mesh assets")]
    [SerializeField]
    private bool createMeshAssets = false;
    [SerializeField]
    private Transform[] meshAssetsParents = null;
    [SerializeField]
    private string assetsPath = "";

    [Space]

    [Header("Duplicate LOD splines [1]")]
    [SerializeField]
    private bool createLODSplines = false;
    [SerializeField]
    private Transform[] railSegmentParents = null;
    [SerializeField]
    private Transform railSegLODsParent = null;
    [SerializeField]
    private Material railsLODMaterial = null;


    [Space]

    [Header("Create LOD array data")]
    [SerializeField]
    private bool computeAllMeshes = false;


    [Space]
    [Header("Spline Comp Deleter [2]")]
    [SerializeField]
    private bool deleteSplineComponents = false;
    [SerializeField]
    private Transform[] railMeshesToDelete = null;
    [SerializeField]
    private int deleteIndex = 0;
    [SerializeField]
    private int deleteState = 0;


    [Space]

    [SerializeField]
    private PairedRailSegmentMesh[] pairedRailSegmentMeshes;

    [Space]

    public int genLODs = 0;


    [SerializeField]
    private bool testResources = false;
    [SerializeField]
    private string resPathTest = "";

    private int curIndex = 0;




    private void Awake()
    {
        //ComputeMeshes();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (createLODSplines)
        {
            createLODSplines = false;

            createLODSplinesM();
        }
        if (computeAllMeshes)
        {
            computeAllMeshes = false;

            ComputeMeshes();
        }
        if (createMeshAssets)
        {
            createMeshAssets = false;

            CreateAssetsMesh(meshAssetsParents);
        }
        if (deleteSplineComponents)
        {
            deleteSplineComponents = false;

            DeleteSplineComponentsM(railMeshesToDelete);
        }
        if (regenMeshbendMeshes)
        {
            regenMeshbendMeshes = false;

            RegenMeshbendMeshesM(regenMeshbendMeshParents);
        }
        if (testResources)
        {
            testResources = false;

            Mesh m = (Mesh)Resources.Load(resPathTest);

            Debug.Log(m == null ? "Is Null" : "NOT NULL");

            int fdjksljf = 0;
        }
    }



    public PairedRailSegmentMesh[] PairedRailSegmentMeshes
    {
        get
        {
            return pairedRailSegmentMeshes;
        }
    }


    public void RegenMeshbendMeshesM(Transform[] regenMeshbendMeshParents)
    {
        List<MeshBender> meshBenders = new List<MeshBender>();

        for (int i = 0; i < regenMeshbendMeshParents.Length; i++)
        {
            meshBenders.AddRange(regenMeshbendMeshParents[i].GetComponentsInChildren<MeshBender>());
        }


        for (int i = 0; i < meshBenders.Count; i++)
        {
            meshBenders[i].RegenMesh();
        }
    }

    public void ResetDeletionStates()
    {
        deleteState = 0;
        deleteIndex = 0;
        genLODs = 0;
    }

    public bool DeleteSplineComponentsM(Transform[] railMeshesToDelete, string meshFilePre = "", bool meshify = true, int overrideDeleteState = -1, int overrideDeleteIndex = -1)
    {
        int deleteStateTake = deleteState;
        int deleteIndexTake = deleteIndex;

        if (overrideDeleteState != -1)
        {
            deleteStateTake = overrideDeleteState;
        }
        if (overrideDeleteIndex != -1)
        {
            deleteIndexTake = overrideDeleteIndex;
        }

        if (deleteStateTake == 0)
        {
            for (int i = 0; i < railMeshesToDelete.Length; i++)
            {
                railMeshesToDelete[i].gameObject.SetActive(false);
            }
            if (overrideDeleteState != -1)
            {
                deleteState++;
            }
        }
        else if (deleteStateTake == 1)
        {
            railMeshesToDelete[deleteIndexTake].gameObject.SetActive(true);
            railMeshesToDelete[deleteIndexTake].GetComponentInChildren<Spline>().RefreshCurves();
            if (overrideDeleteState != -1)
            {
                deleteState++;
            }
        }
        else if (deleteStateTake == 2)
        {
            DestroyImmediate(railMeshesToDelete[deleteIndexTake].GetComponentInChildren<SplineExtrusion>());
            if (railMeshesToDelete[deleteIndexTake].GetComponentInChildren<SplineMeshTiling>() != null)
            {
                DestroyImmediate(railMeshesToDelete[deleteIndexTake].GetComponentInChildren<SplineMeshTiling>());
            }

            ExtrusionSegment[] extrusionSegments = railMeshesToDelete[deleteIndexTake].GetComponentsInChildren<ExtrusionSegment>();
            MeshBender[] meshBenders = railMeshesToDelete[deleteIndexTake].GetComponentsInChildren<MeshBender>();
            MeshCollider[] meshColliders = railMeshesToDelete[deleteIndexTake].GetComponentsInChildren<MeshCollider>();

            for (int j = 0; j < extrusionSegments.Length; j++)
            {
                DestroyImmediate(extrusionSegments[j]);
            }
            for (int j = 0; j < meshBenders.Length; j++)
            {
                DestroyImmediate(meshBenders[j]);
            }
            for (int j = 0; j < meshColliders.Length; j++)
            {
                DestroyImmediate(meshColliders[j]);
            }


            if (meshify)
            {
                meshifySpline(railMeshesToDelete[deleteIndexTake].GetComponentInChildren<Spline>(), meshFilePre + "_");
            }

            if (overrideDeleteState != -1)
            {
                deleteState++;
            }
        }
        else if (deleteStateTake == 3)
        {
            railMeshesToDelete[deleteIndexTake].gameObject.SetActive(false);
            if (overrideDeleteIndex != -1)
            {
                deleteIndex++;
            }



            if (overrideDeleteState != -1)
            {
                deleteState = 0;
            }
        }

        if (deleteIndexTake >= railMeshesToDelete.Length)
        {
            return true;
        }
        return false;


    }

    public void CreateAssetsMesh(Transform[] meshAssetsParents)
    {
        for (int i = 0; i < meshAssetsParents.Length; i++)
        {
            RailSegment[] railSegments = meshAssetsParents[i].GetComponentsInChildren<RailSegment>();

            for (int j = 0; j < railSegments.Length; j++)
            {
                Spline splineChild = railSegments[j].GetComponentInChildren<Spline>();

                if (splineChild != null)
                {
                    meshifySpline(splineChild);
                }
                else
                {
                    Debug.LogError("No spline child found");
                }

            }
        }

        Debug.Log("Generated " + genLODs.ToString() + " LOD splines");
    }


    private void meshifySpline(Spline spline, string filenamePre = "")
    {
        MeshFilter[] mfs = spline.GetComponentsInChildren<MeshFilter>();

        for (int k = 0; k < mfs.Length; k++)
        {
            if (mfs[k].sharedMesh != null)
            {
#if UNITY_EDITOR

                AssetDatabase.DeleteAsset("Assets/" + assetsPath + "/" + filenamePre + genLODs.ToString() + ".asset");

                AssetDatabase.CreateAsset(mfs[k].sharedMesh, "Assets/" + assetsPath + "/" + filenamePre + genLODs.ToString() + ".asset");

                Mesh resourcesMesh = (Mesh)Resources.Load(assetsPath.Replace("Resources/", "") + "/" + filenamePre + genLODs.ToString() + "");

                /*
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                MeshFilter mf = go.GetComponent<MeshFilter>();
                Mesh mesh = Instantiate(mf.mesh) as Mesh;
                mf = mfs[k];
                mf.mesh = mesh;
                DestroyImmediate(go);


                */



                mfs[k].mesh = resourcesMesh;

                genLODs++;

#endif
            }
        }
    }


    private void createLODSplinesM()
    {
        int genLODs = 0;
        for (int i = 0; i < railSegmentParents.Length; i++)
        {
            RailSegment[] railSegments = railSegmentParents[i].GetComponentsInChildren<RailSegment>();

            for (int j = 0; j < railSegments.Length; j++)
            {
                Spline splineChild = railSegments[j].GetComponentInChildren<Spline>();

                if (splineChild != null)
                {
                    GameObject duplicated = Instantiate(splineChild.gameObject, railSegLODsParent);

                    GameObject railing = duplicated.GetComponentInChildren<SplineMeshTiling>().gameObject;
                    DestroyImmediate(railing);

                    Spline duplicatedSpline = duplicated.GetComponent<Spline>();
                    SplineExtrusion splineExtrusion = duplicatedSpline.GetComponent<SplineExtrusion>();
                    splineExtrusion.material = railsLODMaterial;
                    splineExtrusion.shapeVertices = new List<ExtrusionSegment.Vertex>();
                    splineExtrusion.shapeVertices.Add(new ExtrusionSegment.Vertex(new Vector2(-1.2f, 0f), new Vector2(0f, 1f), 0f));
                    splineExtrusion.shapeVertices.Add(new ExtrusionSegment.Vertex(new Vector2(1.2f, 0f), new Vector2(0f, 1f), 1f));
                    duplicatedSpline.RefreshCurves();

                    genLODs++;
                }
                else
                {
                    Debug.LogError("No spline child found");
                }

            }
        }

        Debug.Log("Generated " + genLODs.ToString() + " LOD splines");
    }

    public void ComputeMeshes()
    {
        Spline[] allSplines = FindObjectsOfType<Spline>();

        List<PairedRailSegmentMesh> pairedMeshes = new List<PairedRailSegmentMesh>();

        pairedMeshes.AddRange(pairedRailSegmentMeshes);

        List<Spline> firstSplines = new List<Spline>();
        List<Vector3> cp0 = new List<Vector3>();
        List<Vector3> cp1 = new List<Vector3>();

        for (int i = 0; i < allSplines.Length; i++)
        {
            // Try to find matching first spline

            if (allSplines[i].transform.childCount > 0)
            {
                Spline foundFirstSpline = null;
                for (int j = 0; j < firstSplines.Count; j++)
                {
                    if (Vector3.Distance(allSplines[i].nodes[0].Position, firstSplines[j].nodes[0].Position) <= 0.1f
                        && Vector3.Distance(allSplines[i].nodes[1].Position, firstSplines[j].nodes[1].Position) <= 0.1f)
                    {
                        foundFirstSpline = firstSplines[j];
                        break;
                    }
                }

                if (foundFirstSpline == null)
                {
                    firstSplines.Add(allSplines[i]);
                }
                else
                {
                    Spline splineRail = allSplines[i];
                    Spline splineLOD = foundFirstSpline;

                    Transform[] childTrans = splineLOD.GetComponentsInChildren<Transform>();
                    for (int j = 0; j < childTrans.Length; j++)
                    {
                        if (childTrans[j].gameObject.name.Contains("LeftRailing"))
                        {
                            splineRail = foundFirstSpline;
                            splineLOD = allSplines[i];
                            break;
                        }
                    }
                    /*if (splineRail.GetComponentInChildren<SplineMeshTiling>() == false)
                    {
                        splineRail = foundFirstSpline;
                        splineLOD = allSplines[i];
                    }*/



                    pairedMeshes.AddRange(computePairedMeshes(splineRail, splineLOD));
                }
            }

        }


        for (int i = 0; i < pairedMeshes.Count; i++)
        {
            if (pairedMeshes[i].lodMesh == null || pairedMeshes[i].railMesh == null || pairedMeshes[i].railMeshWood == null)
            {
                pairedMeshes.RemoveAt(i);
                i--;
            }
        }






        pairedRailSegmentMeshes = pairedMeshes.ToArray();
    }

    private PairedRailSegmentMesh[] computePairedMeshes(Spline splineRail, Spline splineLOD)
    {
        PairedRailSegmentMesh[] pairedRailSegmentMeshes = new PairedRailSegmentMesh[splineRail.nodes.Count - 1];

        Transform[] allObjectsSplineRail = splineRail.GetComponentsInChildren<Transform>();

        for (int i = 0; i < allObjectsSplineRail.Length; i++)
        {
            if (allObjectsSplineRail[i].name.StartsWith("segment "))
            {
                int meshIndex = Convert.ToInt32(allObjectsSplineRail[i].name.Split(' ')[1]);

                // Wood
                if (allObjectsSplineRail[i].name.EndsWith(" mesh"))
                {
                    pairedRailSegmentMeshes[meshIndex].railMeshWood = allObjectsSplineRail[i].gameObject;
                }

                // Rail
                else
                {
                    pairedRailSegmentMeshes[meshIndex].railMesh = allObjectsSplineRail[i].gameObject;
                }
            }
        }


        Transform[] allObjectsSplineLOD = splineLOD.GetComponentsInChildren<Transform>();

        for (int i = 0; i < allObjectsSplineLOD.Length; i++)
        {
            if (allObjectsSplineLOD[i].name.StartsWith("segment "))
            {
                int meshIndex = Convert.ToInt32(allObjectsSplineLOD[i].name.Split(' ')[1]);

                pairedRailSegmentMeshes[meshIndex].lodMesh = allObjectsSplineLOD[i].gameObject;
            }
        }

        for (int i = 0; i < splineRail.nodes.Count - 1; i++)
        {
            pairedRailSegmentMeshes[i].worldPos = Vector3.Lerp(splineRail.nodes[i].Position, splineRail.nodes[i + 1].Position, 0.5f);
        }


        return pairedRailSegmentMeshes;
    }
}


[Serializable]
public struct PairedRailSegmentMesh
{
    public GameObject railMesh;
    public GameObject railMeshWood;
    public GameObject lodMesh;
    public Vector3 worldPos;
}

public class PairedRailSegmentsGrid
{
    public PairedRailSegmentMesh[] pairedRailSegments;
    public List<PairedRailSegmentMesh> tempList = new List<PairedRailSegmentMesh>();
}