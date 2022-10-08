using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetInteractable : InteractableObject
{
    private Cabinet _cabinet;

    public override bool Interact()
    {
        if( _cabinet.isOpen )
        {
            _cabinet.CloseDoors();
            this.GetComponent<BoxCollider>().enabled = false; 
            return true; 
        }
        else if( !_cabinet.isOpen)
        {
            _cabinet.OpenDoors();
            this.GetComponent<BoxCollider>().enabled = false;
            return true; 
        }
        return false; 
    }

    protected override void Start()
    {
        _cabinet = this.GetComponentInParent<Cabinet>();
    }

    protected override void Update()
    {
        
    }
}
