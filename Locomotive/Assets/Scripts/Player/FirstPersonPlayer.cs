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
    [SerializeField]
    private float minOutsideDistance = 1f;
    [SerializeField]
    private float maxOutsideDistance = 5f;
    [SerializeField]
    private float scrollSpeed = 1f;

    [SerializeField]
    private Transform outsideCamTrans = null;
    [SerializeField]
    private Transform outsideCamTransY = null;
    [SerializeField]
    private float outsideHeightMin = 1f;
    [SerializeField]
    private float outsideHeightMax = 1f;
    [SerializeField]
    private float outsideHeightSpeed = 1f;
    [SerializeField]
    private Transform debugRaycast = null;

    [SerializeField]
    private FMODUnity.StudioEventEmitter snapshotOutsideCam = null;

    private Camera cam;

    private Interactable currentHoveredInteractable = null;

    private bool camOutside = false;

    private Transform locomotiveTransform = null;

    private float lerpToInsideFor = 0f;
    private float curOutsideDistance = 0f;

    // Start is called before the first frame update
    void Start()
    {
        curOutsideDistance = minOutsideDistance;
        locomotiveTransform = transform.parent;
        cam = GetComponentInChildren<Camera>();
        RaycastDistance = raycastDistance;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (currentHoveredInteractable != null)
            {
                currentHoveredInteractable.Interact();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (currentHoveredInteractable != null)
            {
                currentHoveredInteractable.InteractUp();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
            camOutside = !camOutside;

            if (camOutside)
            {
                snapshotOutsideCam.Play();
                cam.transform.parent = null;
                GlobalOffsetManager.Inst.RegisterQuickfireTransform(cam.transform);
            }
            else
            {
                snapshotOutsideCam.Stop();
                cam.transform.parent = xCamRot;
                GlobalOffsetManager.Inst.DeregisterQuickfireTransform(cam.transform);
                lerpToInsideFor = 0.3f;
            }
        }
    }

    private void FixedUpdate()
    {



        Debug.DrawRay(cam.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)).origin, cam.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)).direction * raycastDistance);

        debugRaycast.position = cam.transform.position;
        debugRaycast.forward = cam.transform.forward;

        RaycastHit hit;
        //if (Physics.Raycast(cam.ScreenPointToRay(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, raycastDistance, LayerMask.GetMask("Interactable")))
        if (Physics.Raycast(new Ray(cam.transform.position, cam.transform.forward), out hit, raycastDistance, LayerMask.GetMask("Interactable")))
        {
            Interactable interactable = hit.transform.GetComponent<InteractableCollider>().Interactable;
            if (currentHoveredInteractable != interactable && currentHoveredInteractable != null)
            {
                currentHoveredInteractable.InteractUp();
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









        if (RotationsBlocked == false)
        {
            yCamRot.Rotate(0f, mouseRotSpeed * Time.fixedDeltaTime * Input.GetAxis("Mouse X"), 0f);
            outsideCamTransY.Rotate(0f, mouseRotSpeed * Time.fixedDeltaTime * Input.GetAxis("Mouse X"), 0f);
            outsideCamTrans.localPosition += new Vector3(0f, mouseRotSpeed * Time.fixedDeltaTime * Input.GetAxis("Mouse Y") * outsideHeightSpeed, 0f);
            outsideCamTrans.localPosition = new Vector3(outsideCamTrans.localPosition.x, Mathf.Clamp(outsideCamTrans.localPosition.y, outsideHeightMin, outsideHeightMax), outsideCamTrans.localPosition.z);
            if (camOutside == false)
            {
                xCamRot.Rotate(mouseRotSpeed * Time.fixedDeltaTime * Input.GetAxis("Mouse Y") * -1f, 0f, 0f);
            }
        }


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        transform.localPosition += transform.InverseTransformVector(yCamRot.forward * movementSpeed * movement.z * Time.fixedDeltaTime);
        transform.localPosition += transform.InverseTransformVector(yCamRot.right * movementSpeed * movement.x * Time.fixedDeltaTime);

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








        if (camOutside)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, outsideCamTrans.position + (outsideCamTrans.position - locomotiveTransform.position).normalized * curOutsideDistance, Time.fixedDeltaTime * 20f);

            cam.transform.rotation = Quaternion.Lerp(cam.transform.localRotation, Quaternion.LookRotation(locomotiveTransform.position - cam.transform.position, Vector3.up), Time.fixedDeltaTime * 40f);

            curOutsideDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;

            curOutsideDistance = Mathf.Clamp(curOutsideDistance, minOutsideDistance, maxOutsideDistance);
        }
        else
        {
            lerpToInsideFor -= Time.fixedDeltaTime;
            if (lerpToInsideFor > 0f)
            {
                cam.transform.position = Vector3.Lerp(cam.transform.position, xCamRot.position, Time.fixedDeltaTime * 20f);
                cam.transform.localRotation = Quaternion.Lerp(cam.transform.localRotation, Quaternion.identity, Time.fixedDeltaTime * 40f);
            }
        }
    }

    public static bool RotationsBlocked
    {
        get; set;
    } = false;

    public static float RaycastDistance
    {
        get; protected set;
    }
}
