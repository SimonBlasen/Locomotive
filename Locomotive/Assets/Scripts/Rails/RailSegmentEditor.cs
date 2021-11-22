using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[ExecuteInEditMode]
public class RailSegmentEditor : MonoBehaviour
{
    [SerializeField]
    private bool active = false;
    [Space]

    private const string folderPath = "./railsegments/";

    [SerializeField]
    private uint railSegmentID = 0;
    [Space]
    [SerializeField]
    private bool adjustTerrain = false;
    [SerializeField]
    private Terrain[] consideredTerrains = null;
    [Space]
    [SerializeField]
    private bool generateMeshes = false;
    [SerializeField]
    private bool tickLODManager = false;
    [Space]
    [SerializeField]
    private bool connectSplines = false;

    [Space]


    [SerializeField]
    private Spline shapeSpline = null;

    private GameObject instHighPolySpline = null;
    private GameObject instLODSpline = null;


    private bool wasTerrainAdjusted = false;
    private bool wereMeshesGenerated = false;

    private GameObject originalSplineHighPoly = null;
    private GameObject originalSplineLOD = null;

    private TerrainOriginals[] terrainOriginals = null;

    private float waitDelCounter = 0f;


    [Space]
    [Header("Info")]
    public bool waitingForSplineCompDeletion = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && !Application.isPlaying && active)
        {
            if (originalSplineHighPoly == null)
            {
                originalSplineHighPoly = Resources.Load<GameObject>("RailSegments/RailSegmentHighPoly");
            }
            if (originalSplineLOD == null)
            {
                originalSplineLOD = Resources.Load<GameObject>("RailSegments/RailSegmentLOD");
            }

            if (adjustTerrain != wasTerrainAdjusted)
            {
                wasTerrainAdjusted = adjustTerrain;

                if (adjustTerrain)
                {
                    adjustTerrainNow();
                }
                else
                {
                    resetTerrain();
                }
            }


            if (generateMeshes != wereMeshesGenerated)
            {
                wereMeshesGenerated = generateMeshes;

                if (generateMeshes)
                {
                    generateMeshesNow();
                }
                else
                {
                    destroyMeshes();
                }
            }

            //if (generateMeshes && waitingForSplineCompDeletion)
            if (tickLODManager)
            {
                tickLODManager = false;
                tickRailLODCompDel();
            }


            if (connectSplines)
            {
                connectSplines = false;

                connectSplineNow();
            }

            if (railSegmentID == 0)
            {
                generatedRandomRailsegmentID();
            }
        }
        
        if (!active && Application.isEditor && !Application.isPlaying)
        {
            wasTerrainAdjusted = adjustTerrain;
            wereMeshesGenerated = generateMeshes;
            tickLODManager = false;
            connectSplines = false;
        }
        
    }


    private void tickRailLODCompDel()
    {
        if (waitingForSplineCompDeletion)
        {
            waitDelCounter = 0.1f;
            RailsLODManager lodMan = FindObjectOfType<RailsLODManager>();
            bool isDone = lodMan.DeleteSplineComponentsM(new Transform[] { instHighPolySpline.transform, instLODSpline.transform }, railSegmentID.ToString());

            if (isDone)
            {
                instHighPolySpline.SetActive(true);
                instLODSpline.SetActive(true);

                lodMan.ComputeMeshes();


                Spline hpSpline = instHighPolySpline.GetComponentInChildren<Spline>();
                Spline lodSpline = instLODSpline.GetComponentInChildren<Spline>();

                DestroyImmediate(hpSpline);
                DestroyImmediate(lodSpline);


                waitingForSplineCompDeletion = false;
                Debug.Log("Done");
            }
        }
    }


    private void generateMeshesNow()
    {
        RailsLODManager lodMan = FindObjectOfType<RailsLODManager>();

        if (instHighPolySpline == null)
        {
            instHighPolySpline = Instantiate(originalSplineHighPoly, transform);
            instHighPolySpline.transform.position = Vector3.zero;
            instLODSpline = Instantiate(originalSplineLOD, transform);
            instLODSpline.transform.position = Vector3.zero;

            Spline splineHP = instHighPolySpline.GetComponentInChildren<Spline>();
            Spline splineLOD = instLODSpline.GetComponentInChildren<Spline>();
            copySplineNodes(shapeSpline, splineHP);
            copySplineNodes(shapeSpline, splineLOD);

            splineHP.RefreshCurves();
            splineLOD.RefreshCurves();
            
            lodMan.RegenMeshbendMeshesM(new Transform[] { instHighPolySpline.transform });

            lodMan.ResetDeletionStates();

            waitingForSplineCompDeletion = true;
            waitDelCounter = 0.1f;
        }
    }

    private void destroyMeshes()
    {
        if (instHighPolySpline != null)
        {
            DestroyImmediate(instHighPolySpline);
        }
        if (instLODSpline != null)
        {
            DestroyImmediate(instLODSpline);
        }
    }


    private void connectSplineNow()
    {
        SplineConnector splineConnector = FindObjectOfType<SplineConnector>();

        Spline[] allSplines = FindObjectsOfType<Spline>();
        for (int i = 0; i < allSplines.Length; i++)
        {
            if (allSplines[i].GetInstanceID() != shapeSpline.GetInstanceID())
            {
                splineConnector.ConnectSplines(allSplines[i], shapeSpline, 5f);
            }
        }
    }

    private void resetTerrain()
    {
        deserializeTerrain(File.ReadAllBytes(OwnFilepathTerrain));
        //deserialize(File.ReadAllBytes(OwnFilepath));

        if (terrainOriginals != null && terrainOriginals.Length > 0)
        {
            int hmRes = consideredTerrains[0].terrainData.heightmapResolution;

            for (int i = 0; i < consideredTerrains.Length; i++)
            {
                float[,] originTerrainHeights = consideredTerrains[i].terrainData.GetHeights(0, 0, hmRes, hmRes);

                for (int x = 0; x < hmRes; x++)
                {
                    for (int y = 0; y < hmRes; y++)
                    {
                        if (terrainOriginals[i].deltaHeights[x, y] != -1f)
                        {
                            originTerrainHeights[x, y] = terrainOriginals[i].deltaHeights[x, y];
                        }
                    }
                }
                consideredTerrains[i].terrainData.SetHeights(0, 0, originTerrainHeights);
            }

            terrainOriginals = null;
            File.WriteAllBytes(OwnFilepathTerrain, serializeTerrain());
        }
    }

    private void adjustTerrainNow()
    {
        if (File.Exists(OwnFilepathTerrain))
        {
            deserializeTerrain(File.ReadAllBytes(OwnFilepathTerrain));
        }

        if (terrainOriginals == null || terrainOriginals.Length == 0)
        {
            TerrainLevelerSpline tls = FindObjectOfType<TerrainLevelerSpline>();

            terrainOriginals = new TerrainOriginals[consideredTerrains.Length];

            for (int i = 0; i < consideredTerrains.Length; i++)
            {
                float[,] deltaHeights = tls.LevelTerrain(shapeSpline, consideredTerrains[i]);
                terrainOriginals[i] = new TerrainOriginals();
                terrainOriginals[i].deltaHeights = deltaHeights;
            }

            File.WriteAllBytes(OwnFilepathTerrain, serializeTerrain());
        }
    }


    private void generatedRandomRailsegmentID()
    {
        bool alreadyExists = true;

        while (railSegmentID == 0 || alreadyExists)
        {
            System.Random rand = new System.Random();
            uint thirtyBits = (uint)rand.Next(1 << 30);
            uint twoBits = (uint)rand.Next(1 << 2);
            uint fullRange = (thirtyBits << 2) | twoBits;
            railSegmentID = fullRange;

            alreadyExists = File.Exists(OwnFilepathTerrain);
        }

        File.WriteAllBytes(OwnFilepathTerrain, serializeTerrain());
    }


    private void copySplineNodes(Spline splineFrom, Spline splineTo)
    {
        while (splineTo.nodes.Count > 2)
        {
            splineTo.RemoveNode(splineTo.nodes[0]);
        }


        for (int i = 0; i < splineFrom.nodes.Count; i++)
        {
            Vector3 pos = splineFrom.nodes[i].Position;
            Vector3 dir = splineFrom.nodes[i].Direction;
            if (i >= splineTo.nodes.Count)
            {
                splineTo.AddNode(new SplineNode(pos, dir));
            }
            else
            {
                splineTo.nodes[i].Position = pos;
                splineTo.nodes[i].Direction = dir;
            }
        }
    }

    private string OwnFilepath
    {
        get
        {
            return folderPath + railSegmentID.ToString() + ".rs";
        }
    }

    private string OwnFilepathTerrain
    {
        get
        {
            return folderPath + railSegmentID.ToString() + "_terrain.rs";
        }
    }
    /*
    private byte[] serialize()
    {
        List<string> lines = new List<string>();

        string longLine = "";
        
        if (terrainOriginals != null)
        {
            for (int i = 0; i < terrainOriginals.Length; i++)
            {
                lines.Add("[TerrainOriginal]_" + i.ToString());
                lines.Add(terrainOriginals[i].deltaHeights.GetLength(0).ToString());
                lines.Add(terrainOriginals[i].deltaHeights.GetLength(1).ToString());

                for (int y = 0; y < terrainOriginals[i].deltaHeights.GetLength(1); y++)
                {
                    for (int x = 0; x < terrainOriginals[i].deltaHeights.GetLength(0); x++)
                    {
                        lines.Add(System.Convert.ToString(terrainOriginals[i].deltaHeights[x, y]));
                    }
                }

                lines.Add("[/TerrainOriginal]");
            }
        }


        longLine = lines[0];
        for (int i = 0; i < lines.Count; i++)
        {
            longLine += "|" + lines[i];
        }

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(longLine);

        byte[] compressed = GZip.Compress(bytes);

        return compressed;
    }*/

    private byte[] serializeTerrain()
    {
        List<byte> bytes = new List<byte>();
        if (terrainOriginals != null)
        {
            for (int i = 0; i < terrainOriginals.Length; i++)
            {
                bytes.AddRange(BitConverter.GetBytes(i));
                for (int y = 0; y < terrainOriginals[i].deltaHeights.GetLength(1); y++)
                {
                    for (int x = 0; x < terrainOriginals[i].deltaHeights.GetLength(0); x++)
                    {
                        bytes.AddRange(BitConverter.GetBytes(terrainOriginals[i].deltaHeights[x, y]));
                    }
                }
            }
        }

        byte[] bytesC = GZip.Compress(bytes.ToArray());
        return bytesC;
        //return bytes.ToArray();
    }

    private void deserializeTerrain(byte[] bytesC)
    {
        byte[] bytes = GZip.Decompress(bytesC);

        int hmRes = consideredTerrains[0].terrainData.heightmapResolution;
        if (bytes.Length >= 4)
        {
            List<TerrainOriginals> terrainOriginalsNew = new List<TerrainOriginals>();
            List<int> terrainOriginalsNewIndices = new List<int>();

            int byteIndex = 0;
            while (byteIndex < bytes.Length)
            {
                TerrainOriginals to = new TerrainOriginals();
                to.deltaHeights = new float[hmRes, hmRes];
                int index = BitConverter.ToInt32(bytes, byteIndex);
                for (int y = 0; y < hmRes; y++)
                {
                    for (int x = 0; x < hmRes; x++)
                    {
                        to.deltaHeights[x, y] = BitConverter.ToSingle(bytes, byteIndex + 4 + x * 4 + y * 4 * hmRes);
                    }
                }

                terrainOriginalsNew.Add(to);
                terrainOriginalsNewIndices.Add(index);
                byteIndex += hmRes * hmRes * 4 + 4;
            }

            terrainOriginals = new TerrainOriginals[terrainOriginalsNew.Count];

            for (int i = 0; i < terrainOriginals.Length; i++)
            {
                terrainOriginals[terrainOriginalsNewIndices[i]] = terrainOriginalsNew[i];
            }
        }
    }
    /*
    private void deserialize(byte[] bytes)
    {
        byte[] decompressed = GZip.Decompress(bytes);

        string longLine = System.Text.Encoding.UTF8.GetString(decompressed);
        string[] lines = longLine.Split('|');

        int index = 0;

        List<TerrainOriginals> terrainOriginalsNew = new List<TerrainOriginals>();
        List<int> terrainOriginalsNewIndices = new List<int>();

        while (index < lines.Length)
        {
            if (lines[index].StartsWith("[TerrainOriginal]_"))
            {
                TerrainOriginals to = new TerrainOriginals();
                int origIndex = Convert.ToInt32(lines[index].Split('_')[1]);

                int xLen = Convert.ToInt32(lines[index + 1]);
                int yLen = Convert.ToInt32(lines[index + 2]);

                float[,] deltaHeights = new float[xLen, yLen];

                for (int i = 0; i < xLen * yLen; i++)
                {
                    deltaHeights[i % xLen, i / xLen] = Convert.ToSingle(lines[index + 3 + i]);
                }

                index += xLen * yLen + 3;

                // For the [/TerrainOriginal]
                index++;

                to.deltaHeights = deltaHeights;
                terrainOriginalsNew.Add(to);
                terrainOriginalsNewIndices.Add(origIndex);
            }
        }




        terrainOriginals = new TerrainOriginals[terrainOriginalsNew.Count];

        for (int i = 0; i < terrainOriginals.Length; i++)
        {
            terrainOriginals[terrainOriginalsNewIndices[i]] = terrainOriginalsNew[i];
        }

    }*/
}



public class TerrainOriginals
{
    public float[,] deltaHeights;
}