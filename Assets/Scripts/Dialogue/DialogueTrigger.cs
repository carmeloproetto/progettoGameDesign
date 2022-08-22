using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;


    private bool playerInRange;

    private void Awake(){
        visualCue.SetActive(false);
    }


    private void Update(){
        if(playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying){
            visualCue.SetActive(true);
            if(Input.GetKeyDown("c")){
                Debug.Log(inkJSON.text);
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else{
            visualCue.SetActive(false);
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
