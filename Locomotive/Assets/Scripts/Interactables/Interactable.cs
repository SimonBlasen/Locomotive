using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected InteractableCollider interactableCollider;
    [SerializeField]
    protected InteractableCollider[] interactableCollidersAdditional = new InteractableCollider[0];

    [SerializeField]
    private GameObject hoveredObj = null;
    [SerializeField]
    private GameObject[] hoveredObjsAdditional = new GameObject[0];

    [SerializeField]
    protected TextMeshPro textMeshHint = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        interactableCollider.Interactable = this;
        for (int i = 0; i < interactableCollidersAdditional.Length; i++)
        {
            interactableCollidersAdditional[i].Interactable = this;
        }
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
            if (hoveredObj == null)
            {
                return false;
            }
            return hoveredObj.activeSelf;
        }
        set
        {
            if (hoveredObj != null)
            {
                hoveredObj.SetActive(value);
            }

            for (int i = 0; i < hoveredObjsAdditional.Length; i++)
            {
                hoveredObjsAdditional[i].SetActive(value);
            }

            if (textMeshHint != null)
            {
                textMeshHint.enabled = value;
            }
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
