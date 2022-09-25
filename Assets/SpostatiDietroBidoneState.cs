using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpostatiDietroBidoneState : StateMachineBehaviour
{
    private Transform _destination;
    private NavMeshAgent _agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _destination = GameObject.FindGameObjectWithTag("Destination_2").transform;
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.SetDestination(_destination.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            animator.SetTrigger("calciaBidone");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
