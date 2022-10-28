using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FineCombattimentoState : StateMachineBehaviour
{
    private float timer = 0f;
    private float maxTime = 3f;
    private Animator _ragazzino; 

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<AnimationEventManager>().EndCombattimento();
        timer = 0f;
        _ragazzino = GameObject.FindGameObjectWithTag("Ragazzino").GetComponent<Animator>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            //Debug.Log("timer scaduto!");
            _ragazzino.SetTrigger("raggiungiBullo");
        }
    }
}
