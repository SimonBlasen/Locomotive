using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SplineConnector : MonoBehaviour
{
    [SerializeField]
    public Spline spline0;
    [SerializeField]
    public Spline spline1;
    [SerializeField]
    public bool connect = false;
    [SerializeField]
    public float distanceTolerance = 2f;


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

            ConnectSplines(spline0, spline1, distanceTolerance);
        }
    }


    public void ConnectSplines(Spline fixSpline, Spline changeSpline, float tolerance)
    {
        int index0 = -1;
        int index1 = -1;

        if (Vector3.Distance(fixSpline.nodes[0].Position, changeSpline.nodes[0].Position) <= tolerance)
        {
            index0 = 0;
            index1 = 0;
        }
        if (index0 != -1 && index1 != -1)
        {
            changeSpline.nodes[index1].Position = fixSpline.nodes[index0].Position;

            Vector3 tangent0 = fixSpline.nodes[index0].Direction - fixSpline.nodes[index0].Position;
            Vector3 tangent1 = changeSpline.nodes[index1].Direction - changeSpline.nodes[index1].Position;

            if (Vector3.Angle(tangent0, tangent1) >= 90f)
            {
                changeSpline.nodes[index1].Direction = (-tangent0.normalized) * tangent1.magnitude + changeSpline.nodes[index1].Position;
            }
            else
            {
                changeSpline.nodes[index1].Direction = (tangent0.normalized) * tangent1.magnitude + changeSpline.nodes[index1].Position;
            }
        }
        index0 = -1;
        index1 = -1;










        if (Vector3.Distance(fixSpline.nodes[fixSpline.nodes.Count - 1].Position, changeSpline.nodes[0].Position) <= tolerance)
        {
            index0 = fixSpline.nodes.Count - 1;
            index1 = 0;
        }
        if (index0 != -1 && index1 != -1)
        {
            changeSpline.nodes[index1].Position = fixSpline.nodes[index0].Position;

            Vector3 tangent0 = fixSpline.nodes[index0].Direction - fixSpline.nodes[index0].Position;
            Vector3 tangent1 = changeSpline.nodes[index1].Direction - changeSpline.nodes[index1].Position;

            if (Vector3.Angle(tangent0, tangent1) >= 90f)
            {
                changeSpline.nodes[index1].Direction = (-tangent0.normalized) * tangent1.magnitude + changeSpline.nodes[index1].Position;
            }
            else
            {
                changeSpline.nodes[index1].Direction = (tangent0.normalized) * tangent1.magnitude + changeSpline.nodes[index1].Position;
            }
        }
        index0 = -1;
        index1 = -1;









        if (Vector3.Distance(fixSpline.nodes[0].Position, changeSpline.nodes[changeSpline.nodes.Count - 1].Position) <= tolerance)
        {
            index0 = 0;
            index1 = changeSpline.nodes.Count - 1;
        }
        if (index0 != -1 && index1 != -1)
        {
            changeSpline.nodes[index1].Position = fixSpline.nodes[index0].Position;

            Vector3 tangent0 = fixSpline.nodes[index0].Direction - fixSpline.nodes[index0].Position;
            Vector3 tangent1 = changeSpline.nodes[index1].Direction - changeSpline.nodes[index1].Position;

            if (Vector3.Angle(tangent0, tangent1) >= 90f)
            {
                changeSpline.nodes[index1].Direction = (-tangent0.normalized) * tangent1.magnitude + changeSpline.nodes[index1].Position;
            }
            else
            {
                changeSpline.nodes[index1].Direction = (tangent0.normalized) * tangent1.magnitude + changeSpline.nodes[index1].Position;
            }
        }
        index0 = -1;
        index1 = -1;











        if (Vector3.Distance(fixSpline.nodes[fixSpline.nodes.Count - 1].Position, changeSpline.nodes[changeSpline.nodes.Count - 1].Position) <= tolerance)
        {
            index0 = fixSpline.nodes.Count - 1;
            index1 = changeSpline.nodes.Count - 1;
        }
        if (index0 != -1 && index1 != -1)
        {
            changeSpline.nodes[index1].Position = fixSpline.nodes[index0].Position;

            Vector3 tangent0 = fixSpline.nodes[index0].Direction - fixSpline.nodes[index0].Position;
            Vector3 tangent1 = changeSpline.nodes[index1].Direction - changeSpline.nodes[index1].Position;

            if (Vector3.Angle(tangent0, tangent1) >= 90f)
            {
                changeSpline.nodes[index1].Direction = (-tangent0.normalized) * tangent1.magnitude + changeSpline.nodes[index1].Position;
            }
            else
            {
                changeSpline.nodes[index1].Direction = (tangent0.normalized) * tangent1.magnitude + changeSpline.nodes[index1].Position;
            }
        }
        index0 = -1;
        index1 = -1;
    }
}
