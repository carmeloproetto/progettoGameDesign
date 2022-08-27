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

    public TextAsset ink;

    private bool playerInRange;

    //serve per far scattare il dialogo da follow destination
    public bool startConv;

    private void Awake(){
        visualCue.SetActive(false);
        startConv = false;
        ink = inkJSON;
    }


    private void Update(){
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            //visualCue.SetActive(true);
            if(Input.GetKeyDown("c") || startConv){
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
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider){
        if(collider.CompareTag("Player")){
            playerInRange = false;
        }
    }
}
