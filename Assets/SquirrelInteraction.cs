using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SquirrelInteraction : InteractableObject
{
    public Transform player;
    public Transform squirrel;

    public override bool Interact()
    {
        //disabilito input player
        //player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerController>().DisableJump();
        player.GetComponent<PlayerController>().DisableInput();
        player.GetComponent<PlayerController>().DisableRotation();

        //ruoto il bambino verso lo scoiattolo
        player.DOLookAt(squirrel.position, 1f).OnComplete(() => player.GetComponent<Animator>().SetTrigger("SquirrelInteraction"));

        //disabilito interazione
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.interactable = false;
        return true; 
    }

    protected override void Start()
    {
        
    }

    protected override void Update()
    {
        
    }
}
