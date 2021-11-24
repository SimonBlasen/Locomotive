using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeLeaver : MonoBehaviour
{
    [SerializeField]
    private Transform leaver = null;
    [SerializeField]
    private Transform leaverPosOpened = null;
    [SerializeField]
    private Transform leaverPosBraked = null;
    [SerializeField]
    private Train train = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leaver.transform.localRotation = Quaternion.Lerp(leaverPosOpened.localRotation, leaverPosBraked.localRotation, BrakeLevel);

        train.BrakeStrength = 1f - BrakeLevel;
    }

    /// <summary>
    /// Between 0 and 1
    /// </summary>
    public float BrakeLevel
    {
        get; set;
    } = 0f;
}
