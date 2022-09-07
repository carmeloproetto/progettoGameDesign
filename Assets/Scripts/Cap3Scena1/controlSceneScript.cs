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
            this.GetComponent<DialogueTrigger>().ink = this.GetComponent<DialogueTrigger>().inkJSON2;
            this.GetComponent<DialogueTrigger>().startConvByOtherScript();
        }
    }
}
