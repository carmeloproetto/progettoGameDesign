using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCap2 : MonoBehaviour
{
    //[Header("Visual Cue")]
   // [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] public TextAsset inkJSON2;
    [SerializeField] public TextAsset inkJSON3;
    [SerializeField] private TextAsset inkJSON_Eng;
    [SerializeField] public TextAsset inkJSON2_Eng;
    [SerializeField] public TextAsset inkJSON3_Eng;

    public int language;


    public TextAsset ink;

    private bool playerInRange;

    //serve per far scattare il dialogo da follow destination
    public bool startConv;

    private int count;

    private void Awake(){
        language = 1;
       // visualCue.SetActive(false);
        startConv = false;
        if(language == 1)
            ink = inkJSON;
        else if(language == 0)
            ink = inkJSON_Eng;

        count = 0;
    }


    private void Update(){
        if(playerInRange && !DialogueManagerCap2.GetInstance().dialogueIsPlaying){
            //visualCue.SetActive(true);
            if(/*Input.GetKeyDown("c") ||*/ startConv){
                Debug.Log(ink.text);
                DialogueManagerCap2.GetInstance().EnterDialogueMode(ink);
                startConv = false;
            }
        }
        else{
            //visualCue.SetActive(false);
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
