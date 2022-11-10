using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManagerCap2 : MonoBehaviour
{
[Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite momImage;
    public Sprite  mayorImage;
    public Sprite uncknowImage;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerCap2 instance;

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

    public GameObject mom;
    public GameObject sindaco;
    public GameObject canvas2;
    public GameObject canvas;

    private bool noAnimation;



    public static float feeling = 1;

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
    }

    public static DialogueManagerCap2 GetInstance(){
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
        noAnimation = false;

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

                /*if(line == 11 && countDialogue == 1){
                    mom.GetComponent<Animator>().SetBool("Angry", true);
                    //ContinueStory();
                }*/
                if(line == 15 && countDialogue == 1){
                    noAnimation = true;
                    sindaco.GetComponent<Animator>().SetBool("Talk2", false);
                    sindaco.GetComponent<Animator>().SetBool("HeadAround", true);
                    disableSpace = true;
                    StartCoroutine(phoneRings());
                }
                else if(line == 10 && countDialogue == 1){
                    noAnimation = true;
                    sindaco.GetComponent<Animator>().SetBool("AngryDad", true);
                    ContinueStory();
                }
                else if(line == 11 && countDialogue == 1){
                    noAnimation = false;
                    mom.GetComponent<Animator>().SetBool("Angry", true);
                    sindaco.GetComponent<Animator>().SetBool("AngryDad", false);
                    ContinueStory();
                }
                else if(line == 1 && countDialogue == 2){
                   StartCoroutine( Rotate( new Vector3(0, -180, 0), 0.3f));
                   ContinueStory();
                }
                else
                    ContinueStory();
            }
        }
    }


    private IEnumerator Rotate( Vector3 angles, float duration )
    {
        Quaternion startRotation = mom.transform.rotation ;
        Quaternion endRotation = Quaternion.Euler( angles ) * startRotation ;
        for( float t = 0 ; t < duration ; t+= Time.deltaTime )
        {
            mom.transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration ) ;
            yield return null;
        }
        mom.transform.rotation = endRotation ;
        //rotating = false;
    }



    private IEnumerator phoneRings(){
        FindObjectOfType<AudioManager>().Play("phoneRing");
        dialoguePanel.SetActive(false);
        yield return new WaitForSeconds(3f);
        sindaco.GetComponent<Animator>().SetBool("HeadAround", false);
        ContinueStory();
        dialoguePanel.SetActive(true);
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
        yield return new WaitForSeconds(1f);
        canvasTutorialDialogo.SetActive(true);
        disableSpace = false;
     }


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);
        canvasTutorialDialogo.SetActive(false);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        //cose da fare quando termina il primo dialogo
        if(countDialogue == 1){
          mom.GetComponent<DialogueTriggerCap2>().closeConv();
          mom.GetComponent<followDestinationCap2_1>().enabled = true;
        }
        //cose da fare quando termina il secondo dialogo
        else if(countDialogue == 2){
            StartCoroutine(finalCanvas());
        }
        //cose da fare quando termina il terzo dialogo
        else if(countDialogue == 3){
          
        }
        //cose da fare quando termina il quarto dialogo
        else if(countDialogue == 4){
            
        }

        line = 0;
        countDialogue++;
    }


    private IEnumerator finalCanvas(){
        yield return new WaitForSeconds(1f);
        canvas2.GetComponent<fineCap2Scena1>().enabled = true;
        canvas2.GetComponent<Canvas>().enabled = true;
        canvas.GetComponent<Canvas>().enabled = false;
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
                        mom.GetComponent<Animator>().SetBool("Talk", true);
                        sindaco.GetComponent<Animator>().SetBool("Talk2", false);
                    }
                    else if(tagValue == "Mayor" || tagValue == "Sindaco"){ 
                        imageOfSpeaker.sprite = mayorImage;
                        mom.GetComponent<Animator>().SetBool("Talk", false);
                        if(noAnimation == false)
                            sindaco.GetComponent<Animator>().SetBool("Talk2", true);
                    }
                    else if(tagValue == "???"){ 
                        imageOfSpeaker.sprite = uncknowImage;
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
        if(choiceIndex == 0 && line == 3 && countDialogue == 1)
            feeling -= 0.25f;

        if(choiceIndex == 1 && line == 4 && countDialogue == 1)
            feeling -= 0.25f;
        
        if(choiceIndex == 0 && line == 9 && countDialogue == 1)
            feeling -= 0.25f;
       

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
        if(line == 15 && countDialogue == 1){
            Debug.Log("lo spazio deve rimanere disabilitato");
        }
        else{
            yield return new WaitForSeconds(0.8f);
            disableSpace = false;
        }
    }

}

