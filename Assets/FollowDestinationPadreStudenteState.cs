using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FollowDestinationPadreStudenteState : StateMachineBehaviour
{
    private Transform _destination;
    private NavMeshAgent _agent; 
    private GameObject levelLoader;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _destination = GameObject.FindGameObjectWithTag("Destination_1").transform;
        levelLoader = GameObject.FindGameObjectWithTag("LevelLoader");
        _agent = animator.gameObject.GetComponent<NavMeshAgent>();
        _agent.speed = 2f;
        _agent.SetDestination(_destination.position);
        animator.SetBool("IsWalking", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if( _agent.remainingDistance <= _agent.stoppingDistance + 0.1f )
        {
            Debug.Log("Arrivato a destinazione");
            animator.SetBool("IsWalking", false);
            _agent.speed = 0f;
            _agent.updateRotation = false;
            levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;

        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
