using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ProcTerrainInputTexture : MonoBehaviour
{
    public Texture2D texture = null;

    public bool refreshPreview = false;

    private Material matCopy = null;

    private Color[,] map = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (refreshPreview)
        {
            refreshPreview = false;

            Material mat = GetComponent<MeshRenderer>().sharedMaterial;
            if (matCopy == null)
            {
                matCopy = new Material(mat);
                GetComponent<MeshRenderer>().sharedMaterial = matCopy;
            }


            matCopy.mainTexture = texture;
        }
    }

    public void OpenData()
    {
        map = new Color[texture.width, texture.height];

        Color[] colors = texture.GetPixels();

        for (int i = 0; i < colors.Length; i++)
        {
            map[i % texture.width, (i / texture.width)] = colors[i];
        }
    }

    public Color GetValue(Vector2 pos)
    {
        Vector2 uvPos = new Vector2((pos.x / 100000f) * map.GetLength(0), (pos.y / 100000f) * map.GetLength(1));


        int xMin = ((int)uvPos.x);
        int xMax = ((int)uvPos.x) + 1;
        int yMin = ((int)uvPos.y);
        int yMax = ((int)uvPos.y) + 1;

        float interpolX = uvPos.x - xMin;
        float interpolY = uvPos.y - yMin;

        if (xMin < 0)
        {
            xMin = 0;
        }
        if (xMax >= map.GetLength(0))
        {
            xMax = map.GetLength(0) - 1;
        }
        if (yMin < 0)
        {
            yMin = 0;
        }
        if (yMax >= map.GetLength(1))
        {
            yMax = map.GetLength(1) - 1;
        }



        Color val0_0 = map[xMin, yMin];
        Color val0_1 = map[xMin, yMax];

        Color val1_0 = map[xMax, yMin];
        Color val1_1 = map[xMax, yMax];

        Color val0 = Color.Lerp(val0_0, val0_1, interpolY);
        Color val1 = Color.Lerp(val1_0, val1_1, interpolY);

        Color val = Color.Lerp(val0, val1, interpolX);

        return val;

        //Color pixel = texture.GetPixelBilinear(uvPos.x, uvPos.y);

        //return new Vector3(pixel.r, pixel.g, pixel.b);
    }
}
