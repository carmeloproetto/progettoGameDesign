using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DialogueManagerCap3_2 : MonoBehaviour{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite dadImage;
    public Sprite thiefImage;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerCap3_2 instance;

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

    public GameObject dad;

    public bool QteScoiattoliEnd;

    public float feeling;
    public float helpLad;
    public bool auxFinal;
    public static int finale;

    public GameObject ragazzo;
    public GameObject professore;
    public GameObject tutorialCorsa;
    
    public bool startCorsa;
   

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        viewChoice = false;
        countDialogue = 1;
        disableSpace = false;

        QteScoiattoliEnd = false;
        //feeling = 0f;
        helpLad = 0;

        startCorsa = false;
        auxFinal = false;
    }

    public static DialogueManagerCap3_2 GetInstance(){
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
        if(!dialogueIsPlaying && !startCorsa){
            return;
        }

        if(Input.GetKeyDown("space") && viewChoice == false && !startCorsa){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);
                
                if(line == 5 && countDialogue == 1){

                }
                ContinueStory();
            }
        }


        
        //MINI GIOCO CORSA
        if(startCorsa){
            if(Input.GetKeyDown("space")){   
                startCorsa = false;
                professore.GetComponent<ProfessoreController>().enabled = true;
                ragazzo.transform.eulerAngles = new Vector3(0f, 90f, 0f);
                ragazzo.GetComponent<RagazzoController>().enabled = true;
                dad.GetComponent<PadreStudenteController>().enabled = true;
                tutorialCorsa.SetActive(false);
              }
        }
    }   

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        disableSpace = true;
        StartCoroutine(activePanelAfterOneSecond());
            
        if(countDialogue == 1){
            currentStory.EvaluateFunction("changeFeeling", feeling);
            ragazzo.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        }

        if(countDialogue == 2){
            currentStory.EvaluateFunction("changeHelp", helpLad);
            currentStory.EvaluateFunction("changeFeeling", feeling);
        }


        ContinueStory();
    }


     private IEnumerator activePanelAfterOneSecond(){
        yield return new WaitForSeconds(1f);
        dialoguePanel.SetActive(true);
         yield return new WaitForSeconds(0.5f);
        disableSpace = false;
     }


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        //cose da fare quando termina il primo dialogo
        if(countDialogue == 1){
            tutorialCorsa.SetActive(true);
            dad.GetComponent<DialogueTriggerCap3_1>().closeConv();
            startCorsa = true;
        }
        //cose da fare quando termina il secondo dialogo
        else if(countDialogue == 2){
            if(helpLad == 0){
                //non lo stiamo aiutando
                if(feeling < 0.5 && !auxFinal)
                    finale = 1;
                else if(feeling >= 0.5 && !auxFinal)
                    finale = 2;
                else if(auxFinal)
                    finale = 3;
            }
            else{
                //lo stiamo aiutando
                if(!auxFinal)
                    finale = 5;
                else if(feeling >= 0.5 && auxFinal)
                    finale = 1;
                else if(feeling < 0.5 && auxFinal)
                    finale = 4;
            }
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
                    if(tagValue == "Dad"){ 
                        imageOfSpeaker.sprite = dadImage;
                    }
                    else if(tagValue == "Lad"){
                        imageOfSpeaker.sprite = thiefImage;
                    }
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
        
        if(choiceIndex == 0 && line == 3 && countDialogue == 1 && feeling >= 0.5f){
            feeling -= 0.25f;
            Debug.Log("nuovo feeling: " + feeling);
            currentStory.EvaluateFunction("changeFeeling", feeling);
        }
        if(choiceIndex == 0 && line == 7 && countDialogue == 1 && feeling < 0.5f){
            feeling -= 0.25f;
            Debug.Log("nuovo feeling: " + feeling);
            currentStory.EvaluateFunction("changeFeeling", feeling);
        }
        if(choiceIndex == 0 && line == 7 && countDialogue == 1 && feeling >= 0.5f)
            helpLad = 1;

        if(helpLad == 0 && choiceIndex == 1 && line == 4 && countDialogue == 2)
            auxFinal = true;
        
        if(helpLad == 1 && choiceIndex == 0 && line == 5 && countDialogue == 2)
            auxFinal = true;


        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }


    public void ContinueStoryByOtherScript(){
        ContinueStory();
    }

}

