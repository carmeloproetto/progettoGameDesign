using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingState : StateMachineBehaviour
{

    private Transform pos;
    private CharacterController _controller;
    private Vector3 _playerVelocity;

     override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PadreController_RetroAzienda>().enabled = false;
        //animator.applyRootMotion = false;
        pos = GameObject.FindGameObjectWithTag("Destination_3").transform;

        _controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

       _controller.Move((pos.position-animator.transform.position)*0.8f*Time.deltaTime);  

    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isHanging", false);
        animator.GetComponent<PadreController_RetroAzienda>().EnableInput();
        animator.GetComponent<PadreController_RetroAzienda>().EnableJump();

        GameObject.FindGameObjectWithTag("Player").GetComponent<PadreController_RetroAzienda>().enabled = true;
    }
}
