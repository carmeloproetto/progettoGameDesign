using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isHanging", false);
        animator.GetComponent<PadreController_RetroAzienda>().EnableInput();
        animator.GetComponent<PadreController_RetroAzienda>().EnableJump();
    }
}
