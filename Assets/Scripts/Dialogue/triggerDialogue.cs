using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDialogue : MonoBehaviour
{
    public GameObject dlgManger;


    private void OnTriggerEnter(Collider collider){
        
        if(collider.name == "MadreBambina"){
            dlgManger.GetComponent<DialogueManager>().ContinueStoryByOtherScript();
        }
    }

    private void OnTriggerExit(Collider collider){
       
    }
}
