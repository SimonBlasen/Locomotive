using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudShaderSun : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer cloudShaderMeshRenderer = null;
    [SerializeField]
    private string shaderPropertyID = "";
    [SerializeField]
    private Transform sunDirectionalLight = null;

    private Material matCopy = null;

    // Start is called before the first frame update
    void Start()
    {
        //matCopy = cloudShaderMeshRenderer.sharedMaterial;
        matCopy = new Material(cloudShaderMeshRenderer.sharedMaterial);
        cloudShaderMeshRenderer.sharedMaterial = matCopy;
    }

    // Update is called once per frame
    void Update()
    {
        matCopy.SetFloat(shaderPropertyID, make0_360(sunDirectionalLight.rotation.eulerAngles.y));
    }

    private float make0_360(float angleVal)
    {
        while (angleVal < 0f)
        {
            angleVal += 360f;
        }

        angleVal = angleVal % 360f;

        return angleVal;
    }
}
