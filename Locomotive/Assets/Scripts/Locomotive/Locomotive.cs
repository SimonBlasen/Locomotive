using SplineMesh;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : TrainPart
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        GlobalOffsetManager.Inst.RegisterQuickfireTransform(transform);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
