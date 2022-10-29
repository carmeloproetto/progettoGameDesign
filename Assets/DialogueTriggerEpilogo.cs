using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerEpilogo : MonoBehaviour
{
    //[Header("Visual Cue")]
   // [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    
    [SerializeField] private TextAsset inkJSON_Eng;
  
    public TextAsset ink;

    private bool playerInRange;

    //serve per far scattare il dialogo da follow destination
    public bool startConv;


    private int count;

    public int language;



    private void Awake(){
        language = LanguageChangeScript.language;
       // visualCue.SetActive(false);
        startConv = false;
        if(language == 0)
            ink = inkJSON_Eng;
        else if(language == 1)
            ink = inkJSON;
        count = 0;
    }


    private void Update(){
        if(playerInRange && !DialogueManagerEpilogo.GetInstance().dialogueIsPlaying){
            //visualCue.SetActive(true);
            if(/*Input.GetKeyDown("c") ||*/ startConv){
                Debug.Log(ink.text);
                DialogueManagerEpilogo.GetInstance().EnterDialogueMode(ink);
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
        Debug.Log("iniziamo il dialogo");
        startConv = true;
        playerInRange = true;
    }


    public void closeConv(){
        startConv = false;
        playerInRange = false;
    }
 
}
