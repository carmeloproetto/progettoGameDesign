using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FineQteSpazzaturaState : StateMachineBehaviour
{
    private GameObject canvas2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        canvas2 = GameObject.FindGameObjectWithTag("Canvas2");
         Debug.Log("Inizio ultima animazione QTE SPAZZATURA");
         GameControllerQTESpazzatura.aux = false;
            GameControllerQTESpazzatura.countDialogueQte = 3;
            canvas2.GetComponent<GameControllerQTESpazzatura>().enabled = true;
            canvas2.GetComponent<Canvas>().enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    /*override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Fine ultima animazione QTE SPAZZATURA");
        GameControllerQTESpazzatura.aux = false;
        GameControllerQTESpazzatura.countDialogueQte = 3;
        canvas2.GetComponent<GameControllerQTESpazzatura>().enabled = true;
        canvas2.GetComponent<Canvas>().enabled = true;
    }*/
}
