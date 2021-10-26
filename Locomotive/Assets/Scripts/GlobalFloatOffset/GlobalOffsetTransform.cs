using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalOffsetTransform : MonoBehaviour
{
    private Vector3 originalPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;

        if (GlobalOffsetManager.Inst != null)
        {
            GlobalOffsetManager.Inst.RegisterTransform(this);
            originalPosition -= GlobalOffsetManager.Inst.GlobalOffset;
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

    public void ApplyGlobalOffset(Vector3Int globalOffset)
    {
        if (IsActive)
        {
            transform.position = originalPosition + globalOffset;
        }
    }

    public bool IsActive
    {
        get; set;
    } = true;
}
