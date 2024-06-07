using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{

    [SerializeField] Transform target; // what to chase
    [SerializeField] Animator animator; // Controls the animation

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        
        agent.destination = target.position;

        // If the speed of the agent is greater than 0.1 ...
        if(agent.velocity.magnitude > 0.05f)
        {
            Debug.Log("Trying to run");
            //... then transition to running
            animator.SetBool("Running", true);
        }
        else
        {
            Debug.Log("Trying to stop");
            //... otherwise, transition to idle
            animator.SetBool("Running", false);
        }

    }
}
