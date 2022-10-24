using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingStateEnemy3 : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Transform destination;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isWalking", true);
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        destination = GameObject.FindGameObjectWithTag("Destination_3").transform;
        agent.ResetPath();
        agent.SetDestination(destination.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("isLooking", true);
            agent.SetDestination(agent.transform.position);
            agent.speed = 0f;
            animator.SetBool("isWalking", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("uscita stato di walking");
    }
}
