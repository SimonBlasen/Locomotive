using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureReleaseValve : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float angleFactor = 1f;
    [SerializeField]
    private AnimationCurve animCurve = null;
    [SerializeField]
    private float animTime = 1f;
    [SerializeField]
    private Vector3Int turnAxe = Vector3Int.zero;

    [Space]

    [SerializeField]
    private Transform[] pointers = null;

    private float animS = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ReleasingAir && animS < 1f)
        {
            animS += Time.deltaTime / animTime;
        }
        else if (ReleasingAir == false && animS > 0f)
        {
            animS -= Time.deltaTime / animTime;
        }


        for (int i = 0; i < pointers.Length; i++)
        {
            float angle = animCurve.Evaluate(animS) * angleFactor;
            pointers[i].localRotation = Quaternion.Euler(turnAxe.x * angle, turnAxe.y * angle, turnAxe.z * angle);
        }
    }

    public bool ReleasingAir
    {
        get; set;
    } = false;
}
