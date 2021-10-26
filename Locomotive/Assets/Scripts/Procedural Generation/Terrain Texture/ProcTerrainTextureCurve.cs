using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TextureLayerType
{
    DIRT = 0, STONES = 1, ROCKS = 2
}

public enum TexturePropType
{
    SLOPE = 0, ABS_HEIGHT = 1
}


public class ProcTerrainTextureCurve : MonoBehaviour
{
    public TerrainTextureLayerCurve[] curves = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[Serializable]
public class TerrainTextureLayerCurve
{
    public TexturePropType property;
    public AnimationCurve curve;
}