using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPlayer : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float mouseRotSpeed = 1f;
    [SerializeField]
    private float movementSpeed = 1f;
    [SerializeField]
    private float raycastDistance = 0.3f;

    [Space]

    [SerializeField]
    private Transform yCamRot = null;
    [SerializeField]
    private Transform xCamRot = null;
    [SerializeField]
    private Transform minLocomotivePos = null;
    [SerializeField]
    private Transform maxLocomotivePos = null;

    private Camera cam;

    private Interactable currentHoveredInteractable = null;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        yCamRot.Rotate(0f, mouseRotSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), 0f);
        xCamRot.Rotate(mouseRotSpeed * Time.deltaTime * Input.GetAxis("Mouse Y") * -1f, 0f, 0f);


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        transform.position += yCamRot.forward * movementSpeed * movement.z;
        transform.position += yCamRot.right * movementSpeed * movement.x;

        if (transform.localPosition.x < minLocomotivePos.localPosition.x)
        {
            transform.localPosition = new Vector3(minLocomotivePos.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x > maxLocomotivePos.localPosition.x)
        {
            transform.localPosition = new Vector3(maxLocomotivePos.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        }

        if (transform.localPosition.y < minLocomotivePos.localPosition.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, minLocomotivePos.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.y > maxLocomotivePos.localPosition.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, maxLocomotivePos.localPosition.y, transform.localPosition.z);
        }

        if (transform.localPosition.z < minLocomotivePos.localPosition.z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, minLocomotivePos.localPosition.z);
        }
        if (transform.localPosition.z > maxLocomotivePos.localPosition.z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, maxLocomotivePos.localPosition.z);
        }

        RaycastHit hit;
        if (Physics.Raycast(cam.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, raycastDistance, LayerMask.GetMask("Interactable")))
        {
            Interactable interactable = hit.transform.GetComponent<InteractableCollider>().Interactable;
            if (currentHoveredInteractable != interactable && currentHoveredInteractable != null)
            {
                currentHoveredInteractable.Hovered = false;
            }
            currentHoveredInteractable = interactable;
            currentHoveredInteractable.Hovered = true;
        }
        else
        {
            if (currentHoveredInteractable != null)
            {
                currentHoveredInteractable.InteractUp();
                currentHoveredInteractable.Hovered = false;
                currentHoveredInteractable = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentHoveredInteractable != null)
            {
                currentHoveredInteractable.Interact();
            }
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            if (currentHoveredInteractable != null)
            {
                currentHoveredInteractable.InteractUp();
            }
        }
    }
}
