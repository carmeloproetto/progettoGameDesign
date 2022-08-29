using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningState : StateMachineBehaviour
{
    float clipDuration; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "Turning")
                clipDuration = clip.length; 
        }
        Quaternion targetRotation = animator.transform.rotation * Quaternion.Euler(0, 180, 0);
        animator.GetComponent<FieldOfView>().TurningCorutine(clipDuration, targetRotation); 
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}
