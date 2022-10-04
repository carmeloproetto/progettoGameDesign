using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class triggerDialogueBulloRagazzino : MonoBehaviour
{
    public Camera cam;
    public GameObject dad;

    private void OnTriggerEnter(Collider collider){
        
        if(collider.CompareTag("Player")){
            cam.GetComponent<CameraFollow>().destinationReached = false;
            cam.GetComponent<CameraFollow>().target_aux = cam.GetComponent<CameraFollow>().target3;
            //dad.GetComponent<PlayerController>().enabled = false;
            //dad.GetComponent<Animator>().SetFloat("Speed", 0);
            dad.GetComponent<PlayerController>().DisableInput();
            dad.GetComponent<PlayerController>().DisableJump();
            dad.GetComponent<NavMeshAgent>().enabled = true;
            //dad.GetComponent<Animator>().applyRootMotion = true; 
            StartCoroutine(startConv());
        }
    }

    IEnumerator startConv(){
        yield return new WaitForSeconds(1.5f);
        this.GetComponent<DialogueTrigger>().startConv = true;
    }
}
