using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalOffsetTransform : MonoBehaviour
{
    private 

    // Start is called before the first frame update
    void Start()
    {
        if (GlobalOffsetManager.Inst != null)
        {
            GlobalOffsetManager.Inst.RegisterTransform(this);
        }
        else
        {
            Debug.LogError("Didn't find GlobalOffsetManager for registration");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (GlobalOffsetManager.Inst != null)
        {
            GlobalOffsetManager.Inst.DeregisterTransform(this);
        }
        else
        {
            Debug.LogError("Didn't find GlobalOffsetManager for deregistration");
        }
    }
}
