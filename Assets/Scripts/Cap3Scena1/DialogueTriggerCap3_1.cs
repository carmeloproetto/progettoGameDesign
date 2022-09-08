using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriggerCap3_1 : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] public TextAsset inkJSON2;
    [SerializeField] public TextAsset inkJSON3;

    public TextAsset ink;

    private bool playerInRange;

    //serve per far scattare il dialogo da follow destination
    public bool startConv;

    private Scene scene;

    private int count;

    private void Awake(){
       // visualCue.SetActive(false);
        startConv = false;
        ink = inkJSON;
        count = 0;
         scene = SceneManager.GetActiveScene();
    }


    private void Update(){
        if(scene.name == "Cap3_scena1"){
            if(playerInRange && !DialogueManagerCap3_1.GetInstance().dialogueIsPlaying){
                //visualCue.SetActive(true);
                if(/*Input.GetKeyDown("c") ||*/ startConv){
                    Debug.Log(ink.text);
                    DialogueManagerCap3_1.GetInstance().EnterDialogueMode(ink);
                    startConv = false;
                }
            }
        }
        else{
            if(playerInRange && !DialogueManagerCap3_2.GetInstance().dialogueIsPlaying){
                //visualCue.SetActive(true);
                if(/*Input.GetKeyDown("c") ||*/ startConv){
                    Debug.Log(ink.text);
                    DialogueManagerCap3_2.GetInstance().EnterDialogueMode(ink);
                    startConv = false;
                }
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
