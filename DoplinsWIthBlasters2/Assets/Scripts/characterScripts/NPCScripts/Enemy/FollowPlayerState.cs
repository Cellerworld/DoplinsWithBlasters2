using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class FollowPlayerState : AbstractState
{
    private static FollowPlayerState _instance;

    public static FollowPlayerState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new FollowPlayerState();
        }
        return _instance;
    }

    public override void Enter(EnemyAgent agent)
    {
        agent.GetNavMeshAgent().isStopped = false;
        agent.SetPlayerTarget();
    }

    public override void Update(EnemyAgent agent)
    {
        //update position of the player
        agent.SetPlayerTarget();

        if(Vector3.Distance(agent.GetNavMeshAgent().destination, agent.transform.position) < agent.GetAttackRange() + 0.5f)
        {
            agent.SetState(AttackState.GetInstance());
        }
        if(Vector3.Distance(agent.GetNavMeshAgent().destination, agent.transform.position) > agent.GetFollowRange() + 0.5f)
        {
            if (agent.GetIsWaveEnemy() == false)
            {
                agent.SetState(PatrolState.GetInstance());
            }
            else
            {
                agent.SetState(ChargeBaseState.GetInstance());
            }
        }
    }

    public override void Exit(EnemyAgent agent)
    {
    }
}
