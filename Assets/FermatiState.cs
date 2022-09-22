using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FermatiState : StateMachineBehaviour
{
    private float timer = 2f;
    private float curTime;
    private bool started = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        curTime = 0f;
        started = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        curTime += Time.deltaTime;
        if( curTime > timer && !started )
        {
            started = true;
            animator.SetTrigger("iniziaCombattimento");
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
