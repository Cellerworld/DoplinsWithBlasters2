using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBaseState : AbstractState
{
    private static AttackBaseState _instance;

    public static AttackBaseState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new AttackBaseState();
        }
        return _instance;
    }

    public override void Enter(EnemyAgent agent)
    {
        agent.GetNavMeshAgent().isStopped = true;
        agent.ResetAttack();
        //start attack animation
        agent.Attack();
    }

    public override void Update(EnemyAgent agent)
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

    public override void Exit(EnemyAgent agent)
    {
    }
}
