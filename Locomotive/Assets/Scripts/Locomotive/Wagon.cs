using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : TrainPart
{
    [Header("References")]
    [SerializeField]
    private Transform[] doorPositions = null;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public Transform[] DoorPositions
    {
        get
        {
            return doorPositions;
        }
    }

    public Transform RandomDoor()
    {
        return doorPositions[Random.Range(0, doorPositions.Length)];
    }
}
