using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedValve : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float angleFactor = 1f;

    [Space]

    [SerializeField]
    private Transform pointer = null;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pointer.localRotation = Quaternion.Euler(0f, 0f, ValveOpening * angleFactor);
    }

    public float ValveOpening
    {
        get; set;
    } = 0f;
}
