using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlSceneScript : MonoBehaviour
{

    public GameObject dlgMng;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //è finito il minigioco degli scoiattoli
        if(dlgMng.GetComponent<DialogueManagerCap3_1>().QteScoiattoliEnd){
            this.GetComponent<DialogueTriggerCap3_1>().ink = this.GetComponent<DialogueTriggerCap3_1>().inkJSON2;
            this.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
        }
    }
}
