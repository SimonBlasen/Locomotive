using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeLeaver : MonoBehaviour
{
    [SerializeField]
    private Transform leaver = null;
    [SerializeField]
    private float angleFactor = 0f;
    [SerializeField]
    private Train train = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leaver.transform.localRotation = Quaternion.Euler(BrakeLevel * angleFactor, 0f, 0f);

        train.BrakeStrength = 1f - BrakeLevel;
    }

    public float BrakeLevel
    {
        get; set;
    } = 0f;
}
