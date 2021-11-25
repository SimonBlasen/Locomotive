using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePanelMover : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve animCurve = null;
    [SerializeField]
    private AnimationCurve animCurveClose = null;
    [SerializeField]
    private float animTime = 1f;
    [SerializeField]
    private float animTimeClose = 1f;
    [SerializeField]
    private Transform[] panelTransforms = null;
    [SerializeField]
    private Transform panelClosedPos = null;
    [SerializeField]
    private Transform panelOpenedPos = null;

    private float animS = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (panelOpened && animS < 1f)
        {
            animS += Time.deltaTime / animTime;
            animS = Mathf.Clamp(animS, 0f, 1f);

            for (int i = 0; i < panelTransforms.Length; i++)
            {
                panelTransforms[i].localRotation = Quaternion.Lerp(panelClosedPos.localRotation, panelOpenedPos.localRotation, animCurve.Evaluate(animS));
            }
        }
        else if (panelOpened == false && animS > 0f)
        {
            animS -= Time.deltaTime / animTimeClose;
            animS = Mathf.Clamp(animS, 0f, 1f);

            for (int i = 0; i < panelTransforms.Length; i++)
            {
                panelTransforms[i].localRotation = Quaternion.Lerp(panelClosedPos.localRotation, panelOpenedPos.localRotation, animCurveClose.Evaluate(animS));
            }
        }
    }



    private bool panelOpened = false;
    public bool PanelOpened
    {
        get
        {
            return panelOpened;
        }
        set
        {
            panelOpened = value;
        }
    }
}
