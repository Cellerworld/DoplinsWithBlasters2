using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBossReturnState : LittleBossState {

    private static LittleBossReturnState _instance;

    public static LittleBossReturnState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LittleBossReturnState();
        }
        return _instance;
    }

    public override void Enter(LittleBossAgent agent)
    {
        agent.ResetDestination();
    }

    public override void Update(LittleBossAgent agent)
    {
        //Debug.Log(Vector3.Distance(agent.GetDestination(), agent.transform.position));
        if(Vector3.Distance(agent.GetDestination(), agent.transform.position) < 0.5f)
        {
            agent.SetState(LittleBossIdleState.GetInstance());
        }
    }

    public override void Exit(LittleBossAgent agent)
    {
    }
}
