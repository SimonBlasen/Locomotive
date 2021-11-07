using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class RailsLODManager : MonoBehaviour
{

    [Header("Making mesh assets")]
    [SerializeField]
    private bool createMeshAssets = false;
    [SerializeField]
    private Transform[] meshAssetsParents = null;
    [SerializeField]
    private string assetsPath = "";

    [Space]

    [Header("Duplicate LOD splines")]
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

    [SerializeField]
    private PairedRailSegmentMesh[] pairedRailSegmentMeshes;


    private int curIndex = 0;



    private void Awake()
    {
        computeMeshes();
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

            computeMeshes();
        }
        if (createMeshAssets)
        {
            createMeshAssets = false;

            createAssetsMesh();
        }
    }



    public PairedRailSegmentMesh[] PairedRailSegmentMeshes
    {
        get
        {
            return pairedRailSegmentMeshes;
        }
    }

    private void createAssetsMesh()
    {
        int genLODs = 0;
        for (int i = 0; i < meshAssetsParents.Length; i++)
        {
            RailSegment[] railSegments = meshAssetsParents[i].GetComponentsInChildren<RailSegment>();

            for (int j = 0; j < railSegments.Length; j++)
            {
                Spline splineChild = railSegments[j].GetComponentInChildren<Spline>();

                if (splineChild != null)
                {
                    MeshFilter[] mfs = splineChild.GetComponentsInChildren<MeshFilter>();
                    
                    for (int k = 0; k < mfs.Length; k++)
                    {
                        AssetDatabase.CreateAsset(mfs[k].sharedMesh, "Assets/" + assetsPath + "/" + genLODs.ToString() + ".asset");

                        Mesh resourcesMesh = (Mesh) Resources.Load(assetsPath + "/" + genLODs.ToString() + ".asset");
                        //mfs[k].mesh = resourcesMesh;

                        genLODs++;
                    }
                }
                else
                {
                    Debug.LogError("No spline child found");
                }

            }
        }

        Debug.Log("Generated " + genLODs.ToString() + " LOD splines");
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

    private void computeMeshes()
    {
        Spline[] allSplines = FindObjectsOfType<Spline>();

        List<PairedRailSegmentMesh> pairedMeshes = new List<PairedRailSegmentMesh>();

        List<Spline> firstSplines = new List<Spline>();
        List<Vector3> cp0 = new List<Vector3>();
        List<Vector3> cp1 = new List<Vector3>();

        for (int i = 0; i < allSplines.Length; i++)
        {
            // Try to find matching first spline

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

                if (splineRail.GetComponentInChildren<SplineMeshTiling>() == false)
                {
                    splineRail = foundFirstSpline;
                    splineLOD = allSplines[i];
                }



                pairedMeshes.AddRange(computePairedMeshes(splineRail, splineLOD));
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