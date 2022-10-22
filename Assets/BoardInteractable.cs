using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoardInteractable : InteractableObject
{
    public Transform player;
    public Transform board;

    public override bool Interact()
    {
        //disabilito input player
        player.GetComponent<PlayerController>().enabled = false;

        //ruoto il bambino verso la board
        player.DOLookAt(board.position, 1f, AxisConstraint.Y, Vector3.up).OnComplete(() => { /*player.GetComponent<Animator>().SetTrigger("ReadBoard")*/
            player.GetComponent<PlayerController>().enabled = true ;
        /*FAR PARTIRE DIALOGO LETTURA BOARD QUI;*/});

        return true; 
    }

    protected override void Start()
    {
        
    }

    protected override void Update()
    {
        
    }
}
