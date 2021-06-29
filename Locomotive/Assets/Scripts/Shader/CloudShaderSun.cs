using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class CloudShaderSun : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer cloudShaderMeshRenderer = null;
    [SerializeField]
    private string shaderPropertyXID = "";
    [SerializeField]
    private string shaderPropertyYID = "";
    [SerializeField]
    private Transform sunDirectionalLight = null;

    private Material matCopy = null;

    
    // Start is called before the first frame update
    void Awake()
    {
        //matCopy = cloudShaderMeshRenderer.sharedMaterial;
        matCopy = new Material(cloudShaderMeshRenderer.sharedMaterial);
        cloudShaderMeshRenderer.sharedMaterial = matCopy;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = transform.rotation.eulerAngles.x;

        float sin = Mathf.Sin(angle * Mathf.PI / 180f);
        float cos = Mathf.Cos(angle * Mathf.PI / 180f);

        matCopy.SetFloat(shaderPropertyXID, sin);
        matCopy.SetFloat(shaderPropertyYID, cos);

        //Debug.Log("Sin: " + sin.ToString("n2"));
        //Debug.Log("Cos: " + cos.ToString("n2"));
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
