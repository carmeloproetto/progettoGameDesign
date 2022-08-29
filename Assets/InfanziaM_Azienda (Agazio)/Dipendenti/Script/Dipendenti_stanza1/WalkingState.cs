using UnityEngine.AI; 
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : StateMachineBehaviour
{
    NavMeshAgent _agent;
    GameObject _wayPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = 1.5f;

        _wayPoint = GameObject.FindGameObjectWithTag("Destination_1");

        _agent.SetDestination(_wayPoint.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            animator.SetBool("isAtDestination", true);
        }
    }
}
