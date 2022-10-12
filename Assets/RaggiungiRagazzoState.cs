using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiRagazzoState : StateMachineBehaviour
{
    private Transform _target;
    private NavMeshAgent _agent; 
    //private Transform _dad;
    //private float speed = 1.5f;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _target = GameObject.FindGameObjectWithTag("Ragazzino").transform;
        _agent = animator.GetComponent<NavMeshAgent>();
        animator.gameObject.GetComponent<CharacterController>().enabled = false;
        _agent.enabled = true; 
        _agent.speed = 2f;
        _agent.stoppingDistance = 0.8f;
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.SetDestination(_target.position);

        /*_target = GameObject.FindGameObjectWithTag("Ragazzino").transform;
        _dad = animator.gameObject.transform;

        float distance = Vector3.Magnitude(_dad.position - _target.position);
        float duration = distance / speed;

        _dad.DOMove(_target.position, duration).OnComplete(() => animator.SetTrigger("arrivato"));*/
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(_target.position);
        if( _agent.enabled && _agent.remainingDistance <= (_agent.stoppingDistance - 0.1f))
        {
            _agent.speed = 0f;
            _agent.updateRotation = false;
            animator.SetTrigger("arrivato");
            _agent.ResetPath();
            _agent.enabled = false; 
        }
    }
}
