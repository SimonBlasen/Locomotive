using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePressureRelease : Interactable
{
    [SerializeField]
    private Boiler boiler = null;

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
        boiler.ReleaseSteam = true;
    }

    public override void InteractUp()
    {
        boiler.ReleaseSteam = false;
    }
}