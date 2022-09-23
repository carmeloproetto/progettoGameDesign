using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fermatiState_2 : StateMachineBehaviour
{
    private float timer = 0f;
    private float maxTime = 3f;
    private bool qteActive = false; 
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        qteActive = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;

        if( timer > maxTime && !qteActive )
        {
            //dopo 3 secondi faccio partire il QTE
            qteActive = true;
            Debug.Log("timer scaduto!");
            animator.gameObject.GetComponent<CombattimentoManager>().ActiveQTE(3);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
