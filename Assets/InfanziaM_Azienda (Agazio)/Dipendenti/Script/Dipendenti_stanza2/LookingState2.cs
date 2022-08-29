using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingState2 : StateMachineBehaviour
{
    private float _timer;
    private float _lookingTime;
    private GameObject _player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = 0f;
        _lookingTime = Random.Range(3f, 10f);
        animator.SetBool("isLooking", true);
        _player = GameObject.FindGameObjectWithTag("Player");

        animator.GetComponent<FieldOfView>().TurningCorutine(4f, Quaternion.Euler(0, 180, 0));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;

        if(_player.GetComponent<PlayerController_Agazio>().velocity > 1.9f && _player.GetComponent<PlayerController_Agazio>()._isBehindChest)
        {
            animator.SetBool("isChasing", true);
            //_player.GetComponent<PlayerController>().DisableJump();
            //_player.GetComponent<PlayerController>().DisableInput();
            Debug.Log("Troppo veloce!");
        }

        if (_timer >= _lookingTime && animator.GetBool("isLooking"))
        {
            animator.SetBool("isLooking", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isLooking", false);
    }
}
