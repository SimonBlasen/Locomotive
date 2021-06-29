using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSetting : MonoBehaviour
{
    public delegate void SwitchChangeEvent(int oldSwitchPos, int newSwitchPos);

    public event SwitchChangeEvent SwitchChange;


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
        int oldSetting = CurrentSetting;
        CurrentSetting = val;

        SwitchChange?.Invoke(oldSetting, CurrentSetting);
    }
}
