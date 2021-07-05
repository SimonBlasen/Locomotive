using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCorrector : MonoBehaviour
{
    [SerializeField]
    private Transform[] transformsToMove = null;
    [SerializeField]
    private Transform playerTransform = null;
    [SerializeField]
    private float maxDistance = 2000f;

    private Transform moveTrans = null;


    // Start is called before the first frame update
    void Start()
    {
        GameObject instGo = new GameObject("Float Corr Move Pivot");
        moveTrans = instGo.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 player2D = new Vector2(playerTransform.position.x, playerTransform.position.z);
        if (Vector2.Distance(player2D, Vector2.zero) >= maxDistance)
        {
            moveTrans.position = playerTransform.position;

            Transform[] oldParents = new Transform[transformsToMove.Length];
            for (int i = 0; i < transformsToMove.Length; i++)
            {
                oldParents[i] = transformsToMove[i].parent;
                transformsToMove[i].parent = moveTrans;
            }

            moveTrans.position = new Vector3(0f, moveTrans.position.y, 0f);

            for (int i = 0; i < transformsToMove.Length; i++)
            {
                transformsToMove[i].parent = oldParents[i];
            }
        }
    }
}
