using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoalKGAmount : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textMeshKG = null;
    [SerializeField]
    private float refillSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //textMeshKG.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private float coalWeight = 0f;
    public float CoalWeight
    {
        get
        {
            return coalWeight;
        }
        set
        {
            coalWeight = value;
            if (coalWeight < 0f)
            {
                coalWeight = 0f;
            }

            textMeshKG.text = coalWeight.ToString("n1") + " kg";
        }
    }

    public float MaxCoalWeight
    {
        get; set;
    }

    public void Refill(float deltaTime)
    {
        CoalWeight += refillSpeed * deltaTime;
        if (CoalWeight > MaxCoalWeight)
        {
            CoalWeight = MaxCoalWeight;
        }
    }
}
