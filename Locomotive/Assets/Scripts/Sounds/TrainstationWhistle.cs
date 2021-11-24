using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainstationWhistle : MonoBehaviour
{
    [SerializeField]
    private StudioEventEmitter soundEventEmitter = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static TrainstationWhistle inst = null;
    public static TrainstationWhistle Inst
    {
        get
        {
            if (inst == null)
            {
                inst = FindObjectOfType<TrainstationWhistle>();
            }
            return inst;
        }
    }

    public void BlowWhistle()
    {
        soundEventEmitter.Play();
    }
}
