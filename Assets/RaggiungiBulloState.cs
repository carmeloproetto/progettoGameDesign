using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiBulloState : StateMachineBehaviour
{
    private Transform _bullo;
    private NavMeshAgent _agent;
    private bool arrived = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _bullo = GameObject.FindGameObjectWithTag("Bullo").transform;
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = 1.5f;
        _agent.updatePosition = true;
        _agent.updateRotation = true; 
        _agent.stoppingDistance = 0.4f;
        _agent.SetDestination(_bullo.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance && !arrived)
        {
            animator.SetTrigger("spingiBullo");
            arrived = true;
            _agent.updatePosition = false;
            _agent.updateRotation = false;
            _agent.speed = 0f; 
        }
    }
}
