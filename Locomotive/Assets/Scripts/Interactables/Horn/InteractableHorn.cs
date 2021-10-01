using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHorn : Interactable
{

    //[FMODUnity.EventRef]
    //public string fmodEventTrainSound;

    //private FMOD.Studio.EventInstance instanceTrainSound;
    private StudioEventEmitter eventEmitterLokSound = null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        eventEmitterLokSound = GetComponent<StudioEventEmitter>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }


    public override void Interact()
    {
        eventEmitterLokSound.Play();
    }

    public override void InteractUp()
    {
        eventEmitterLokSound.StopInstance();
    }
}