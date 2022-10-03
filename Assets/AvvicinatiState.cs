using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvvicinatiState : StateMachineBehaviour
{
    private Transform bullo;
    private NavMeshAgent _agent;
    private bool arrived = false; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bullo = GameObject.FindGameObjectWithTag("Bullo").transform;
        animator.GetComponent<PlayerController>().enabled = false; 
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.speed = 1.5f;
        _agent.stoppingDistance = 0.8f;
        _agent.SetDestination(bullo.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( _agent.remainingDistance <= 0.9f && !arrived )
        {
            Debug.Log("arrivati");
            arrived = true; 
            animator.SetTrigger("arrivato");
            _agent.speed = 0f;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
