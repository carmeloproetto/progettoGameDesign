using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMiniGame : MonoBehaviour
{
    public GameObject dad;

    private void OnTriggerEnter(Collider collider){
        Debug.Log("Siamo dentro il triggere finale");
        if(collider.CompareTag("Player")){
            dad.GetComponent<PadreStudenteController>().startRun = false;
        }
    }
}
