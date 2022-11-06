using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DialogueManagerEpilogo : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite momImage;
    public Sprite dadImage;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerEpilogo instance;

    private const string SPEAKER_TAG = "speaker";
    
    //serve per non poter premere spazio davanti ad una domanda
    private bool viewChoice;

    //serve per tenere traccia di che dialogo stiamo ascoltando
    private int countDialogue;

    //conto il numero di frasi alla quale siamo arrivati nella conversazione
    private int line;

    //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
    public bool disableSpace;

    public GameObject dad;
    public GameObject mom;

    public GameObject levelLoader;


    /////////////////////////////SELEZIONE PRIMO PULSANTE NELLE SCELTE/////////////////////////////////
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

    public GameObject board;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        viewChoice = false;
        countDialogue = 1;
        disableSpace = false;
        //audioManager.GetComponent<AudioManager>().Play("birdsAudio");

       

    }

    public static DialogueManagerEpilogo GetInstance(){
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

        /////////////////////////////SELEZIONE PRIMO PULSANTE NELLE SCELTE/////////////////////////////////
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

        if((Keyboard.current.spaceKey.isPressed || Keyboard.current.enterKey.isPressed) && viewChoice == false){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                //disableSpace = true;
                //StartCoroutine(disableSpaceFunction());
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);
                //serve per far partire la camminata nella scena cap1 quando siamo davanti al parco

                if (line == 12 && countDialogue == 1)
                {
                    disableSpace = true;
                    dad.GetComponent<Animator>().SetTrigger("victory");
                    StartCoroutine(disableSpaceEnjoy());
                    ContinueStory();
                }
                else
                {
                    disableSpace = true;
                    StartCoroutine(disableSpaceFunction());
                    ContinueStory();
                }

            }
        }
    }


    private IEnumerator disableSpaceFunction(){
        yield return new WaitForSeconds(0.3f);
        disableSpace = false;
     }

     private IEnumerator disableSpaceEnjoy(){
        yield return new WaitForSeconds(1.5f);
        disableSpace = false;
     }


    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        disableSpace = true;

        if(DialogueManagerCap3_2.finale == 4){
            currentStory.EvaluateFunction("changeEspulsione", 1);
        }
        
        StartCoroutine(activePanelAfterOneSecond());
        ContinueStory();

    }


     private IEnumerator activePanelAfterOneSecond(){
        yield return new WaitForSeconds(1f);
        dialoguePanel.SetActive(true);
         canvasTutorialDialogo.SetActive(true);
        yield return new WaitForSeconds(1f);
        disableSpace = false;
     }


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);
        canvasTutorialDialogo.SetActive(false);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        dad.GetComponent<Animator>().SetBool("Speak", false);
        mom.GetComponent<Animator>().SetBool("Speak", false);

        //cose da fare quando termina il primo dialogo
        if(countDialogue == 1){
            //StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioEpilogo", 1, 0));
            dad.GetComponent<Animator>().SetTrigger("kiss");
            mom.GetComponent<Animator>().SetTrigger("kiss");
            //levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
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
                    if((tagValue == "Mom" && countDialogue != 3) || (tagValue == "Mamma" && countDialogue != 3)){          
                        imageOfSpeaker.sprite = momImage;
                        dad.GetComponent<Animator>().SetBool("Speak", false);
                        mom.GetComponent<Animator>().SetBool("Speak", true);
                    }
                    if(tagValue == "Dad" || tagValue == "Papà"){ 
                        imageOfSpeaker.sprite = dadImage;
                        dad.GetComponent<Animator>().SetBool("Speak", true);
                        mom.GetComponent<Animator>().SetBool("Speak", false);
                    }
                    break;
              /*  case PORTRAIT_TAG:
                    Debug.Log("portrait=" + tagValue);
                    break;
               case LAYOUT_TAG:
                    Debug.Log("layout=" + tagValue);
                    break;*/
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
        
        setFirstActiveBtnSx = true;


        
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
