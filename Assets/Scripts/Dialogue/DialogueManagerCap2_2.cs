using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManagerCap2_2 : MonoBehaviour
{
[Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite momImage;
    public Sprite guardiaImage;
    public Sprite manifestante1Image;
    public Sprite manifestante2Image;
    public Sprite manifestante3Image;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerCap2_2 instance;

    private const string SPEAKER_TAG = "speaker";
    //private const string PORTRAIT_TAG = "portrait";
    //private const string LAYOUT_TAG = "layout";

    //serve per non poter premere spazio davanti ad una domanda
    private bool viewChoice;

    //serve per tenere traccia di che dialogo stiamo ascoltando
    private int countDialogue;


    //conto il numero di frasi alla quale siamo arrivati nella conversazione
    private int line;

    //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
    public bool disableSpace;


    public GameObject triggerDialogueZoneGuardia;
    public GameObject triggerDialogueZoneManifestanteDx;
    public GameObject triggerDialogueZoneManifestanteCentro;
    public GameObject triggerDialogueZoneManifestanteSx;

    public string whoSpeak;
    public bool talkedToGuard;

    public GameObject guardia;
    public GameObject manifestanteDx;

    public bool retroAzienda;

    public GameObject manifestanteCentro;



    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        viewChoice = false;
        countDialogue = 1;
        disableSpace = false;
        talkedToGuard = false;
        retroAzienda = false;
    }

    public static DialogueManagerCap2_2 GetInstance(){
        return instance;
    }

    private void Start(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices){
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        line = 0;
    }

    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }

        if(Input.GetKeyDown("space") && viewChoice == false){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                disableSpace = true;
                StartCoroutine(disableSpaceFunction());
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);

               /*INSERIRE LE COSE DA FARE IN DETERMINATI PUNTI DEL DIALOGO*/

                

                ContinueStory();
            }
        }
    }

    private IEnumerator disableSpaceFunction(){
        yield return new WaitForSeconds(1f);
        disableSpace = false;
     }


    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        disableSpace = true;
        StartCoroutine(activePanelAfterOneSecond());
       ContinueStory();
    }


     private IEnumerator activePanelAfterOneSecond(){
        yield return new WaitForSeconds(1f);
        dialoguePanel.SetActive(true);
        disableSpace = false;
     }


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);

        Debug.Log("siamo fuori dalla conversazione");
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";


         if(whoSpeak == "ManifestanteCentro"){
             manifestanteCentro.GetComponent<Animator>().SetBool("Talk", false);
         }

         if(whoSpeak == "Guardia"){
                triggerDialogueZoneGuardia.SetActive(false);
                talkedToGuard = true;
                triggerDialogueZoneManifestanteCentro.GetComponent<DialogueTriggerCap2_2>().closeConv();
                triggerDialogueZoneManifestanteCentro.SetActive(true);
                guardia.GetComponent<Animator>().SetBool("No", false);
         }
        else if(whoSpeak == "ManifestanteDx"){
            triggerDialogueZoneManifestanteDx.SetActive(false);
            manifestanteDx.GetComponent<Animator>().SetBool("Speak", false);
        }
        else if(whoSpeak == "ManifestanteSx"){
            triggerDialogueZoneManifestanteSx.SetActive(false);
             
        }
        else if(whoSpeak == "ManifestanteCentro" && !talkedToGuard){
            triggerDialogueZoneManifestanteCentro.SetActive(false);
           
        }

        //if che parte al termine del dialgoo se la madre è pronta per andare dietro l'azienda
        if(retroAzienda){
              triggerDialogueZoneManifestanteCentro.SetActive(false);
              manifestanteCentro.GetComponent<followDestinationCap2_2>().enabled = true;
        }  

        line = 0;
        countDialogue++;
    }



    private void getTextStory(string text){
        Debug.Log(text);
    }


    private void ContinueStory(){
         if(currentStory.canContinue){
            dialogueText.text = currentStory.Continue();

            DisplayChoices();

            HandleTags(currentStory.currentTags);
        }
        else{

            StartCoroutine(ExitDialogueMode());
        }
    }


    private void HandleTags(List<string> currentTags){
        foreach(string tag in currentTags){
            string[] splitTag = tag.Split(':');
            if(splitTag.Length != 2){
                Debug.LogError("numero di tag errati: " + tag);
            }
            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();
            switch(tagKey){
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    if(tagValue == "Mom" || tagValue == "Mamma"){          
                        imageOfSpeaker.sprite = momImage;
                    }
                    else if(tagValue == "Guardia" || tagValue == "Guard"){          
                        imageOfSpeaker.sprite = guardiaImage;
                    }
                    else if(tagValue == "Manifestante 1" || tagValue == "Protester 1")
                        imageOfSpeaker.sprite = manifestante1Image;
                    else if(tagValue == "Manifestante 2" || tagValue == "Protester 2")
                        imageOfSpeaker.sprite = manifestante2Image;
                    else if(tagValue == "Manifestante 3" || tagValue == "Protester 3")
                        imageOfSpeaker.sprite = manifestante3Image;
                    break;
             
                default: 
                    Debug.Log("errore nei tag " + tag);
                    break;            
            }
        }
    }



    private void DisplayChoices(){
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length){
            Debug.LogError("errore nel numero di scelte!");
        }

        int index = 0;
        foreach(Choice choice in currentChoices){
            viewChoice = true;
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for(int i = index; i < choices.Length; i++){
            viewChoice = false;
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());

    }

    private IEnumerator SelectFirstChoice(){
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex){
        Debug.Log("numero della scleta:" + choiceIndex + " " + line + " " + countDialogue);
        /* inserie cose da fare in base alle scelte*/
        if(choiceIndex == 0){
            Debug.Log("possiamo andare sul retro");
            retroAzienda = true;
        }
       

        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }


    public void ContinueStoryByOtherScript(){
        ContinueStory();
    }

    public int getCountDialogue(){
        return countDialogue;
    }

}


