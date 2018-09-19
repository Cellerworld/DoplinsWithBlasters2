using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayerState : BossAbstractState
{

    private static BossFollowPlayerState _instance;

    public static BossFollowPlayerState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BossFollowPlayerState();
        }
        return _instance;
    }

    public override void Enter(BossAgent agent)
    {

    }

    public override void Update(BossAgent agent)
    {
        agent.SetPlayerAsTarget();
        if (agent.GetIsPlayerInAttackRange())
        {
            agent.SetState(BossAttackState.GetInstance());
        }
        if (!agent.GetIsPlayerInRange())
        {
            agent.SetState(BossChargeTownState.GetInstance());
        }
    }

    public override void Exit(BossAgent agent)
    {

    }
}
