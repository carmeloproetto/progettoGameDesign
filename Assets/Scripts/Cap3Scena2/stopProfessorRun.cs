using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopProfessorRun : MonoBehaviour
{

    public GameObject professore;

    // Start is called before the first frame update
    /*void Start()
    {
        professore.GetComponent<PadreStudenteController>().startRun = false;
        professore.GetComponent<ProfessoreController>().enabled = false;
        //professore.GetComponent<DialogueTriggerCap3_1>().ink = dad.GetComponent<DialogueTriggerCap3_1>().inkJSON2;
        //professore.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
    }*/

    private void OnTriggerEnter(Collider collider){
        Debug.Log("Destinazione finale triggerata");
        if(collider.CompareTag("Professor")){
            professore.GetComponent<ProfessoreController>().profStartRun = false;
            professore.GetComponent<Animator>().SetFloat("Speed", 0f);
            professore.GetComponent<ProfessoreController>().enabled = false;
        }
    }
}
