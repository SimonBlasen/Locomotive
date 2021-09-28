using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailroadMapTracksegment : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private RailSegment[] accordingRailSegments = null;

    private Color colorOnTrack = Color.yellow;

    private TrainRailHandler railHandler = null;
    private Train train = null;

    private RailSegment currentRailSegment = null;
    private float checkRailSegmentCounter = 0f;

    private MeshRenderer meshRenderer = null;
    private Material materialNormal = null;
    private Material materialOnTrack = null;

    // Start is called before the first frame update
    void Start()
    {
        train = GetComponentInParent<Train>();
        train.RailHandlerInit += Train_RailHandlerInit;

        meshRenderer = GetComponent<MeshRenderer>();
        materialNormal = new Material(meshRenderer.sharedMaterial);
        materialOnTrack = new Material(materialNormal);
        materialOnTrack.color = colorOnTrack;

        meshRenderer.sharedMaterial = materialNormal;
    }

    private void Train_RailHandlerInit(TrainRailHandler railHandler)
    {
        this.railHandler = railHandler;
        currentRailSegment = railHandler.CurrentRailSegment;
    }

    // Update is called once per frame
    void Update()
    {
        checkRailSegmentCounter += Time.deltaTime;

        if (checkRailSegmentCounter >= 1f)
        {
            checkRailSegmentCounter = 0f;
            if (railHandler != null && railHandler.CurrentRailSegment != currentRailSegment)
            {
                currentRailSegment = railHandler.CurrentRailSegment;

                IsTrainOnSegment = isRailsegmentPartOfSelf(currentRailSegment);
            }
        }
    }

    private bool isRailsegmentPartOfSelf(RailSegment railSegment)
    {
        for (int i = 0; i < accordingRailSegments.Length; i++)
        {
            if (railSegment == accordingRailSegments[i])
            {
                return true;
            }
        }
        return false;
    }


    private bool isTrainOnSegment = false;
    public bool IsTrainOnSegment
    {
        get
        {
            return isTrainOnSegment;
        }
        set
        {
            isTrainOnSegment = value;

            meshRenderer.sharedMaterial = isTrainOnSegment ? materialOnTrack : materialNormal;
        }
    }
}
