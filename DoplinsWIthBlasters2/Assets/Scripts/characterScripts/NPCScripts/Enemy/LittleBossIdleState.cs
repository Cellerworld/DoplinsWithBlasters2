using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBossIdleState : LittleBossState {

    private static LittleBossIdleState _instance;

    public static LittleBossIdleState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LittleBossIdleState();
        }
        return _instance;
    }

    public override void Enter(LittleBossAgent agent)
    {
        agent.DeactivateMoving();
    }

    public override void Update(LittleBossAgent agent)
    {
        if(agent.GetDistanceBtwPlayerAndReturn() < agent.GetRange())
        {
            Debug.Log("Player is in reach");
            agent.SetState(LittleBossFollowPlayerState.GetInstance());
        }
    }

    public override void Exit(LittleBossAgent agent)
    {
    }
}
