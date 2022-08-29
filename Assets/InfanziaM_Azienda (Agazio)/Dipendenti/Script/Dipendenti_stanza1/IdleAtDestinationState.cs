using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleAtDestinationState : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player; 


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    /*public IEnumerator RotateToDirection(Transform transform, Vector3 positionToLook, float timeToRotate)
    {
        var startRotation = transform.rotation;
        var direction = positionToLook - transform.position;
        var finalRotation = Quaternion.LookRotation(direction);

        var t = 0f;
        while( t <= 1f)
        {
            t += Time.deltaTime / timeToRotate;
            transform.rotation = Quaternion.Slerp(startRotation, finalRotation, t);
            yield return null;
        }
        transform.rotation = finalRotation;
    }*/
}
