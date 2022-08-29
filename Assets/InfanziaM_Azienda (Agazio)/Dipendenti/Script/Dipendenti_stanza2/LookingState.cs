using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingState : StateMachineBehaviour
{
    private float _timer;
    private float _lookingTime; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0f; 
        _lookingTime = Random.Range(3f, 10f);
        animator.SetBool("isLooking", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;

        if( _timer >= _lookingTime && animator.GetBool("isLooking") )
        {
            animator.SetTrigger("turnBack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isLooking", false);
        animator.transform.rotation = Quaternion.Euler(0, 180, 0);
        animator.ResetTrigger("turnBack");
    }
}
