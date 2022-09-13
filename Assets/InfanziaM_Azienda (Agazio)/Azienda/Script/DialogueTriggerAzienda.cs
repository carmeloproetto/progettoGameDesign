using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerAzienda : MonoBehaviour
{
    //[Header("Visual Cue")]
   // [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public TextAsset ink;

    private bool playerInRange;

    //serve per far scattare il dialogo da follow destination
    public bool startConv;

    public GameObject dlgMng;
    public GameObject canvas;
    public GameObject plant;
    public GameObject tutorial;

    private int count;

    private bool aux;

    private void Awake(){
       // visualCue.SetActive(false);
        startConv = false;
        ink = inkJSON;
        count = 0;
        startConvByOtherScript();
        aux = false;
        FindObjectOfType<AudioManager>().Play("angryCrowd");
        
    }


    private void Update(){
        if(playerInRange && !DialogueManagerAzienda.GetInstance().dialogueIsPlaying){
            //visualCue.SetActive(true);
            if(startConv){
                Debug.Log(ink.text);
                dlgMng.GetComponent<DialogueManagerAzienda>().disableSpace = true;
                DialogueManagerAzienda.GetInstance().EnterDialogueMode(ink);
                startConv = false;
            }
        }
        else if(!aux){
            StartCoroutine(Continue());
        }
    }

    IEnumerator Continue(){   
        aux = true;
        yield return new WaitForSeconds(3);
        dlgMng.GetComponent<DialogueManagerAzienda>().ContinueStoryByOtherScript();
        yield return new WaitForSeconds(3);
        dlgMng.GetComponent<DialogueManagerAzienda>().ContinueStoryByOtherScript();
        yield return new WaitForSeconds(3);
        dlgMng.GetComponent<DialogueManagerAzienda>().ContinueStoryByOtherScript();
        yield return new WaitForSeconds(3);
        dlgMng.GetComponent<DialogueManagerAzienda>().ContinueStoryByOtherScript();
        yield return new WaitForSeconds(2);
        dlgMng.GetComponent<DialogueManagerAzienda>().ContinueStoryByOtherScript();
        yield return new WaitForSeconds(2);
        canvas.SetActive(false);
        plant.GetComponent<PlantInteraction>().interact = true;
        tutorial.SetActive(true);
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

