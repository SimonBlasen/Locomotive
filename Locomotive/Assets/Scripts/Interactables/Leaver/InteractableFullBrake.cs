using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFullBrake : Interactable
{
    [SerializeField]
    private BrakeLeaver brakeLeaver = null;
    [SerializeField]
    private float colliderStretchFactor = 1f;

    private bool eDown = false;

    private float sliderVal = 0f;
    private float sliderStartVal = 0f;
    private float sliderStartValOld = 0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        brakeLeaver.BrakeLevel = 0f;
        setTextMeshHint();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    private void FixedUpdate()
    {
        if (eDown)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, 2f, LayerMask.GetMask("Interactable")))
            {
                sliderVal = interactableCollider.transform.InverseTransformPoint(hit.point).y + (sliderStartValOld - sliderStartVal);

                //Debug.Log(sliderVal.ToString("n2"));

                float brakeVal = (sliderVal * 1.5f + 0.5f);
                brakeVal = Mathf.Clamp(brakeVal, 0f, 1f);

                brakeLeaver.BrakeLevel = brakeVal;
                setTextMeshHint();
            }
        }
    }

    private void setTextMeshHint()
    {
        if (textMeshHint != null)
        {
            textMeshHint.text = "Brake: " + (100f - brakeLeaver.BrakeLevel * 100f).ToString("n0") + "%";
        }
    }


    public override void Interact()
    {
        eDown = true;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, 2f, LayerMask.GetMask("Interactable")))
        {
            sliderStartVal = interactableCollider.transform.InverseTransformPoint(hit.point).y;
        }
    }

    public override void InteractUp()
    {
        sliderStartValOld = sliderVal;
        eDown = false;
    }
}
