using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGauge : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float angleFactor = 1f;

    [Space]

    [SerializeField]
    private Transform pointer = null;
    [SerializeField]
    private Train train = null;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TargetSpeed < 0f)
        {
            TargetSpeed = 0f;
        }

        train.TargetSpeed = TargetSpeed;

        pointer.localRotation = Quaternion.Euler(0f, 0f, train.CurrentSpeed * angleFactor);
    }

    public float TargetSpeed
    {
        get; set;
    } = 0f;
}
