using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShadowsManager : MonoBehaviour
{
    [SerializeField]
    private Train train = null;
    [SerializeField]
    private float distanceToLoc = 0f;
    [SerializeField]
    private GameObject prefabNightShadows = null;
    [SerializeField]
    private int instancesAmount = 0;
    [SerializeField]
    private float distanceToLocMoveSpeed = 4f;


    private int oldInstancesAmount = 0;

    private List<NightShadow> instShadows = new List<NightShadow>();

    private float targetTrainDistance = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oldInstancesAmount != instancesAmount)
        {
            while (instShadows.Count < instancesAmount)
            {
                spawnShadow();
            }
            while (instShadows.Count > instancesAmount)
            {
                destroyShadow();
            }
            oldInstancesAmount = instancesAmount;
        }

        distanceToLoc = Mathf.MoveTowards(distanceToLoc, targetTrainDistance, Time.deltaTime * distanceToLocMoveSpeed);
        if (Mathf.Abs(distanceToLoc - targetTrainDistance) <= 0.1f)
        {
            targetTrainDistance = Random.Range(0f, 200f);
        }
    }

    private void spawnShadow()
    {
        GameObject instShadow = Instantiate(prefabNightShadows, transform);
        NightShadow nightShadow = instShadow.GetComponent<NightShadow>();
        nightShadow.NightShadowsManager = this;
        nightShadow.Train = train;

        instShadows.Add(nightShadow);
    }

    private void destroyShadow()
    {
        if (instShadows.Count > 0)
        {
            int randomDeletion = Random.Range(0, instShadows.Count);

            instShadows[randomDeletion].KillShadow();
            instShadows.RemoveAt(randomDeletion);
        }
    }

    public float DistanceToLoc
    {
        get
        {
            return distanceToLoc;
        }
    }
}
