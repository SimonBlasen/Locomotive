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
    [SerializeField]
    private bool newSlideMode = true;
    [SerializeField]
    private bool useXAxe = true;
    [SerializeField]
    private float slideFactor = 0.01f;

    public float pressureOnWheels = 0f;

    private bool eDown = false;

    private float sliderVal = 0f;
    private float sliderStartVal = 0f;
    private float sliderStartValOld = 0f;

    private Vector2 mousePosStart = Vector2.zero;
    private float startSpeedValue = 0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        speedValve.ValveOpening = 0f;
        setTextMeshHint();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (newSlideMode)
        {
            if (eDown)
            {
                Vector2 absDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                mousePosStart += absDelta * slideFactor;


                float slideVal = useXAxe ? mousePosStart.x : mousePosStart.y;

                speedValve.ValveOpening = Mathf.Clamp(startSpeedValue + slideVal, 0f, 1f);
                setTextMeshHint();
            }


        }
    }

    private void FixedUpdate()
    {
        if (!newSlideMode)
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

                    speedValve.ValveOpening = brakeVal;
                    setTextMeshHint();

                    //brakeLeaver.BrakeLevel = brakeVal;
                }
            }

            float usedPressure = boiler.UseUpPressure(speedValve.ValveOpening * pressureUseFactor);
            pressureOnWheels = speedValve.ValveOpening * boiler.Pressure * usedPressure * pressureDriveFactor;
            train.PressureWheels = pressureOnWheels;
        }
    }


    private void setTextMeshHint()
    {
        if (textMeshHint != null)
        {
            textMeshHint.text = (speedValve.ValveOpening * 100f).ToString("n0") + "%";
        }
    }

    public override void Interact()
    {
        eDown = true;

        mousePosStart = Vector2.zero;
        if (newSlideMode)
        {
            startSpeedValue = speedValve.ValveOpening;
            FirstPersonPlayer.RotationsBlocked = true;
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, 2f, LayerMask.GetMask("Interactable")))
        {
            sliderStartVal = interactableCollider.transform.InverseTransformPoint(hit.point).y;
        }
    }

    public override void InteractUp()
    {
        if (newSlideMode)
        {
            FirstPersonPlayer.RotationsBlocked = false;
        }

        sliderStartValOld = sliderVal;
        eDown = false;
    }
}
