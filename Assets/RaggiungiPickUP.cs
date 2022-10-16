using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiPickUP : StateMachineBehaviour
{
    private Transform _target;
    private NavMeshAgent _agent;
    private bool destinationSetted = false;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _target = GameObject.FindGameObjectWithTag("Destination_4").transform;
        //animator.GetComponent<CharacterController>().enabled = false;
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.enabled = true;
        _agent.speed = 5f;
        _agent.stoppingDistance = 1f;
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.SetDestination(_target.position);
        destinationSetted = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!_agent.pathPending)
        {
            if (_agent.enabled && _agent.remainingDistance <= (_agent.stoppingDistance - 0.1f) && destinationSetted)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    _agent.speed = 0f;
                    _agent.updateRotation = false;
                    animator.SetTrigger("arrivato");
                    _agent.ResetPath();
                    _agent.enabled = false;
                }

            }

        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<DialogueManagerCap3_2>().disableSpace = false;
    }
}
