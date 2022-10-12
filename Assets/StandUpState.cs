using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //il padre raggiunge il punto di destinazione
        animator.gameObject.GetComponent<followDestinationDad>().enabled = true;
        //abilito il movimento della camera
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovmentCap3>().enabled = true;
    }
}
