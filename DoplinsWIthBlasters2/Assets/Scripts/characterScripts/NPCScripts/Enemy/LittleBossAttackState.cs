using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBossAttackState : LittleBossState {

    private static LittleBossAttackState _instance;

    public static LittleBossAttackState GetInstance()
    {
        if(_instance == null)
        {
            _instance = new LittleBossAttackState();
        }
        return _instance;
    }

    public override void Enter(LittleBossAgent agent)
    {
        agent.GetRigidbody().velocity = Vector3.zero;
        agent.GetNavMeshAgent().isStopped = true;
        agent.SetAnimation(true);
        agent.ResetAttack();
        agent.Attack();
    }

    public override void Update(LittleBossAgent agent)
    {
        agent.SetPlayerAsDestination();
        if (agent.GetDistanceBtwPlayerAndReturn() > agent.GetRange())
        {
            agent.SetState(LittleBossReturnState.GetInstance());
        }
        Debug.Log(Vector3.Distance(agent.transform.position, agent.GetDestination()));
        if(Vector3.Distance(agent.transform.position, agent.GetDestination()) > agent.GetAttackRange())
        {
            agent.SetState(LittleBossFollowPlayerState.GetInstance());
        }
        if(agent.GetCurrentTimeBtwAttacks() < 0)
        {
            agent.Attack();
        }
        else
        {
            agent.UpdateAttackTime();
        }
    
        //insert EXPLOSION!!
    }

    public override void Exit(LittleBossAgent agent)
    {
        agent.GetNavMeshAgent().isStopped = false;
        agent.SetAnimation(false);
    }
}
