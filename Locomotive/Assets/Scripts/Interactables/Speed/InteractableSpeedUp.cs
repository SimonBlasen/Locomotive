using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSpeedUp : Interactable
{
    [SerializeField]
    private SpeedGauge speedGauge = null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }


    public override void Interact()
    {
        speedGauge.TargetSpeed += 1f;
    }
}