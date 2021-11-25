using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePanel : Interactable
{
    [SerializeField]
    private FirePanelMover firePanel = null;
    [SerializeField]
    private GameObject interactableColliderBlocker = null;
    [SerializeField]
    private StudioEventEmitter snapshotPanelOpenClose = null;

    [FMODUnity.EventRef]
    public string eventOpenPanel;
    [FMODUnity.EventRef]
    public string eventClosePanel;

    private StudioEventEmitter stevem = null;

    private FMOD.Studio.EventInstance instanceTrainSound;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        stevem = GetComponent<StudioEventEmitter>();
        //instanceTrainSound = FMODUnity.RuntimeManager.CreateInstance(fmodEventTrainSound);

        interactableColliderBlocker.SetActive(true);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }


    public override void Interact()
    {
        firePanel.PanelOpened = !firePanel.PanelOpened;
        interactableColliderBlocker.SetActive(!firePanel.PanelOpened);

        if (firePanel.PanelOpened)
        {
            snapshotPanelOpenClose.Play();
            stevem.Event = eventOpenPanel;
        }
        else
        {
            snapshotPanelOpenClose.Stop();
            stevem.Event = eventClosePanel;
        }

        stevem.Play();
        //instanceTrainSound.start();
    }

    public override void InteractUp()
    {
        //stevem.Stop();

        //instanceTrainSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
