using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{

    [SerializeField] Vector3 currentDestination;
[SerializeField] bool useClickToMove;
    NavMeshAgent agent;
    [SerializeField] Transform targetTR;
    [SerializeField] Transform[] waypoints;
    [SerializeField] Animator anim;
    [SerializeField] float velocity;
    [SerializeField] int currentWaypointIndex;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentDestination = waypoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (useClickToMove)
        {

            agent.destination = currentDestination;
            if (agent.remainingDistance < 1)
            {
                if (currentWaypointIndex < waypoints.Length)
                {
                    currentWaypointIndex++;
                }
                else
                {
                    currentWaypointIndex = 0;
                }
                currentDestination = waypoints[currentWaypointIndex].position;
            }

        }
        velocity = agent.velocity.magnitude;
        anim.SetFloat("Speed",velocity);
    }
}
