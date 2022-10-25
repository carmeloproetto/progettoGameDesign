using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMiniGame : MonoBehaviour
{
    public GameObject dad;
    public GameObject professore;
    public GameObject ragazzo;

    private void OnTriggerEnter(Collider collider){
       
        if(collider.CompareTag("Player")){
             Debug.Log("Siamo dentro il triggere finale del padre, dobbiamo far partire il dialogo");
            dad.GetComponent<PadreStudenteController>().startRun = false;
            //dad.GetComponent<PadreStudenteController>().enabled = false;
            //ragazzo.GetComponent<RagazzoController>().enabled = false;
            //professore.GetComponent<ProfessoreController>().enabled = false;
            //professore.GetComponent<DialogueTriggerCap3_1>().ink = dad.GetComponent<DialogueTriggerCap3_1>().inkJSON;
            //professore.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
            dad.GetComponent<Animator>().SetFloat("Speed", 0f);
            dad.GetComponent<PadreStudenteController>().enabled = false;
            StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("QteCorsa", 3, 0.05f));
        }
    }
}
