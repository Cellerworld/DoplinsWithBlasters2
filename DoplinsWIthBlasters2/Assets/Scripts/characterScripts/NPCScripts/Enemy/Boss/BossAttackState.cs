using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossAbstractState
{

    private static BossAttackState _instance;

    public static BossAttackState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BossAttackState();
        }
        return _instance;
    }

    public override void Enter(BossAgent agent)
    {
        agent.Attack();
    }

    public override void Update(BossAgent agent)
    {
        if (agent.GetIsPlayerInAttackRange())
        {
            agent.SetState(GetInstance());
        }
        else if (agent.GetIsPlayerInRange())
        {
            agent.SetState(BossFollowPlayerState.GetInstance());
        }
        else if (agent.GetIsBaseInAttackRange())
        {
            agent.SetState(GetInstance());
        }
        else
        {
            agent.SetState(BossChargeTownState.GetInstance());
        }
    }

    public override void Exit(BossAgent agent)
    {

    }
}
