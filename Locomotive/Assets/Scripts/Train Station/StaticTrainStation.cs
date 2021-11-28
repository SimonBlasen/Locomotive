using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StaticTrainStation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private TrainStation trainStation = null;

    [Space]

    [Header("Edit Mode")]
    [SerializeField]
    private bool move = false;
    [SerializeField]
    private bool moveBack = false;


    private Vector3 originalPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        sanityCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveBack)
        {
            moveBack = false;

            transform.position = originalPosition;
        }

        if (move)
        {
            move = false;

            Vector3 splineLoc = trainStation.Platforms[0].spline.GetSampleAtDistance(Mathf.Lerp(trainStation.Platforms[0].trainStationBegin, trainStation.Platforms[0].trainStationEnd, 0.5f)).location;

            Debug.Log("Spline loc: " + splineLoc.ToString());

            Vector3Int clampedOffsetPos = GlobalOffsetManager.Inst.GetPotentialGlobalOffset(splineLoc);

            sanityCheck();

            for (int i = 1; i < trainStation.Platforms.Length; i++)
            {
                splineLoc = trainStation.Platforms[i].spline.GetSampleAtDistance(Mathf.Lerp(trainStation.Platforms[i].trainStationBegin, trainStation.Platforms[i].trainStationEnd, 0.5f)).location;
                Vector3Int newClampedOffset = GlobalOffsetManager.Inst.GetPotentialGlobalOffset(splineLoc);

                if (newClampedOffset != clampedOffsetPos)
                {
                    Debug.LogError("Train station \"" + gameObject.name + "\" has platforms in different global offset locations");
                    Debug.LogError("Conflict at platform [" + i.ToString() + "]");
                }
                else
                {

                }
            }


            originalPosition = transform.position;
            transform.position -= clampedOffsetPos;

            trainStation.globalOffsetToSpawnPersons = -clampedOffsetPos;

        }

    }

    private void sanityCheck()
    {
        Vector3 splineLoc0 = trainStation.Platforms[0].spline.GetSampleAtDistance(trainStation.Platforms[0].trainStationBegin).location;
        Vector3 splineLoc1 = trainStation.Platforms[0].spline.GetSampleAtDistance(trainStation.Platforms[0].trainStationEnd).location;

        Vector3Int clampedOffsetPos0 = GlobalOffsetManager.Inst.GetPotentialGlobalOffset(splineLoc0);
        Vector3Int clampedOffsetPos1 = GlobalOffsetManager.Inst.GetPotentialGlobalOffset(splineLoc1);

        if (clampedOffsetPos0 != clampedOffsetPos1)
        {
            Debug.LogError("Train station is inbetween two different global offsets!");
        }
    }
}
