using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class EnvObjectsManager : MonoBehaviour
{
    [SerializeField]
    private int amountOfGrids = 0;
    [SerializeField]
    private int sqrtElementsPerFile = 0;
    [SerializeField]
    private GameObject[] envObjectsIDList;

    private EnvObjectsGrid[] grids;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void loadEnvObjectsGrid()
    {
        string filePath = "./envobjects/envobjectsgrid";
        for (int i = 0; i < amountOfGrids; i++)
        {
            if (File.Exists(filePath + i.ToString() + ".eog") == false)
            {
                EnvObjectsGrid eog = new EnvObjectsGrid();
                File.WriteAllBytes(filePath + i.ToString() + ".eog", eog.ToBytes());
            }
        }


        grids = new EnvObjectsGrid[amountOfGrids];
        for (int i = 0; i < amountOfGrids; i++)
        {
            byte[] bytes = File.ReadAllBytes(filePath + i.ToString() + ".eog");

            grids[i] = EnvObjectsGrid.FromBytes(bytes);
        }
    }

    public int GetObjectID(GameObject prefab)
    {
        for (int i = 0; i < envObjectsIDList.Length; i++)
        {
            if (envObjectsIDList[i] == prefab)
            {
                return i;
            }
        }

        return -1;
    }

    public GameObject[] ObjectPrefabs
    {
        get
        {
            return envObjectsIDList;
        }
    }

    public int SqrtElementsPerFile
    {
        get
        {
            return sqrtElementsPerFile;
        }
    }
}


[Serializable]
public class EnvObjectsGrid
{
    public EnvSpawnObjectInfo[,] spawnObjects;
    public float gridSize;
    public int gridOffsetX;
    public int gridOffsetZ;


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

    public static EnvObjectsGrid FromBytes(byte[] bytes)
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

        EnvObjectsGrid eog = (EnvObjectsGrid)obj;

        ms.Flush();
        ms.Close();
        ms.Dispose();

        return eog;
    }
}

[Serializable]
public struct EnvSpawnObjectInfo
{
    public int objectID;

    public Vector3 pos;
    public Vector3 rot;
    public Vector3 upVec;
    public float yRot;
    public Vector3 scale;
}





public class SerializationSurgateUnityObjs : ISerializationSurrogate
{

    // Method called to serialize a Vector3 object
    public void GetObjectData(System.Object obj, SerializationInfo info, StreamingContext context)
    {

        Vector3 v3 = (Vector3)obj;
        info.AddValue("x", v3.x);
        info.AddValue("y", v3.y);
        info.AddValue("z", v3.z);
    }

    // Method called to deserialize a Vector3 object
    public System.Object SetObjectData(System.Object obj, SerializationInfo info,
                                       StreamingContext context, ISurrogateSelector selector)
    {

        Vector3 v3 = (Vector3)obj;
        v3.x = (float)info.GetValue("x", typeof(float));
        v3.y = (float)info.GetValue("y", typeof(float));
        v3.z = (float)info.GetValue("z", typeof(float));
        obj = v3;
        return obj;
    }
}