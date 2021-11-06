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
    private Transform[] pointers = null;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < pointers.Length; i++)
        {
            pointers[i].localRotation = Quaternion.Euler(0f, 0f, ValveOpening * angleFactor);
        }
    }

    public float ValveOpening
    {
        get; set;
    } = 0f;
}
