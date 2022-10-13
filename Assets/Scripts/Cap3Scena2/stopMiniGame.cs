using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopMiniGame : MonoBehaviour
{
    public GameObject dad;
    public GameObject professore;
    public GameObject ragazzo;

    private void OnTriggerEnter(Collider collider){
        Debug.Log("Siamo dentro il triggere finale");
        if(collider.CompareTag("Player")){
            dad.GetComponent<PadreStudenteController>().startRun = false;
            //dad.GetComponent<PadreStudenteController>().enabled = false;
            //ragazzo.GetComponent<RagazzoController>().enabled = false;
            //professore.GetComponent<ProfessoreController>().enabled = false;
            dad.GetComponent<DialogueTriggerCap3_1>().ink = dad.GetComponent<DialogueTriggerCap3_1>().inkJSON2;
            dad.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
            dad.GetComponent<Animator>().SetFloat("Speed", 0f);
            dad.GetComponent<PadreStudenteController>().enabled = false;
            StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("QteCorsa", 3, 0.05f));
        }
    }
}
