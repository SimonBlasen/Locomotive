using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInstanceTest : MissionInstance
{
    [Header("Settings")]
    [SerializeField]
    private float minimumFireTemp = 1f;

    private enum State
    {
        START_0, START_1, START_2, WAIT_FOR_TEMPERATURE, FIRE_TEMPERATURE_REACHED, 
    }

    private State state = State.START_0;

    private float stateChangeCounter = 0f;
    private State changeState = State.START_0;

    private float stateCheck = 0f;

    // Start is called before the first frame update
    protected new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected new void Update()
    {
        base.Update();

        if (stateChangeCounter > 0f)
        {
            stateChangeCounter -= Time.deltaTime;

            if (stateChangeCounter <= 0f)
            {
                goToState(changeState);
            }
        }

        stateCheck += Time.deltaTime;

        if (stateCheck >= 1f)
        {
            stateCheck = 0f;

            stateTick();
        }
    }

    public override void MissionStart()
    {
        base.MissionStart();

        goToState(State.START_1);
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

    private void goToState(State newState)
    {
        State oldState = state;
        state = newState;

        if (state == State.START_1)
        {
            showDialogue("Hello Text");

            stateChangeCounter = 8f;
            changeState = State.START_2;
        }
        else if (state == State.START_2)
        {
            showDialogue("Coal Introduction");

            state = State.WAIT_FOR_TEMPERATURE;
        }
        else if (state == State.FIRE_TEMPERATURE_REACHED)
        {
            showDialogue("Fire Temperature Reached");
        }
    }

    private void stateTick()
    {
        if (state == State.WAIT_FOR_TEMPERATURE)
        {
            if (Fire.Heat >= minimumFireTemp)
            {
                goToState(State.FIRE_TEMPERATURE_REACHED);
            }
        }
    }
}
