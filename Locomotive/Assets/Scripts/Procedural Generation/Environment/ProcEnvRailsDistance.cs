using SplineMesh;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class ProcEnvRailsDistance
{
    private int resolution = 25;

    private float[,] distanceField = null;

    public float maxDistance = 150f;
    private float cellDiagonalDistance = 0f;

    public ProcEnvRailsDistance()
    {
        distanceField = new float[100000 / resolution, 100000 / resolution];

        cellDiagonalDistance = resolution * Mathf.Sqrt(2f);
    }

    public void ComputeDistancefield(Spline[] splines)
    {
        for (int y = 0; y < distanceField.GetLength(1); y++)
        {
            for (int x = 0; x < distanceField.GetLength(0); x++)
            {
                distanceField[x, y] = computeFor(x, y, splines);
            }
        }
    }

    private float computeFor(int x, int y, Spline[] splines)
    {
        Vector2 worldPos = new Vector2(x * resolution + resolution * 0.5f, y * resolution + resolution * 0.5f);

        float closestDistance = maxDistance * 10f;

        for (int spl = 0; spl < splines.Length; spl++)
        {
            bool consider = false;
            for (int cp = 0; cp < splines[spl].nodes.Count; cp++)
            {
                if (Vector2.Distance(new Vector2(splines[spl].nodes[cp].Position.x, splines[spl].nodes[cp].Position.z), worldPos) <= maxDistance * 3f)
                {
                    consider = true;
                    break;
                }
            }

            if (consider)
            {
                CurveSample curveSample = splines[spl].GetProjectionSample(worldPos);

                float distance = Vector2.Distance(new Vector2(curveSample.location.x, curveSample.location.z), worldPos) - cellDiagonalDistance;
                if (distance < 0f)
                {
                    distance = 0f;
                }
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                }
            }
        }

        return closestDistance;
    }

    public float DistanceToRails(Vector2 pos)
    {
        Vector2Int arrayPos = new Vector2Int((int)(pos.x / resolution), (int)(pos.y / resolution));
        if (arrayPos.x >= 0 && arrayPos.x < distanceField.GetLength(0) && arrayPos.y >= 0 && arrayPos.y < distanceField.GetLength(1))
        {
            return distanceField[arrayPos.x, arrayPos.y];
        }
        return maxDistance * 10f;
    }


    public byte[] ToBytes()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        SurrogateSelector surrogateSelector = new SurrogateSelector();
        SerializationSurgateUnityObjs vector3SS = new SerializationSurgateUnityObjs();
        surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3SS);

        binaryFormatter.SurrogateSelector = surrogateSelector;

        MemoryStream ms = new MemoryStream();

        binaryFormatter.Serialize(ms, this);

        byte[] bytes = ms.ToArray();

        ms.Flush();
        ms.Close();
        ms.Dispose();

        return bytes;
    }

    public static ProcEnvRailsDistance FromBytes(byte[] bytes)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        SurrogateSelector surrogateSelector = new SurrogateSelector();
        SerializationSurgateUnityObjs vector3SS = new SerializationSurgateUnityObjs();
        surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3SS);

        binaryFormatter.SurrogateSelector = surrogateSelector;

        MemoryStream ms = new MemoryStream();
        ms.Write(bytes, 0, bytes.Length);
        ms.Seek(0, SeekOrigin.Begin);

        object obj = binaryFormatter.Deserialize(ms);

        ProcEnvRailsDistance eog = (ProcEnvRailsDistance)obj;

        ms.Flush();
        ms.Close();
        ms.Dispose();

        return eog;
    }
}
