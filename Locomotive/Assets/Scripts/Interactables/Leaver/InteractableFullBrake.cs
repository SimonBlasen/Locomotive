using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFullBrake : Interactable
{
    [SerializeField]
    private BrakeLeaver brakeLeaver = null;

    private bool eDown = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        brakeLeaver.BrakeLevel = 0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (eDown)
        {
            float sliderVal = 0f;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, 2f, LayerMask.GetMask("Interactable")))
            {
                sliderVal = interactableCollider.transform.InverseTransformPoint(hit.point).y;

                Debug.Log(sliderVal.ToString("n2"));

                float brakeVal = (sliderVal * 1.5f + 0.5f);
                brakeVal = Mathf.Clamp(brakeVal, 0f, 1f);

                brakeLeaver.BrakeLevel = brakeVal;
            }
        }
    }


    public override void Interact()
    {
        eDown = true;
    }

    public override void InteractUp()
    {
        eDown = false;
    }
}
