using DialogX;
using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]
    private TriggerType triggerType;
    [SerializeField]
    private string triggerID = "";
    [SerializeField]
    private bool isOneShot = false;

    [SerializeField]
    private RailSegment railSegment = null;
    [SerializeField]
    private float splineS = 0f;
    [SerializeField]
    private float refreshTime = 1f;

    private DialogManager dialogManager = null;

    private Spline spline = null;

    private int prevSide = 0;

    private float checkS = 0f;
    private bool wasActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
        spline = railSegment.GetComponentInChildren<Spline>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!wasActivated || !isOneShot)
        {
            checkS -= Time.deltaTime;

            if (checkS <= 0f)
            {
                checkS = refreshTime;

                checkPassPosition();
            }
        }
    }

    private void checkPassPosition()
    {
        if (dialogManager.Train.TrainRailHandler.GetTrainPoses()[0].splineID != railSegment.ID)
        {
            prevSide = 0;
        }
        else
        {
            int sideNow = (dialogManager.Train.TrainRailHandler.GetTrainPoses()[0].splineS > splineS) ? 1 : -1;
            
            if (prevSide != 0 && sideNow != 0 && prevSide != sideNow)
            {
                dialogManager.TriggerActivated(this);
                wasActivated = true;
            }

            prevSide = sideNow;
        }
    }

    public TriggerType TriggerType
    {
        get
        {
            return triggerType;
        }
    }

    public string TriggerID
    {
        get
        {
            return triggerID;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (spline == null)
        {
            spline = railSegment.GetComponentInChildren<Spline>();
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(spline.GetSampleAtDistance(splineS).location + GlobalOffsetManager.Inst.GlobalOffset, 20f);
    }
}
