using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiSpazzatura_2 : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private Transform _spazzatura_1;
    private bool arrived = false; 
    private GameObject canvas2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _spazzatura_1 = GameObject.FindGameObjectWithTag("Spazzatura_2").transform;
        canvas2 = GameObject.FindGameObjectWithTag("Canvas2");
        _agent.speed = 1.5f;
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.stoppingDistance = 0.6f;
        _agent.SetDestination(_spazzatura_1.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var targetRotation = Quaternion.LookRotation(_spazzatura_1.transform.position - animator.transform.position);
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, targetRotation, 10f * Time.deltaTime);

        if (_agent.remainingDistance <= _agent.stoppingDistance && !arrived)
        {
            
            animator.SetTrigger("arrivato");
            arrived = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameControllerQTESpazzatura.aux = false;
        GameControllerQTESpazzatura.countDialogueQte = 1;
        canvas2.GetComponent<GameControllerQTESpazzatura>().enabled = true;
        canvas2.GetComponent<Canvas>().enabled = true;
    }
}
