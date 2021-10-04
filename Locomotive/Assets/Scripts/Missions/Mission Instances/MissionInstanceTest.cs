using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInstanceTest : MissionInstance
{
    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();
    }

    public override void MissionStart()
    {
        base.MissionStart();
    }

    public override void EnterRailsegment(RailSegment railSegment)
    {
        base.EnterRailsegment(railSegment);
    }

    public override void StopInTrainstation(TrainStation trainStation)
    {
        base.StopInTrainstation(trainStation);
    }

    public override void PassTrigger(MissionTrigger missionTrigger)
    {
        base.PassTrigger(missionTrigger);
    }
}
