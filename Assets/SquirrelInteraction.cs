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
        player.GetComponent<PlayerController>().enabled = false;

        //ruoto il bambino verso lo scoiattolo
        player.DOLookAt(squirrel.position, 1f).OnComplete(() => player.GetComponent<Animator>().SetTrigger("SquirrelInteraction"));

        return true; 
    }

    protected override void Start()
    {
        
    }

    protected override void Update()
    {
        
    }
}
