using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PcInteractable : InteractableObject
{
    private PlayerController_Agazio _pController;
    private Animator _pAnimator; 

    public override bool Interact()
    {
        //can interact once
        interactable = false;
        
        //disable player inputs and jump
        _pController.DisableInput(); 
        _pController.DisableJump();

        //rotate the player towards the pc
        _pController.SetTargetDirection(Vector3.left);

        //play the interaction animation
        _pAnimator.SetTrigger("PushButton");
       
        return true; 
    }

    protected override void Start()
    {
        _pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Agazio>();
        _pAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>(); 
    }

    protected override void Update()
    {
    }
}
