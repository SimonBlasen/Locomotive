using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightForrestAmbient : MonoBehaviour
{
    [SerializeField]
    private StudioEventEmitter studioEventEmitter = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        studioEventEmitter.SetParameter("Daytime", DayNightManager.Inst.HourOfDay);
    }
}
