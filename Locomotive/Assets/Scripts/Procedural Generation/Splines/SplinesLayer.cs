using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SplinesLayer : MonoBehaviour
{
    [Header("Run")]
    [SerializeField]
    private bool generateSpline = false;

    [Space]

    [Header("References")]
    [SerializeField]
    private Spline toAdjustSpline = null;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generateSpline)
        {
            generateSpline = false;

            genSpline();
        }
    }


    private void genSpline()
    {

    }
}
