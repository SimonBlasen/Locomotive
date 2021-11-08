using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmbientEnvironmentType
{
    FORREST, FIELD, TRAIN_STATION, MOUNTAIN
}

public class AmbientSampleSpawner : MonoBehaviour
{
    [Header("Running info")]
    [SerializeField]
    private AmbientEnvironmentType currentArea = AmbientEnvironmentType.FIELD;

    [Space]

    [Header("Settings")]
    [SerializeField]
    private AmbientTypeBorder[] ambientBorders = null;


    private Train train = null;

    // Start is called before the first frame update
    void Start()
    {
        train = FindObjectOfType<Train>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ambientBorders.Length; i++)
        {
            if (ambientBorders[i].railSegment == train.CurrentRailSegment)
            {
                if (ambientBorders[i].trainSide == 0)
                {
                    ambientBorders[i].trainSide = train.CurPosOnSPline < ambientBorders[i].pos ? -1 : 1;
                }

                int nowSide = train.CurPosOnSPline < ambientBorders[i].pos ? -1 : 1;

                if (ambientBorders[i].trainSide != 0 && nowSide != ambientBorders[i].trainSide)
                {
                    // Train drove over border
                    if (nowSide == 1)
                    {
                        currentArea = ambientBorders[i].typeYellow;
                    }
                    else
                    {
                        currentArea = ambientBorders[i].typeRed;
                    }

                    ambientBorders[i].trainSide = nowSide;
                }

            }
            else if (ambientBorders[i].trainSide != 0)
            {
                ambientBorders[i].trainSide = 0;
            }
        }
    }

    public AmbientEnvironmentType CurrentAreaType
    {
        get
        {
            return currentArea;
        }
    }

    public Train Train
    {
        get
        {
            return train;
        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < ambientBorders.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(ambientBorders[i].railSegment.Spline.GetSampleAtDistance(Mathf.Clamp(ambientBorders[i].pos + 1f, 0f, ambientBorders[i].railSegment.Spline.Length)).location + GlobalOffsetManager.Inst.GlobalOffset, 2f);
            
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(ambientBorders[i].railSegment.Spline.GetSampleAtDistance(Mathf.Clamp(ambientBorders[i].pos - 1f, 0f, ambientBorders[i].railSegment.Spline.Length)).location + GlobalOffsetManager.Inst.GlobalOffset, 2f);

        }
    }
}


[Serializable]
public class AmbientTypeBorder
{
    public RailSegment railSegment = null;
    public float pos = 0f;

    public AmbientEnvironmentType typeYellow = AmbientEnvironmentType.FIELD;
    public AmbientEnvironmentType typeRed = AmbientEnvironmentType.FIELD;

    [HideInInspector]
    public int trainSide = 0;
}