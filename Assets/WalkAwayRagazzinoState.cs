using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAwayRagazzinoState : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private bool _arrived;
    private Transform _destination;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _arrived = false;
        _destination = GameObject.FindGameObjectWithTag("Destination_1").transform;
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = 1f;
        _agent.speed = 3.5f;
        _agent.updateRotation = true;
        _agent.updatePosition = true;
        _agent.SetDestination(_destination.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= 1f && !_arrived)
        {
            animator.gameObject.SetActive(false);
            _arrived = true;
            _agent.updatePosition = false;
            _agent.updateRotation = false;
            _agent.speed = 0f;
            Debug.Log(_agent.stoppingDistance);
        }
    }
}
