using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SplineAdjuster : MonoBehaviour
{
    [SerializeField]
    private bool adjust = false;
    [SerializeField]
    private Spline spline = null;
    [SerializeField]
    private ProcTerrainAccessor terrainAccessor = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (adjust)
        {
            adjust = false;

            adjustSpline();
        }
    }


    private void adjustSpline()
    {
        for (int i = 0; i < spline.nodes.Count; i++)
        {
            Vector2 pos2D = new Vector2(spline.nodes[i].Position.x, spline.nodes[i].Position.z);
            Vector2 pos2DDirection = new Vector2(spline.nodes[i].Direction.x, spline.nodes[i].Direction.z);

            RaycastHit[] hit = Physics.RaycastAll(new Ray(new Vector3(pos2D.x, 6000f, pos2D.y), Vector3.down), 7000f);
            RaycastHit[] hitDirection = Physics.RaycastAll(new Ray(new Vector3(pos2DDirection.x, 6000f, pos2DDirection.y), Vector3.down), 7000f);

            for (int k = 0; k < hit.Length; k++)
            {
                for (int j = 0; j < hitDirection.Length; j++)
                {
                    if (hit[k].transform.name.Contains("Terrain") && hitDirection[j].transform.name.Contains("Terrain"))
                    {
                        spline.nodes[i].Position = new Vector3(pos2D.x, hit[k].point.y, pos2D.y);

                        spline.nodes[i].Direction = new Vector3(pos2DDirection.x, hitDirection[j].point.y, pos2DDirection.y);
                    }
                }
            }

        }
    }
}
