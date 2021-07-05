using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTerrain : MonoBehaviour
{
    [SerializeField]
    private BoxCollider aabbCollider = null;
    [SerializeField]
    private Terrain terrain = null;

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
}
