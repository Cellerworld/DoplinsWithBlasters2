using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBossFollowPlayerState : LittleBossState {

    private static LittleBossFollowPlayerState _instance;

    public static LittleBossFollowPlayerState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new LittleBossFollowPlayerState();
        }
        return _instance;
    }

    public override void Enter(LittleBossAgent agent)
    {
        agent.ActivateMoving();
        agent.SetPlayerAsDestination();
    }

    public override void Update(LittleBossAgent agent)
    {
        agent.SetPlayerAsDestination();
        if(Vector3.Distance(agent.GetDestination(), agent.transform.position) < agent.GetAttackRange())
        {
            agent.SetState(LittleBossAttackState.GetInstance());
        }
        if(agent.GetDistanceBtwPlayerAndReturn() > agent.GetRange())
        {
            agent.SetState(LittleBossReturnState.GetInstance());
        }
    }

    public override void Exit(LittleBossAgent agent)
    {

    }
}
