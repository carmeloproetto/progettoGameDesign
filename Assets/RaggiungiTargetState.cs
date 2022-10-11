using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiTargetState : StateMachineBehaviour
{
    private Transform _target;
    private NavMeshAgent _agent;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovmentCap3>().enabled = true;
        animator.GetComponent<CharacterController>().enabled = false;
        _target = GameObject.FindGameObjectWithTag("Destination_1").transform;
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.enabled = true;
        _agent.speed = 2f;
        _agent.stoppingDistance = 0.2f; 
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.SetDestination(_target.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.gameObject.transform.LookAt(_target.position);
        if (!_agent.pathPending)
        {
            if (_agent.enabled && _agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    _agent.speed = 0f;
                    _agent.updateRotation = false;
                    animator.SetTrigger("arrivato");
                    _agent.ResetPath();
                    _agent.enabled = false;
                    animator.GetComponent<CharacterController>().enabled = true;
                    animator.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = true;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovmentCap3>().enabled = false;
                }

            }
        }
    }
}
