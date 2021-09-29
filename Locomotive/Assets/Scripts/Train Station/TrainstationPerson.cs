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
        init();
    }

    private bool inited = false;
    private void init()
    {
        if (!inited)
        {
            inited = true;
            navAgent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        randomWalkTimer -= Time.deltaTime;
        if (randomWalkTimer <= 0f)
        {
            randomWalkTimer = Random.Range(1f, 15f);

            if (navAgent.velocity.magnitude < 0.05f)
            {
                if (Vector3.Distance(navAgent.destination, navAgent.transform.position) <= 0.1f)
                {
                    if (IsExitingTrain)
                    {
                        Debug.Log("Exiting person has existed");
                        IsExitingTrain = false;
                        CanEnterTrain = false;
                    }
                }

                navAgent.SetDestination(Vector3.Lerp(WaitingPlatform.waitingAreaMinPos.position, WaitingPlatform.waitingAreaMaxPos.position, UnityEngine.Random.Range(0f, 1f)));
            }
        }
    }

    public Platform WaitingPlatform
    {
        get; set;
    } = null;



    private bool canEnterTrain = false;
    public bool CanEnterTrain
    {
        get
        {
            return canEnterTrain;
        }
        set
        {
            init();
            canEnterTrain = value;

            if (canEnterTrain)
            {
                navAgent.areaMask = -1;
            }
            else
            {
                navAgent.areaMask = (NavMesh.AllAreas) ^ (0x01 << NavMesh.GetAreaFromName("InTrain"));
            }
        }
    }

    public bool IsExitingTrain
    {
        get; set;
    } = false;

    public bool IsEnteringTrain
    {
        get; set;
    } = false;

    public TrainStation DestinationTrainstation
    {
        get; set;
    } = null;
}
