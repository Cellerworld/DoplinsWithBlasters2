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

    }

    public override void Update(LittleBossAgent agent)
    {
        if(agent.GetDistanceBtwPlayerAndReturn() > agent.GetRange())
        {
            agent.SetState(LittleBossReturnState.GetInstance());
        }
        if(Vector3.Distance(agent.transform.position, agent.GetDestination()) > agent.GetAttackRange())
        {
            agent.SetState(LittleBossFollowPlayerState.GetInstance());
        }
        if(agent.GetCurrentTimeBtwAttacks() < 0)
        {
            //attack
        }
        else
        {
            agent.UpdateAttackTime();
        }
        //if time to attack do attack 
        //wait until time to attack
    
        //EXPLOSION!!
    }

    public override void Exit(LittleBossAgent agent)
    {
        
    }
}
