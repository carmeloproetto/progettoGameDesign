using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RaggiungiRagazzoState : StateMachineBehaviour
{
    private Transform _target;
    private Transform _dad;
    private float speed = 1.5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _target = GameObject.FindGameObjectWithTag("Ragazzino").transform;
        _dad = animator.gameObject.transform;

        float distance = Vector3.Magnitude(_dad.position - _target.position);
        float duration = distance / speed;

        _dad.DOMove(_target.position, duration).OnComplete(() => animator.SetTrigger("arrivato"));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _dad.LookAt(_target.position);
    }
}
