using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrainstationPerson : MonoBehaviour
{
    private NavMeshAgent navAgent = null;

    private float randomWalkTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();

        int randomWaitingArea = Random.Range(0, WaitingPlatform.waitingAreas.Length);
        transform.position = WaitingPlatform.waitingAreas[randomWaitingArea].position + new Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (randomWalkTimer <= 0f)
        {
            randomWalkTimer = Random.Range(1f, 15f);

            navAgent.SetDestination(transform.position + new Vector3(Random.Range(-20f, 20f), 0f, Random.Range(-20f, 20f)));
        }
    }

    public Platform WaitingPlatform
    {
        get; set;
    } = null;
}
