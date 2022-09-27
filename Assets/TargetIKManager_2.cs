using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIKManager_2 : StateMachineBehaviour
{
    private AnimationEventManager animMgr;
    private Transform _lattina_3;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animMgr = animator.gameObject.GetComponent<AnimationEventManager>();
        _lattina_3 = GameObject.FindGameObjectWithTag("Spazzatura_3").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_lattina_3 != null)
            animMgr.RaccogliLattina(_lattina_3);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
