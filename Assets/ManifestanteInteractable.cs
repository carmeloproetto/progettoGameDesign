using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ManifestanteInteractable : InteractableObject
{
    public Transform player;
    public Transform manifestante;

    public override bool Interact()
    {
        //ruoto il bambino verso lo scoiattolo
        player.DOLookAt(manifestante.position, 1f, AxisConstraint.Y, Vector3.up);

        return true;
    }

    protected override void Start()
    {

    }

    protected override void Update()
    {

    }
}
