using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHorn : Interactable
{

    [FMODUnity.EventRef]
    public string fmodEventTrainSound;

    private FMOD.Studio.EventInstance instanceTrainSound;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        instanceTrainSound = FMODUnity.RuntimeManager.CreateInstance(fmodEventTrainSound);

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }


    public override void Interact()
    {

        instanceTrainSound.setParameterByName("Parameter 1", 1f);
        instanceTrainSound.start();

    }

    public override void InteractUp()
    {

        instanceTrainSound.setParameterByName("Parameter 1", 0f);
    }
}