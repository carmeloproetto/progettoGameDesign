using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCap2_2 : MonoBehaviour
{
 [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] public TextAsset inkJSON2;
    [SerializeField] public TextAsset inkJSON3;
    [SerializeField] private TextAsset inkJSON_Eng;
    [SerializeField] public TextAsset inkJSON2_Eng;

    public TextAsset ink;

    private bool playerInRange;

    //serve per far scattare il dialogo da follow destination
    public bool startConv;

    private int count;

    public GameObject visualCue;
    public GameObject mom;
    public GameObject guardia;
    public GameObject manifestanteDx;
    public GameObject manifestanteCen;

    public int language;

    private void Awake(){
       // visualCue.SetActive(false);
       language = LanguageChangeScript.language;


        startConv = false;

        if(language == 1)
            ink = inkJSON;
        else 
            ink = inkJSON_Eng;
   
    }


    private void Update(){

        if(playerInRange && !DialogueManagerCap2_2.GetInstance().dialogueIsPlaying){
            if(Input.GetKeyDown("e") || startConv){
                //visualCue.SetActive(false);
                if(this.name == "triggerDialogueZoneGuardia"){
                    mom.GetComponent<DialogueManagerCap2_2>().whoSpeak = "Guardia";
                    guardia.GetComponent<Animator>().SetBool("No", true);
                }
                else if(this.name == "TriggerDialogueZoneDx"){
                    mom.GetComponent<DialogueManagerCap2_2>().whoSpeak = "ManifestanteDx";
                    //mom.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    manifestanteDx.GetComponent<Animator>().SetBool("Speak", true);
                }
                else if(this.name == "TriggerDialogueZoneSx"){
                    mom.GetComponent<DialogueManagerCap2_2>().whoSpeak = "ManifestanteSx";
                    //mom.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                }
                else if(this.name == "TriggerDialogueZoneCentro"){
                    //mom.transform.eulerAngles = new Vector3(0f, 0f, 0f);
                    manifestanteCen.GetComponent<Animator>().SetBool("Talk", true);
                    if(mom.GetComponent<DialogueManagerCap2_2>().talkedToGuard){
                        if(language == 1)
                            ink = inkJSON2;
                        else 
                            ink = inkJSON2_Eng;
                        //mom.GetComponent<DialogueManagerCap2_2>().talkedToGuard = false;
                    }
                   mom.GetComponent<DialogueManagerCap2_2>().whoSpeak = "ManifestanteCentro";
                }

                Debug.Log(ink.text);
                DialogueManagerCap2_2.GetInstance().EnterDialogueMode(ink);
                startConv = false;
                
            }
        }
    }


    private void OnTriggerEnter(Collider collider){
        
        if(collider.CompareTag("Player")){
            playerInRange = true;
            //visualCue.SetActive(true);

            
        }
    }

    private void OnTriggerExit(Collider collider){
        if(collider.CompareTag("Player")){
            playerInRange = false;
            //visualCue.SetActive(false);
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
