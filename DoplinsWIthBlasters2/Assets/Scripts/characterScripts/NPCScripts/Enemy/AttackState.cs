using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AttackState : AbstractState
{
    private static AttackState _instance;

    public static AttackState GetInstance()
    {
        if(_instance == null)
        {
            _instance = new AttackState();
        }
        return _instance;
    }

    public override void Enter(EnemyAgent agent)
    {
        agent.GetRigidbody().velocity = Vector3.zero;
        agent.GetNavMeshAgent().isStopped = true;
        agent.SetAnimation(true);
        agent.ResetAttack();
        //start attack animation
        agent.Attack();
    }

    public override void Update(EnemyAgent agent)
    {
        //check if target still in attack range if yes attack again after ending the attack animation
        agent.SetPlayerTarget();
        //Debug.Log(Vector3.Distance(agent.GetNavMeshAgent().destination, agent.transform.position));
        if(Vector3.Distance(agent.GetNavMeshAgent().destination, agent.transform.position) < agent.GetAttackRange())
        {
            if (agent.GetCurrentTimeBtwAttacks() <= 0)
            {
                agent.Attack();
            }
            else
            {
                agent.AdjustAttackTime();
            }
        }
        else
        {
            agent.SetState(FollowPlayerState.GetInstance());
        }
    }

    public override void Exit(EnemyAgent agent)
    {
        Debug.Log("Dont run away coward!");
        agent.GetNavMeshAgent().isStopped = false;
        agent.SetAnimation(false);
    }
}
