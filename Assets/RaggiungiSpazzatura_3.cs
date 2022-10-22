using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiSpazzatura_3 : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private Transform _spazzatura_1;
    private bool arrived = false;
    private GameObject canvas2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>(); 
        _spazzatura_1 = GameObject.FindGameObjectWithTag("Spazzatura_3").transform;

        _agent.speed = 1.5f;
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.stoppingDistance = 0.5f;
        _agent.SetDestination(_spazzatura_1.position);
        _agent.transform.DOLookAt(_spazzatura_1.position, 1f, AxisConstraint.Y, Vector3.up);

        canvas2 = GameObject.FindGameObjectWithTag("Canvas2");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.transform.LookAt(_spazzatura_1.position, Vector3.up);

        if (_agent.remainingDistance <= _agent.stoppingDistance && !arrived)
        {
            animator.SetTrigger("arrivato");
            arrived = true;
            _agent.speed = 0f;
            _agent.updatePosition = false;
            _agent.updateRotation = false;
            _agent.ResetPath();
        }
        else if (!_agent.hasPath)
        {
            Debug.Log("nessun path!!");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameControllerQTESpazzatura.aux = false;
        GameControllerQTESpazzatura.countDialogueQte = 2;
        canvas2.GetComponent<GameControllerQTESpazzatura>().enabled = true;
        canvas2.GetComponent<Canvas>().enabled = true;
    }
}
