using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TerrainMaterialAssigner : MonoBehaviour
{
    public Material toAssignMaterial = null;
    public float pixelError = 1f;

    public bool assign = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (assign)
        {
            assign = false;

            Terrain[] terrains = FindObjectsOfType<Terrain>();

            for (int i = 0; i < terrains.Length; i++)
            {
                terrains[i].materialTemplate = toAssignMaterial;
                terrains[i].heightmapPixelError = pixelError;
            }
        }
    }
}
