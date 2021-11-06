using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRailroadSwitch : Interactable
{
    [SerializeField]
    private SwitchSetting switchSetting = null;
    [SerializeField]
    private float colliderStretchFactor = 1f;
    [SerializeField]
    private AnimationCurve curveFlipSwitch = null;
    [SerializeField]
    private float animationTime = 1f;
    [SerializeField]
    private Transform switchTransform = null;
    [SerializeField]
    private Transform leftPosTransform = null;
    [SerializeField]
    private Transform rightPosTransform = null;

    private StudioEventEmitter stevem = null;

    private float s = 0f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stevem = GetComponent<StudioEventEmitter>();

        switchSetting.SetSwitch(0);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (s < switchSetting.CurrentSetting)
        {
            s += Time.deltaTime / animationTime;
        }
        else if (s > switchSetting.CurrentSetting)
        {
            s -= Time.deltaTime / animationTime;
        }

        s = Mathf.Clamp(s, 0f, 1f);

        switchTransform.localRotation = Quaternion.Lerp(leftPosTransform.localRotation, rightPosTransform.localRotation, curveFlipSwitch.Evaluate(s));
    }


    public override void Interact()
    {
        switchSetting.SetSwitch(1 - switchSetting.CurrentSetting);
        stevem.Play();
    }
}
