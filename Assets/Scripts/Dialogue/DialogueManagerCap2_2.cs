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

    EventSystem m_EventSystem;
    public GameObject btn_choice_sx;
    public GameObject btn_choice_dx;
    private bool setFirstActiveBtnSx;
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshPro2;

    public GameObject canvasTutorialDialogo;
    private GameObject child1;
    private GameObject child2;
    private GameObject child3;

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

        StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioIntro", 3, 0));
        StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("rain", 2, 0));
        FindObjectOfType<AudioManager>().Play("birds");
        FindObjectOfType<AudioManager>().Play("crowd");

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

        child1 = canvasTutorialDialogo.transform.GetChild(0).gameObject;
        child2 = canvasTutorialDialogo.transform.GetChild(1).gameObject;
        child3 = canvasTutorialDialogo.transform.GetChild(2).gameObject;
    }

    private void Update(){

        if(PauseMenu.GameIsPaused){
            setFirstActiveBtnSx = true;
            return;
        }

        if(disableSpace == true){
            canvasTutorialDialogo.GetComponent<Canvas>().enabled = false;
        }
        else{
            canvasTutorialDialogo.GetComponent<Canvas>().enabled = true;
        }

        setFirstActiveButton();

        if(!dialogueIsPlaying){
            return;
        }

        if((Input.GetKeyDown("space") || Input.GetKeyDown("return")) && viewChoice == false){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                FindObjectOfType<AudioManager>().Play("ui-text");
                disableSpace = true;
                StartCoroutine(disableSpaceFunction());
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);

               /*INSERIRE LE COSE DA FARE IN DETERMINATI PUNTI DEL DIALOGO*/

                

                ContinueStory();
            }
        }
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
        canvasTutorialDialogo.SetActive(true);
        disableSpace = false;
     }


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);
        canvasTutorialDialogo.SetActive(false);
        Debug.Log("siamo fuori dalla conversazione");
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";


         if(whoSpeak == "ManifestanteCentro"){
             manifestanteCentro.GetComponent<Animator>().SetBool("Talk", false);
         }

         if(whoSpeak == "Guardia"){
                //triggerDialogueZoneGuardia.SetActive(false);
                talkedToGuard = true;
                triggerDialogueZoneManifestanteCentro.GetComponent<DialogueTriggerCap2_2>().closeConv();
                //triggerDialogueZoneManifestanteCentro.SetActive(true);
                guardia.GetComponent<Animator>().SetBool("No", false);
         }
        else if(whoSpeak == "ManifestanteDx"){
            //triggerDialogueZoneManifestanteDx.SetActive(false);
            manifestanteDx.GetComponent<Animator>().SetBool("Speak", false);
        }
        else if(whoSpeak == "ManifestanteSx"){
            //triggerDialogueZoneManifestanteSx.SetActive(false);
             
        }
        else if(whoSpeak == "ManifestanteCentro" && !talkedToGuard){
            //triggerDialogueZoneManifestanteCentro.SetActive(false);
           
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
                    //displayNameText.text = tagValue;
                    if(tagValue == "Mom" || tagValue == "Mamma"){          
                        imageOfSpeaker.sprite = momImage;
                        displayNameText.text = tagValue;
                    }
                    else if(tagValue == "Guardia" || tagValue == "Guard"){          
                        imageOfSpeaker.sprite = guardiaImage;
                        displayNameText.text = tagValue;
                    }
                    else if(tagValue == "Manifestante 1" || tagValue == "Protester 1"){
                        imageOfSpeaker.sprite = manifestante1Image;
                        if(tagValue == "Manifestante 1")
                            displayNameText.text = "Manifestante";
                        else
                            displayNameText.text = "Protester";
                    }
                    else if(tagValue == "Manifestante 2" || tagValue == "Protester 2"){
                        imageOfSpeaker.sprite = manifestante2Image;
                        if(tagValue == "Manifestante 2")
                            displayNameText.text = "Manifestante";
                        else
                            displayNameText.text = "Protester";
                    }
                    else if(tagValue == "Manifestante 3" || tagValue == "Protester 3"){
                        imageOfSpeaker.sprite = manifestante3Image;
                        if(tagValue == "Manifestante 3")
                            displayNameText.text = "Manifestante";
                        else
                            displayNameText.text = "Protester";
                    }
                    else 
                        displayNameText.text = tagValue;
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
            child1.SetActive(false);
            child2.SetActive(true);
            child3.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for(int i = index; i < choices.Length; i++){
            viewChoice = false;
            disableSpace = true;
            StartCoroutine(disableSpaceFunction());
            child1.SetActive(true);
            child2.SetActive(false);
            child3.SetActive(false);
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

        if(PauseMenu.GameIsPaused)
            return;

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

    private IEnumerator disableSpaceFunction(){
        yield return new WaitForSeconds(0.8f);
        disableSpace = false;
    }

}


