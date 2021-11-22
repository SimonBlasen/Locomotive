using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvObjectsPool : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private EnvObjectsManager envObjectsManager = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnObject(EnvSpawnObjectInfo objectInfo)
    {
        GameObject prefab = envObjectsManager.ObjectPrefabs[objectInfo.objectID].prefabLOD0;

        GameObject obj = Instantiate(prefab, transform);
        obj.transform.position = objectInfo.pos + GlobalOffsetManager.Inst.GlobalOffset;
        obj.transform.up = objectInfo.upVec;
        obj.transform.Rotate(0f, objectInfo.yRot, 0f, Space.Self);
        obj.transform.localScale = objectInfo.scale;
        if (objectInfo.yRot == 0f && objectInfo.upVec == Vector3.zero && objectInfo.rot != Vector3.zero)
        {
            obj.transform.rotation = Quaternion.Euler(objectInfo.rot);
        }

        obj.AddComponent<GlobalOffsetTransform>();

        return obj;
    }

    public void DespawnObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
