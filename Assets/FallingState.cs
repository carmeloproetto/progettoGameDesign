using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class FallingState : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private Animator _bullo;
    private GameObject _padreBambino;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = 0.5f;
        _agent.updateRotation = false;
        _agent.SetDestination(animator.transform.position - new Vector3(1.6f, 0f, 0f));
        _bullo = GameObject.FindGameObjectWithTag("Bullo").GetComponent<Animator>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.speed = 1.5f;
        _agent.updateRotation = true;

        //il bullo vede il bambino (Padre)
        _bullo.SetTrigger("ArmGesture");
    }
}
