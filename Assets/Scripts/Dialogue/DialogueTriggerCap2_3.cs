using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCap2_3 : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] public TextAsset inkJSON2;
    [SerializeField] public TextAsset inkJSON3;
    [SerializeField] private TextAsset inkJSON_eng;
    [SerializeField] public TextAsset inkJSON2_eng;
    [SerializeField] public TextAsset inkJSON3_eng;

    public TextAsset ink;

    private bool playerInRange;

    //serve per far scattare il dialogo da follow destination
    public bool startConv;

    private int count;


    private void Awake(){

        if(LanguageChangeScript.language == 0){
            inkJSON = inkJSON_eng;
            inkJSON2 = inkJSON2_eng;
            inkJSON3 = inkJSON3_eng;
        }

        startConv = false;
        ink = inkJSON;
        count = 0;
    }

      private void Update(){
        if(playerInRange && !DialogueManagerCap2_3.GetInstance().dialogueIsPlaying){
            //visualCue.SetActive(true);
            if(/*Input.GetKeyDown("c") ||*/ startConv){
                Debug.Log(ink.text);
                DialogueManagerCap2_3.GetInstance().EnterDialogueMode(ink);
                startConv = false;
            }
        }


    }

      private void OnTriggerEnter(Collider collider){
        
        if(collider.CompareTag("Player")){
            //il primo dilogo viene triggerato in follow desitination dopo l'animazione di hello, quindi non dobbiamo far partire la conversazione da qui
            if(count != 0){
                Debug.Log("conversazione numero " + count);
                startConv = true;
            }
            playerInRange = true;
            count++;
        }
    }

    private void OnTriggerExit(Collider collider){
        if(collider.CompareTag("Player")){
            playerInRange = false;
        }
    }


    public void startConvByOtherScript(){
        startConv = true;
        playerInRange = true;
    }

    public void closeConv(){
        startConv = false;
        playerInRange = false;
    }

}
