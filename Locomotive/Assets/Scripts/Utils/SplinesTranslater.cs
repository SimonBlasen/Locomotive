using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SplinesTranslater : MonoBehaviour
{
    [SerializeField]
    private bool translateSplines = false;
    [SerializeField]
    private Spline[] toTranslateSplines = null;
    [SerializeField]
    private Vector3 translation = Vector3.zero;

    [Space]

    [SerializeField]
    private bool translateTransforms = false;
    [SerializeField]
    private Transform[] toTranslateTransforms = null;
    [SerializeField]
    private Vector3 translationTransforms = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (translateSplines)
        {
            translateSplines = false;

            transSplines();
        }
        if (translateTransforms)
        {
            translateTransforms = false;

            transTransforms();
        }
    }

    private void transSplines()
    {
        for (int i = 0; i < toTranslateSplines.Length; i++)
        {
            List<SplineNode> newNodes = new List<SplineNode>();

            for (int j = 0; j < toTranslateSplines[i].nodes.Count; j++)
            {
                newNodes.Add(new SplineNode(toTranslateSplines[i].nodes[j].Position + translation, toTranslateSplines[i].nodes[j].Direction + translation));

                toTranslateSplines[i].nodes[j].Position += translation;
                toTranslateSplines[i].nodes[j].Direction += translation;
            }

            //toTranslateSplines[i].nodes = newNodes;
            toTranslateSplines[i].RefreshCurves();
        }
    }

    private void transTransforms()
    {
        for (int i = 0; i < toTranslateTransforms.Length; i++)
        {
            toTranslateTransforms[i].position += translationTransforms;
        }
    }
}
