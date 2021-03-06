using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFullBrake : Interactable
{
    [SerializeField]
    private BrakeLeaver brakeLeaver = null;
    [SerializeField]
    private float colliderStretchFactor = 1f;
    [SerializeField]
    private bool newSlideMode = true;
    [SerializeField]
    private bool useXAxe = true;
    [SerializeField]
    private float slideFactor = 0.01f;
    [SerializeField]
    private StudioEventEmitter leaverSoundEmitter = null;

    private bool eDown = false;
    private bool playedAudio = false;

    private float sliderVal = 0f;
    private float sliderStartVal = 0f;
    private float sliderStartValOld = 0f;

    private Vector2 mousePosStart = Vector2.zero;
    private float startBrakeVal = 0f;

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

        if (newSlideMode)
        {
            if (eDown)
            {
                Vector2 absDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
                mousePosStart += absDelta * slideFactor;


                float slideVal = useXAxe ? mousePosStart.x : mousePosStart.y;

                float oldBrakeLevel = brakeLeaver.BrakeLevel;
                brakeLeaver.BrakeLevel = Mathf.Clamp(startBrakeVal + slideVal, 0f, 1f);
                setTextMeshHint();

                if (oldBrakeLevel != brakeLeaver.BrakeLevel && playedAudio == false)
                {
                    playedAudio = true;
                    leaverSoundEmitter.Play();
                }
            }
            else
            {
                if (playedAudio)
                {
                    playedAudio = false;
                }
            }


        }
    }

    private void FixedUpdate()
    {/*
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

                    float oldBrakeLevel = brakeLeaver.BrakeLevel;
                    brakeLeaver.BrakeLevel = brakeVal;
                    setTextMeshHint();

                }
            }
            else
            {
                if (playedAudio)
                {
                    playedAudio = false;
                }
            }
        }*/
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
        //mousePosStart = Input.mousePosition;
        mousePosStart = Vector2.zero;

        if (newSlideMode)
        {
            startBrakeVal = brakeLeaver.BrakeLevel;
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
