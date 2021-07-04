using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTerrainManager : MonoBehaviour
{
    [SerializeField]
    private float checkInterval = 1f;
    [SerializeField]
    private float distanceTillRender = 1f;
    [SerializeField]
    private Transform player = null;

    private SingleTerrain[] allTerrains = null;

    private float checkCounter = 0f;

    // Start is called before the first frame update
    void Start()
    {
        allTerrains = FindObjectsOfType<SingleTerrain>();
    }

    // Update is called once per frame
    void Update()
    {
        checkCounter += Time.deltaTime;

        if (checkCounter >= checkInterval)
        {
            checkCounter = 0f;

            for (int i = 0; i < allTerrains.Length; i++)
            {
                Vector3 closestPoint = allTerrains[i].BoxCollider.ClosestPointOnBounds(player.position);
                float distance = Vector2.Distance(new Vector2(player.position.x, player.position.z), new Vector2(closestPoint.x, closestPoint.z));

                if (distance <= distanceTillRender)
                {
                    if (allTerrains[i].Terrain.gameObject.activeSelf == false)
                    {
                        allTerrains[i].Terrain.gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (allTerrains[i].Terrain.gameObject.activeSelf)
                    {
                        allTerrains[i].Terrain.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
