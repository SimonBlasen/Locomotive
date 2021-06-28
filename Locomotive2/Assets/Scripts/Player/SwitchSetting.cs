using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CurrentSetting
    {
        get; protected set;
    }

    public void SetSwitch(int val)
    {
        CurrentSetting = val;
    }
}
