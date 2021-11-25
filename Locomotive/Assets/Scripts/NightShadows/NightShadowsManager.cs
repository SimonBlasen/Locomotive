using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightShadowsManager : MonoBehaviour
{
    [SerializeField]
    private Train train = null;
    [SerializeField]
    private GameObject prefabNightShadows = null;
    [SerializeField]
    private int instancesAmount = 0;


    private int oldInstancesAmount = 0;

    private List<NightShadow> instShadows = new List<NightShadow>();


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
}
