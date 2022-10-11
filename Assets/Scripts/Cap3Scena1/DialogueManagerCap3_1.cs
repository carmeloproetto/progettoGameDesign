using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Playables;

public class DialogueManagerCap3_1 : MonoBehaviour{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite dadImage;
    public Sprite professorImage;
    public PlayableDirector director; 


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerCap3_1 instance;

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

    public GameObject professor;
    public GameObject dad;

    public bool QteScoiattoliEnd;

    EventSystem m_EventSystem;
    public GameObject btn_choice_sx;
    public GameObject btn_choice_dx;
    private bool setFirstActiveBtnSx;
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshPro2;


    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        viewChoice = false;
        countDialogue = 1;
        disableSpace = false;

        QteScoiattoliEnd = false;
      
    }

    public static DialogueManagerCap3_1 GetInstance(){
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

        m_EventSystem = EventSystem.current;
        setFirstActiveBtnSx = true;
    }

    private void Update(){

        if(PauseMenu.GameIsPaused){
            setFirstActiveBtnSx = true;
            return;
        }

        setFirstActiveButton();


        if(!dialogueIsPlaying){
            return;
        }

        if(Input.GetKeyDown("space") && viewChoice == false){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);
                
                if(line == 5 && countDialogue == 1){
                    Debug.Log("riga 102 DialogueMangerCap3_1, BISOGNA FAR PARTIRE ANIMAZIONE DEL PROF CHE POSA GLI SCOIATTOLI SULLA SCRIVANIA");
                    director.Play();
                }


                if(line == 14 && countDialogue == 1){
                    professor.GetComponent<Animator>().SetBool("Talk", false);
                    professor.GetComponentInParent<followDestinationProfessor2>().enabled = true;
                    Debug.Log("riga 109 DialogueMangerCap3_1, BISOGNA FAR PARTIRE ANIMAZIONE DEL RAGAZZO CHE NON PARLA PIU'");
                    dad.GetComponent<Animator>().SetBool("Talk", false);
                }
                else
                    ContinueStory();
            }
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        StartCoroutine(activePanelAfterOneSecond());
        ContinueStory();
    }


     private IEnumerator activePanelAfterOneSecond(){
        yield return new WaitForSeconds(1f);
        dialoguePanel.SetActive(true);
     }


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        //cose da fare quando termina il primo dialogo
        if(countDialogue == 1){
           dad.GetComponent<DialogueTriggerCap3_1>().closeConv();
            //IL RAGAZZO SI DEVE ALAZARE QUI E VA VERSO GLI SCOIATTOLI;IL MOVIMENTO é GIA' FATTO, MANCA L'ANIMAZIONE DI ALZARSI E CAMMINARE
           dad.GetComponent<Animator>().SetTrigger("StandUp");
        }
        //cose da fare quando termina il secondo dialogo
        else if(countDialogue == 2){
           dad.GetComponent<DialogueTriggerCap3_1>().closeConv();
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
                    if(tagValue == "Dad" || tagValue == "Papà"){ 
                        imageOfSpeaker.sprite = dadImage;
                    }
                    else if(tagValue == "Professor" || tagValue == "Professore"){
                        imageOfSpeaker.sprite = professorImage;
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

        if(PauseMenu.GameIsPaused){
            return;
        }
        
        Debug.Log("numero della scleta:" + choiceIndex + " " + line + " " + countDialogue);
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }


    public void ContinueStoryByOtherScript(){
        ContinueStory();
    }

    public void setFirstActiveButton(){
        if(setFirstActiveBtnSx == true){
            Debug.Log("setto il pulsante di sinistra come attivo");
            m_EventSystem.SetSelectedGameObject(btn_choice_sx);
            btn_choice_sx.GetComponent<Image>().color = new Color32(0, 0, 0, 150);
            btn_choice_dx.GetComponent<Image>().color = new Color32(0, 0, 0, 50);
            textmeshPro.color = new Color32(231, 231, 231, 255);
            textmeshPro2.color = new Color32(231, 231, 231, 50);
            setFirstActiveBtnSx = false;
        }
    }

}

