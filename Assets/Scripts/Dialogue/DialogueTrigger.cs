using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] public TextAsset inkJSON2;
    [SerializeField] public TextAsset inkJSON3;

    public TextAsset ink;

    private bool playerInRange;

    //serve per far scattare il dialogo da follow destination
    public bool startConv;

    public GameObject dad;

    private int count;

    private void Awake(){
        visualCue.SetActive(false);
        startConv = false;
        ink = inkJSON;
        count = 0;
    }


    private void Update(){
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            //visualCue.SetActive(true);
            if(/*Input.GetKeyDown("c") ||*/ startConv){
                Debug.Log(ink.text);
                DialogueManager.GetInstance().EnterDialogueMode(ink);
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
}
