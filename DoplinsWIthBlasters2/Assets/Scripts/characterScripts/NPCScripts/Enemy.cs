using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    //use state machine instead!! work for friday
    //wandering enemy (patroling through the wood)
    //"agressive" enemy (running towards the base)
    //both attack player on sight

    public bool isSpawned;

    private int waypointIndex = 1;
    public GameObject[] waypoints;

    public float dropPercentage;
    public GameObject drop;
    private bool followingPlayer = false;
    public float maxFollowRange;
    public GameObject player;

    private NavMeshAgent agent;

    private void Start()
    {
        isSpawned = true;
        agent = GetComponent<NavMeshAgent>();
        if (isSpawned == false)
        {
            agent.destination = waypoints[0].transform.position;
        }
    }

    private void Update()
    {
        if (isSpawned == false)
        {
            CheckForGoal();
        }
        else
        {
            if(Vector3.Distance(transform.position, agent.destination) < 2/*magic number that needs to be the radius of the target + a part of the weapon*/)
            {
                //attack target (attack script is using input --> cant use it for enemy
                Debug.Log("CHARGEEEEE!");
            }
        }
        RaycastHit hit;
        if(Physics.SphereCast(transform.position + new Vector3(0.5f, 0.5f, 0.5f), 0.5f, transform.forward, out hit, 10))
        {
            if (hit.collider.tag == "Player")
            {
                followingPlayer = true;
            }
        }
        if(followingPlayer)
        {
            agent.destination = player.transform.position;
            if(Vector3.Distance(transform.position, player.transform.position) > maxFollowRange)
            {
                followingPlayer = false;
                agent.destination = waypoints[waypointIndex].transform.position;
            }
        }
    }

    private void CheckForGoal()
    {
        if(Vector3.Distance(transform.position, agent.destination) < 2f)
        {
            agent.destination = waypoints[waypointIndex].transform.position;
            waypointIndex++;
            waypointIndex = waypointIndex % waypoints.Length;
        }
    }

    private void OnDestroy()
    {
        int rnd = Random.Range(0, 100);
        if(dropPercentage >= rnd)
        {
            Instantiate(drop, new Vector3(transform.position.x, -0.25f, transform.position.z), Quaternion.identity);
        }
    }
}
