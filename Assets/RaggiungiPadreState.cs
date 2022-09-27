using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiPadreState : StateMachineBehaviour
{
    private Transform _padre;
    private NavMeshAgent _agent;
    private bool arrived = false; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _padre = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = 1.5f;
        _agent.stoppingDistance = 1f;
        _agent.updatePosition = true;
        _agent.updateRotation = true; 
        _agent.SetDestination(_padre.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= 1f && !arrived )
        {
            animator.SetTrigger("arrivato");
            arrived = true;
            _agent.speed = 0f; 
            _agent.updatePosition = false;
            _agent.updateRotation = false;
            _agent.SetDestination(GameObject.FindGameObjectWithTag("Destination_1").transform.position);
            Debug.Log(_agent.stoppingDistance);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
