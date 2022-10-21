using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelInteractionState : StateMachineBehaviour
{
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<PlayerController>().enabled = true;
    }
}
