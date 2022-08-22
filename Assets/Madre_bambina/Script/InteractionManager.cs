using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private bool canInteract = false;

    private InteractableObject interactableObject;

    private void OnTriggerEnter(Collider other)
    {
        InteractableObject ob = other.gameObject.GetComponent<InteractableObject>(); 
        if(ob != null)
        {
            canInteract = true;
            interactableObject = ob; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObject ob = other.gameObject.GetComponent<InteractableObject>();
        if (ob != null)
        {
            canInteract = false;
            interactableObject = null;
        }
    }

    private void Update()
    {
        if( canInteract && Input.GetKeyDown(KeyCode.E) )
        {
            interactableObject.Interact(); 
        }
    }
}
