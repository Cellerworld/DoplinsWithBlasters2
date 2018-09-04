using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    private int waypointIndex = 1;
    public float speed;
    public GameObject[] waypoints;

    public float dropPercentage;
    public GameObject drop;
    private bool followingPlayer = false;
    public float maxFollowRange;
    public GameObject player;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = waypoints[0].transform.position;
    }

    private void Update()
    {
        CheckForGoal();
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
