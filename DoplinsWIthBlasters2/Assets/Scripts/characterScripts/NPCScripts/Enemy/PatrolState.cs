using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : AbstractState
{
    private static PatrolState _instance;

    public static PatrolState GetInstance()
    {
        if (_instance == null)
        {
            _instance = new PatrolState();
        }
        return _instance;
    }

    public override void Enter(EnemyAgent agent)
    {
        agent.UpdateWaypoint();
    }

    public override void Update(EnemyAgent agent)
    {
        if(Vector3.Distance(agent.GetNavMeshAgent().destination, agent.transform.position) < 2.5f)
        {
            agent.UpdateWaypoint();
        }
        RaycastHit hit;
        if (Physics.SphereCast(agent.transform.position + new Vector3(0.5f, 0f, 0.5f), 0.5f, agent.transform.forward, out hit, agent.GetFollowRange()))
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
