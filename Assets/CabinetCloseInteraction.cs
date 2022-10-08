using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetCloseInteraction : InteractableObject
{
    private Cabinet _cabinet;
    public BoxCollider openTrigger; 

    public override bool Interact()
    {
        _cabinet.CloseDoors();
        this.GetComponent<BoxCollider>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionManager>().uiEnabledOntriggerStay = true;
        openTrigger.enabled = true;
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
