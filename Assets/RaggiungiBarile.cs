using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiBarile : StateMachineBehaviour
{
    private GameObject _destination;
    private NavMeshAgent _agent; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _destination = GameObject.FindGameObjectWithTag("Barile");
        _agent = animator.GetComponent<NavMeshAgent>();

        _agent.stoppingDistance = 1f;
        _agent.SetDestination(_destination.transform.position);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= 1.1f)
        {
            animator.SetBool("atDestination", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PadreController_RetroAzienda>().enabled = true;
        _agent.updateRotation = false; 
        //_agent.transform.DORotate(new Vector3(0f, -90f, 0f), 2f);
    }
}
