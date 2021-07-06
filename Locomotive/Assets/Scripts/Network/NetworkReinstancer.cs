using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkReinstancer : MonoBehaviour
{
    [SerializeField]
    private GameObject networkPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Restarting network...");

        Instantiate(networkPrefab);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
