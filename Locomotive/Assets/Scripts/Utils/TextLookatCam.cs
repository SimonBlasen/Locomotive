using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookatCam : MonoBehaviour
{
    private Transform cameraTrans = null;

    // Start is called before the first frame update
    void Start()
    {
        cameraTrans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt((transform.position - cameraTrans.position) + transform.position, Vector3.up);
    }
}
