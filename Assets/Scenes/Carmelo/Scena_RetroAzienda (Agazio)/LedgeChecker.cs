using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeChecker : MonoBehaviour
{
    private Ledge ledge;
    public bool isGrabbingLedge = false; 

    private void OnTriggerEnter(Collider other)
    {
        ledge = other.GetComponent<Ledge>();
        if( ledge != null)
        {
            isGrabbingLedge = true;
            this.GetComponentInParent<Animator>().SetBool("isHanging", true);
            GetComponentInParent<PadreController_RetroAzienda>().DisableInput();
            GetComponentInParent<PadreController_RetroAzienda>().DisableJump();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        ledge = other.GetComponent<Ledge>();
        if (ledge != null)
        {
            isGrabbingLedge = false;
        }
    }
}
