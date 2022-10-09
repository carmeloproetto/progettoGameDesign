using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopProfessorRun : MonoBehaviour
{

    public GameObject professore;

    // Start is called before the first frame update
    void Start()
    {
        professore.GetComponent<PadreStudenteController>().startRun = false;
        professore.GetComponent<ProfessoreController>().enabled = false;
        //professore.GetComponent<DialogueTriggerCap3_1>().ink = dad.GetComponent<DialogueTriggerCap3_1>().inkJSON2;
        //professore.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
