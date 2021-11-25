using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightDirLight : MonoBehaviour
{
    [SerializeField]
    private Transform pivotTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = DayNightManager.Inst.HourOfDay * 360f / 24f;
        pivotTransform.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }
}
