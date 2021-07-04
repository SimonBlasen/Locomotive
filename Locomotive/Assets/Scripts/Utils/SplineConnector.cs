using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SplineConnector : MonoBehaviour
{
    [SerializeField]
    private Spline spline0;
    [SerializeField]
    private Spline spline1;
    [SerializeField]
    private bool connect = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (connect)
        {
            connect = false;

            int index0 = -1;
            int index1 = -1;

            if (Vector3.Distance(spline0.nodes[0].Position, spline1.nodes[0].Position) <= 2f)
            {
                index0 = 0;
                index1 = 0;
            }
            if (index0 != -1 && index1 != -1)
            {
                spline1.nodes[index1].Position = spline0.nodes[index0].Position;

                Vector3 tangent0 = spline0.nodes[index0].Direction - spline0.nodes[index0].Position;
                Vector3 tangent1 = spline1.nodes[index1].Direction - spline1.nodes[index1].Position;

                if (Vector3.Angle(tangent0, tangent1) >= 90f)
                {
                    spline1.nodes[index1].Direction = (-tangent0.normalized) * tangent1.magnitude + spline1.nodes[index1].Position;
                }
                else
                {
                    spline1.nodes[index1].Direction = (tangent0.normalized) * tangent1.magnitude + spline1.nodes[index1].Position;
                }
            }
            index0 = -1;
            index1 = -1;










            if (Vector3.Distance(spline0.nodes[spline0.nodes.Count - 1].Position, spline1.nodes[0].Position) <= 2f)
            {
                index0 = spline0.nodes.Count - 1;
                index1 = 0;
            }
            if (index0 != -1 && index1 != -1)
            {
                spline1.nodes[index1].Position = spline0.nodes[index0].Position;

                Vector3 tangent0 = spline0.nodes[index0].Direction - spline0.nodes[index0].Position;
                Vector3 tangent1 = spline1.nodes[index1].Direction - spline1.nodes[index1].Position;

                if (Vector3.Angle(tangent0, tangent1) >= 90f)
                {
                    spline1.nodes[index1].Direction = (-tangent0.normalized) * tangent1.magnitude + spline1.nodes[index1].Position;
                }
                else
                {
                    spline1.nodes[index1].Direction = (tangent0.normalized) * tangent1.magnitude + spline1.nodes[index1].Position;
                }
            }
            index0 = -1;
            index1 = -1;









            if (Vector3.Distance(spline0.nodes[0].Position, spline1.nodes[spline1.nodes.Count - 1].Position) <= 2f)
            {
                index0 = 0;
                index1 = spline1.nodes.Count - 1;
            }
            if (index0 != -1 && index1 != -1)
            {
                spline1.nodes[index1].Position = spline0.nodes[index0].Position;

                Vector3 tangent0 = spline0.nodes[index0].Direction - spline0.nodes[index0].Position;
                Vector3 tangent1 = spline1.nodes[index1].Direction - spline1.nodes[index1].Position;

                if (Vector3.Angle(tangent0, tangent1) >= 90f)
                {
                    spline1.nodes[index1].Direction = (-tangent0.normalized) * tangent1.magnitude + spline1.nodes[index1].Position;
                }
                else
                {
                    spline1.nodes[index1].Direction = (tangent0.normalized) * tangent1.magnitude + spline1.nodes[index1].Position;
                }
            }
            index0 = -1;
            index1 = -1;











            if (Vector3.Distance(spline0.nodes[spline0.nodes.Count - 1].Position, spline1.nodes[spline1.nodes.Count - 1].Position) <= 2f)
            {
                index0 = spline0.nodes.Count - 1;
                index1 = spline1.nodes.Count - 1;
            }
            if (index0 != -1 && index1 != -1)
            {
                spline1.nodes[index1].Position = spline0.nodes[index0].Position;

                Vector3 tangent0 = spline0.nodes[index0].Direction - spline0.nodes[index0].Position;
                Vector3 tangent1 = spline1.nodes[index1].Direction - spline1.nodes[index1].Position;

                if (Vector3.Angle(tangent0, tangent1) >= 90f)
                {
                    spline1.nodes[index1].Direction = (-tangent0.normalized) * tangent1.magnitude + spline1.nodes[index1].Position;
                }
                else
                {
                    spline1.nodes[index1].Direction = (tangent0.normalized) * tangent1.magnitude + spline1.nodes[index1].Position;
                }
            }
            index0 = -1;
            index1 = -1;
        }
    }
}
