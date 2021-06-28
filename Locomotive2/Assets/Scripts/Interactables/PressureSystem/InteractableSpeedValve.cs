using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpeedValve : Interactable
{
    [SerializeField]
    private SpeedValve speedValve = null;
    [SerializeField]
    private Boiler boiler = null;
    [SerializeField]
    private Train train = null;
    [SerializeField]
    private float pressureUseFactor = 1f;
    [SerializeField]
    private float pressureDriveFactor = 1f;

    public float pressureOnWheels = 0f;

    private bool eDown = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        speedValve.ValveOpening = 0f;
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
            float sliderVal = 0f;

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, 2f, LayerMask.GetMask("Interactable")))
            {
                sliderVal = interactableCollider.transform.InverseTransformPoint(hit.point).y;

                //Debug.Log(sliderVal.ToString("n2"));

                float brakeVal = (sliderVal * 1.5f + 0.5f);
                brakeVal = Mathf.Clamp(brakeVal, 0f, 1f);

                speedValve.ValveOpening = brakeVal;

                //brakeLeaver.BrakeLevel = brakeVal;
            }
        }

        float usedPressure = boiler.UseUpPressure(speedValve.ValveOpening * pressureUseFactor);
        pressureOnWheels = speedValve.ValveOpening * boiler.Pressure * usedPressure * pressureDriveFactor;
        train.PressureWheels = pressureOnWheels;
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
