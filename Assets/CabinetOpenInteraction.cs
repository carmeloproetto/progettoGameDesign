using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetOpenInteraction : InteractableObject
{
    private Cabinet _cabinet;

    public override bool Interact()
    {
        _cabinet.OpenDoors();
        this.interactable = false;
        this.GetComponent<BoxCollider>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionManager>().uiEnabledOntriggerStay = false;
        return true; 
    }

    protected override void Start()
    {
        _cabinet = this.GetComponentInParent<Cabinet>();
    }

    protected override void Update()
    {
    }
}
