using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ChargeBaseState : AbstractState
{
    private static ChargeBaseState _instance;

    public static ChargeBaseState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new ChargeBaseState();
        }
        return _instance;
    }

    public override void Enter(EnemyAgent agent)
    {
        //set base as target
        agent.SetBaseTarget();
    }

    public override void Update(EnemyAgent agent)
    {
        //check if player is in his way if yes follow player
        if(Vector3.Distance(agent.GetNavMeshAgent().destination, agent.transform.position) < agent.GetAttackRange() + 0.5f)
        {
            agent.SetState(AttackBaseState.GetInstance());
        }
        RaycastHit hit;
        if (Physics.SphereCast(agent.transform.position + new Vector3(0.5f, 0.5f, 0.5f), 0.5f, agent.transform.forward, out hit, agent.GetFollowRange()))
        {
            if (hit.collider.tag == "Player")
            {
                agent.SetState(FollowPlayerState.GetInstance());
            }
        }
    }

    public override void Exit(EnemyAgent agent)
    {
    }
}
