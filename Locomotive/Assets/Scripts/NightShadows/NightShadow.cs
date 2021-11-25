using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShadow : MonoBehaviour
{
    private float multipleOfDistanceSpawn = 4f;

    // Start is called before the first frame update
    void Start()
    {
        float randAngle = Random.Range(0f, 360f);

        transform.position = Train.Locomotive.transform.position + (Quaternion.Euler(0f, randAngle, 0f) * Vector3.forward) * NightShadowsManager.DistanceToLoc * multipleOfDistanceSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public NightShadowsManager NightShadowsManager
    {
        get; set;
    } = null;

    public Train Train
    {
        get; set;
    } = null;

    public void KillShadow()
    {

    }
}
