using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTerrain : MonoBehaviour
{
    private BoxCollider aabbCollider = null;

    private Terrain terrain = null;

    private GlobalOffsetTransform globalOffsetTransform = null;

    private void Awake()
    {
        terrain = GetComponent<Terrain>();

        GameObject aabbColliderObj = new GameObject("Terrain AABB Collider");
        aabbCollider = aabbColliderObj.AddComponent<BoxCollider>();

        aabbColliderObj.AddComponent<GlobalOffsetTransform>();

        aabbColliderObj.transform.localScale = new Vector3(10000f, 10000f, 10000f);
        aabbColliderObj.transform.position = transform.position + new Vector3(5000f, 0f, 5000f);

        aabbCollider.isTrigger = true;

        globalOffsetTransform = GetComponent<GlobalOffsetTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BoxCollider BoxCollider
    {
        get
        {
            return aabbCollider;
        }
    }

    public Terrain Terrain
    {
        get
        {
            return terrain;
        }
    }



    private bool isEnabled = true;
    public bool IsEnabled
    {
        get
        {
            return isEnabled;
        }
        set
        {
            bool wasEnabled = isEnabled;
            isEnabled = value;

            if (wasEnabled == false && isEnabled)
            {
                globalOffsetTransform.IsActive = true;
                globalOffsetTransform.ApplyGlobalOffset(GlobalOffsetManager.Inst.GlobalOffset);
            }
            else if (wasEnabled && isEnabled == false)
            {
                globalOffsetTransform.IsActive = false; 
            }
        }
    }
}
