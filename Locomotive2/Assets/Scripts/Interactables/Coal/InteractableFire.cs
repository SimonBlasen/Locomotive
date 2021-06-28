using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableFire : Interactable
{
    [SerializeField]
    private Fire fire = null;
    [SerializeField]
    private CoalTender coalTender = null;
    [SerializeField]
    private Transform fireMid = null;
    [SerializeField]
    private float flySpeed = 1f;
    [FMODUnity.EventRef]
    public string fmodEventTrainSound;

    private Transform flyingCoal = null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (flyingCoal != null)
        {
            flyingCoal.localPosition = Vector3.MoveTowards(flyingCoal.localPosition, fireMid.localPosition, Time.deltaTime * flySpeed);

            if (Vector3.Distance(flyingCoal.localPosition, fireMid.localPosition) <= 0.05f)
            {
                Destroy(flyingCoal.gameObject);
                flyingCoal = null;
            }
        }

    }


    public override void Interact()
    {

    }

    public void PutCoalIn(Transform coalTransform)
    {
        fire.AddCoal();
        //FMOD.Studio.EventInstance instanceTrainSound = FMODUnity.RuntimeManager.CreateInstance(fmodEventTrainSound);
        FMODUnity.RuntimeManager.PlayOneShot(fmodEventTrainSound, transform.position);

        coalTransform.parent = transform;

        if (flyingCoal != null)
        {
            Destroy(flyingCoal.gameObject);
            flyingCoal = null;
        }

        flyingCoal = coalTransform;
    }
}