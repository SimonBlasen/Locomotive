using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePressureRelease : Interactable
{
    [SerializeField]
    private Boiler boiler = null;
    [SerializeField]
    private PressureReleaseValve pressureReleaseValve = null;

    [FMODUnity.EventRef]
    public string fmodEventTrainSound;

    private StudioEventEmitter stevem = null;

    private FMOD.Studio.EventInstance instanceTrainSound;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stevem = GetComponent<StudioEventEmitter>();
        //instanceTrainSound = FMODUnity.RuntimeManager.CreateInstance(fmodEventTrainSound);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }


    public override void Interact()
    {
        boiler.ReleaseSteam = true;
        pressureReleaseValve.ReleasingAir = true;

        stevem.Play();
        //instanceTrainSound.start();
    }

    public override void InteractUp()
    {
        boiler.ReleaseSteam = false;
        pressureReleaseValve.ReleasingAir = false;

        //stevem.Stop();

        //instanceTrainSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}