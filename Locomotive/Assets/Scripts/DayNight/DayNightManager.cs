using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayNightManager : MonoBehaviour
{
    [SerializeField]
    private float minutesPerCycle = 5f;
    public float hourOfDay = 0f;


    public bool doIt = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Daytime", hourOfDay);

        if (doIt)
        {
            doIt = false;
            StudioEventEmitter[] see = FindObjectsOfType<StudioEventEmitter>();
            for (int i = 0; i < see.Length; i++)
            {
                Debug.Log(see[i].gameObject.name);
            }
        }

        hourOfDay += (Time.deltaTime / (minutesPerCycle * 60f)) * 24f;
        if (hourOfDay >= 24f)
        {
            hourOfDay -= 24f;
            Debug.Log("Midnight");
        }
    }


    private static DayNightManager inst = null;
    public static DayNightManager Inst
    {
        get
        {
            if (inst == null)
            {
                inst = FindObjectOfType<DayNightManager>();
            }
            return inst;
        }
    }

    public float HourOfDay
    {
        get
        {
            return hourOfDay;
        }
    }
}
