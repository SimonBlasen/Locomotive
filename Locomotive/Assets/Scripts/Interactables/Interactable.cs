using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected InteractableCollider interactableCollider;

    [SerializeField]
    private GameObject hoveredObj = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        interactableCollider.Interactable = this;
        Hovered = false;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public bool Hovered
    {
        get
        {
            return hoveredObj.activeSelf;
        }
        set
        {
            hoveredObj.SetActive(value);
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacted with something");
    }

    public virtual void InteractUp()
    {

    }
}
