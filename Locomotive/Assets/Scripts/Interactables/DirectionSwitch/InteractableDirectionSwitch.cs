using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDirectionSwitch : Interactable
{
    [SerializeField]
    private Train train = null;
    [SerializeField]
    private float colliderStretchFactor = 1f;
    [SerializeField]
    private AnimationCurve curveFlipSwitch = null;
    [SerializeField]
    private float animationTime = 1f;
    [SerializeField]
    private Transform switchTransform = null;
    [SerializeField]
    private Transform forwardPosTransform = null;
    [SerializeField]
    private Transform backwardsPosTransform = null;

    private StudioEventEmitter stevem = null;

    private float s = 1f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stevem = GetComponent<StudioEventEmitter>();

        train.DriveDirectionForward = true;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (s < (train.DriveDirectionForward ? 1f : 0f))
        {
            s += Time.deltaTime / animationTime;
        }
        else if (s > (train.DriveDirectionForward ? 1f : 0f))
        {
            s -= Time.deltaTime / animationTime;
        }

        s = Mathf.Clamp(s, 0f, 1f);

        switchTransform.localRotation = Quaternion.Lerp(backwardsPosTransform.localRotation, forwardPosTransform.localRotation, curveFlipSwitch.Evaluate(s));
    }


    public override void Interact()
    {
        train.DriveDirectionForward = !train.DriveDirectionForward;
        stevem.Play();
    }
}
