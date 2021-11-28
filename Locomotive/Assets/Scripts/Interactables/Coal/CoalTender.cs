using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalTender : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabCoal = null;
    [SerializeField]
    private Vector3 coalLocalPos = Vector3.zero;
    [SerializeField]
    private float maxTenderFill = 1000f;
    [SerializeField]
    private float weightPerCoal = 0.5f;
    [SerializeField]
    private CoalKGAmount coalKGAmount = null;
    [SerializeField]
    private Canvas explodeCanvas = null;


    private GameObject coalInHand = null;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        coalKGAmount.CoalWeight = maxTenderFill;
        coalKGAmount.MaxCoalWeight = maxTenderFill;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(0)) && coalInHand != null)
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

        if (coalKGAmount.CoalWeight <= 0f)
        {
            explodeCanvas.enabled = true;
        }
    }

    public void TakeCoal()
    {
        if (coalInHand == null)
        {
            if (coalKGAmount.CoalWeight > 0f)
            {
                coalKGAmount.CoalWeight -= weightPerCoal;
                coalInHand = Instantiate(prefabCoal, cam.transform);

                coalInHand.transform.localPosition = coalLocalPos;
            }
        }
    }
}
