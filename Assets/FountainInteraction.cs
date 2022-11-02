using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FountainInteraction : InteractableObject
{
    public Transform player;
    public Transform fountain;
    public AudioManager audioMgr; 

    public override bool Interact()
    {
        //disabilito input player
        //player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerController>().DisableInput();
        player.GetComponent<PlayerController>().DisableJump();
        player.GetComponent<PlayerController>().DisableRotation();

        //ruoto il bambino verso lo scoiattolo
        player.DOLookAt(fountain.position, 1f, AxisConstraint.Y, Vector3.up).OnComplete(() => player.GetComponent<Animator>().SetTrigger("FountainInteraction"));
        //DISATTIVARE PARTICLE SYSTEM FONTANA da animationEvents

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
