using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class forwardRagazzino : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private GameObject _ragazzino;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _ragazzino = GameObject.FindGameObjectWithTag("Ragazzino");
        _agent.stoppingDistance = 0.8f; 
        _agent.SetDestination(_ragazzino.transform.position - new Vector3(0f, 0.5f, 0f));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( _agent.remainingDistance <= 0.8f )
        {
            animator.SetBool("isWalking", false);
        }  
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
