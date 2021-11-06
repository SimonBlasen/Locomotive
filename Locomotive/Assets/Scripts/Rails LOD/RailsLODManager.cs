using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RailsLODManager : MonoBehaviour
{
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
        if (computeAllMeshes)
        {
            computeAllMeshes = false;

            computeMeshes();
        }
    }



    public PairedRailSegmentMesh[] PairedRailSegmentMeshes
    {
        get
        {
            return pairedRailSegmentMeshes;
        }
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