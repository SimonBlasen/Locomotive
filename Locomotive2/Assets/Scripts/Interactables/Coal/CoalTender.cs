using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalTender : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCoal = null;
    [SerializeField]
    private Vector3 coalLocalPos = Vector3.zero;

    private GameObject coalInHand = null;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && coalInHand != null)
        {
            RaycastHit hit;
            if (Physics.Raycast(cam.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, FirstPersonPlayer.RaycastDistance, LayerMask.GetMask("Interactable")))
            {
                Interactable interactable = hit.transform.GetComponent<InteractableCollider>().Interactable;

                if (interactable.GetType() == typeof(InteractableFire))
                {
                    ((InteractableFire)interactable).PutCoalIn(coalInHand.transform);
                    coalInHand = null;
                }
                else
                {
                    coalInHand.AddComponent<Rigidbody>();
                    coalInHand.transform.parent = null;
                    coalInHand = null;
                }
            }
            else
            {
                coalInHand.AddComponent<Rigidbody>();
                coalInHand.transform.parent = null;
                coalInHand = null;
            }
        }
    }

    public void TakeCoal()
    {
        if (coalInHand == null)
        {
            coalInHand = Instantiate(prefabCoal, cam.transform);

            coalInHand.transform.localPosition = coalLocalPos;
        }
    }
}
