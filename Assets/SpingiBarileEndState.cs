using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpingiBarileEndState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PadreController_RetroAzienda>().EnableInput();
        animator.GetComponent<PadreController_RetroAzienda>().EnableJump();
        animator.GetComponent<PadreController_RetroAzienda>().EnableBackward();
        animator.GetComponent<PadreController_RetroAzienda>().maxVelocity = 2f;

        GameObject.FindGameObjectWithTag("Barile").transform.parent = null;
        GameObject.FindGameObjectWithTag("Barile").GetComponent<PushingRotation>().isPushing = false;
        //GameObject.FindGameObjectWithTag("Barile").GetComponent<Rigidbody>().mass = 100f;
    }
}
