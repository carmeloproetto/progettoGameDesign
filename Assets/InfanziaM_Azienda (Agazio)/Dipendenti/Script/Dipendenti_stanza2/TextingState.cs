using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextingState : StateMachineBehaviour
{
    private float _timer;
    private float _textingTime;
    private PlayerController_Agazio _pController; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0f;
        _textingTime = Random.Range(4f, 7f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;

        if (_timer >= _textingTime)
        {
            animator.SetBool("isLooking", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
