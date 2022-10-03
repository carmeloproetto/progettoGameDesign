using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class forwardBulloState : StateMachineBehaviour
{
    private GameObject _bullo;
    private NavMeshAgent _agent; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bullo = GameObject.FindGameObjectWithTag("Bullo");
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.speed = 1.5f;
        _agent.stoppingDistance = 0.5f; 
        _agent.SetDestination(_bullo.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_agent.remainingDistance <= _agent.stoppingDistance)
        {
            animator.SetBool("isWalking", false);
            _agent.speed = 0f;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
