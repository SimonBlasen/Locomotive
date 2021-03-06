using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrainstationPerson : MonoBehaviour
{
    private NavMeshAgent navAgent = null;

    private float randomWalkTimer = 5f;
    private float checkAreaCounter = 0f;

    private float enableNavMeshAgent = 0.05f;

    // TODO: Ticks on train needs to only work, if agent doesn't move anymore
    private int ticksOnTrainArea = 0;



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
        if (IsEnteringTrain == false)
        {
            randomWalkTimer -= Time.deltaTime;
            if (randomWalkTimer <= 0f)
            {
                randomWalkTimer = Random.Range(1f, 15f);

                if (HasPreviouslyExitedTrain)
                {
                }
                else
                {
                    //if (navAgent.velocity.magnitude < 0.05f)
                    //{
                    navAgent.SetDestination(Vector3.Lerp(WaitingPlatform.waitingAreaMinPos.position, WaitingPlatform.waitingAreaMaxPos.position, UnityEngine.Random.Range(0f, 1f)));
                    //}
                }
            }
        }

        checkAreaCounter += Time.deltaTime;

        if (checkAreaCounter >= 0.1f)
        {
            if (HasPreviouslyExitedTrain)
            {
                Vector2 exitPos = new Vector2(WaitingPlatform.waitingAreaMaxPos.position.x, WaitingPlatform.waitingAreaMaxPos.position.z);
                Vector2 selfPos = new Vector2(transform.position.x, transform.position.z);
                if (Vector2.Distance(exitPos, selfPos) <= 0.2f)
                {
                    Destroy(gameObject);
                }
            }

            checkAreaCounter = 0f;

            if (IsExitingTrain)
            {
                NavMeshHit hit;
                if (NavMesh.SamplePosition(transform.position, out hit, 3f, NavMesh.AllAreas))
                {
                    if ((hit.mask & (0x01 << NavMesh.GetAreaFromName("InTrain"))) == 0x0)
                    {
                        Debug.Log("Exiting person has existed");
                        IsExitingTrain = false;
                        navAgent.SetDestination(WaitingPlatform.platformExit.position);
                        CanEnterTrain = false;
                        randomWalkTimer = 1f;

                        Destroy(gameObject, Random.Range(20f, 25f));
                    }
                }
            }

            if (IsEnteringTrain)
            {
                Vector2 flatDest = new Vector2(navAgent.destination.x, navAgent.destination.z);
                Vector2 flatPos = new Vector2(transform.position.x, transform.position.z);
                // TODO: Ticks on train needs to only work, if agent doesn't move anymore
                if (Vector2.Distance(flatDest, flatPos) <= 0.5f)// || ticksOnTrainArea >= 10)
                {
                    Debug.Log("Person entered waggon");
                    List<TrainStation> possibleTrainstations = new List<TrainStation>();
                    possibleTrainstations.AddRange(TrainStation.AllTrainstations);
                    possibleTrainstations.Remove(OriginTrainstation);
                    //int randomDestStation = Random.Range(0, possibleTrainstations.Count);

                    TrainStation randomDestStation = PersonsManager.Inst.SampleDestinationTrainstation(possibleTrainstations);

                    DestinationTrain.PersonEntersTrain(this, randomDestStation);

                    Destroy(gameObject);
                }
                else
                {
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(transform.position, out hit, 3f, NavMesh.AllAreas))
                    {
                        if ((hit.mask & (0x01 << NavMesh.GetAreaFromName("InTrain"))) != 0x0)
                        {
                            ticksOnTrainArea++;
                        }
                    }
                }

            }
        }

        if (enableNavMeshAgent > 0f)
        {
            enableNavMeshAgent -= Time.deltaTime;

            if (enableNavMeshAgent <= 0f)
            {
                navAgent.enabled = true;
                if (toSetDestination != Vector3.zero)
                {
                    CanEnterTrain = canEnterTrain;
                    navAgent.SetDestination(toSetDestination);
                    toSetDestination = Vector3.zero;
                }
            }
        }
    }

    public Platform WaitingPlatform
    {
        get; set;
    } = null;

    private Vector3 toSetDestination = Vector3.zero;
    public Vector3 NavDestination
    {
        get
        {
            return navAgent.destination;
        }
        set
        {
            if (navAgent.enabled == false)
            {
                toSetDestination = value;
            }
            else
            {
                toSetDestination = Vector3.zero;
                navAgent.SetDestination(value);
            }
        }
    }



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

    public bool HasPreviouslyExitedTrain
    {
        get; set;
    } = false;

    public bool IsExitingTrain
    {
        get; set;
    } = false;

    public bool IsEnteringTrain
    {
        get; set;
    } = false;

    public Train DestinationTrain
    {
        get; set;
    } = null;

    public TrainStation DestinationTrainstation
    {
        get; set;
    } = null;

    public TrainStation OriginTrainstation
    {
        get; set;
    } = null;
}
