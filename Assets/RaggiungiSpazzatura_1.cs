using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class RaggiungiSpazzatura_1 : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private Transform _spazzatura_1;
    private bool arrived = false; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<CharacterController>().enabled = false;
        animator.GetComponent<PlayerController>().enabled = false; 
        _agent = animator.GetComponent<NavMeshAgent>();
        _spazzatura_1 = GameObject.FindGameObjectWithTag("Spazzatura_1").transform;

        _agent.speed = 1.5f;
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.stoppingDistance = 0.5f; 
        _agent.SetDestination(_spazzatura_1.position);
        _agent.transform.DOLookAt(_spazzatura_1.position, 1f, AxisConstraint.Y, Vector3.up);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.transform.LookAt(_spazzatura_1.position, Vector3.up);

        if( _agent.remainingDistance <= _agent.stoppingDistance && !arrived)
        {
            animator.SetTrigger("arrivato");
            _agent.speed = 0f;
            _agent.updatePosition = false;
            _agent.updateRotation = false;
            _agent.ResetPath();
            arrived = true; 
        }
        else if ( !_agent.hasPath)
        {
            Debug.Log("nessun path!!");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
