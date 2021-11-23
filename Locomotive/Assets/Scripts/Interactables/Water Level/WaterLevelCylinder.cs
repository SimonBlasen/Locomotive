using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelCylinder : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float fullFill = 2000f;
    [SerializeField]
    private float waterUseupFactor = 1f;
    [SerializeField]
    private float refillSpeed = 1f;

    [Space]

    [SerializeField]
    private Transform pivotTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        currentFill = fullFill;
        refreshCylinderTransform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseupWater(float pressureDelta)
    {
        currentFill -= waterUseupFactor * pressureDelta;
        currentFill = Mathf.Clamp(currentFill, 0f, fullFill);
        refreshCylinderTransform();
    }

    private float currentFill = 1f;
    public float WaterFill
    {
        get
        {
            return currentFill;
        }
        set
        {
            currentFill = Mathf.Clamp(value, 0f, fullFill);
            refreshCylinderTransform();
        }
    }

    private void refreshCylinderTransform()
    {
        pivotTransform.localScale = new Vector3(1f, currentFill / fullFill, 1f);
    }

    public void Refill(float deltaTime)
    {
        WaterFill += refillSpeed * deltaTime;
    }
}
