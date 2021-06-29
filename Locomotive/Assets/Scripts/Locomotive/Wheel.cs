using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float wheelRadius = 1f;

    [Space]

    [Header("References")]
    [SerializeField]
    private Train train = null;

    private float factor = 270f;

    private float wheelCircumference = 0f;

    // Start is called before the first frame update
    void Start()
    {
        wheelCircumference = 2f * Mathf.PI * wheelRadius;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * train.curVelocity * factor / wheelCircumference, 0f, 0f, Space.Self);
    }
}
