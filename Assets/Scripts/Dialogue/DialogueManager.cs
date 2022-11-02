using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite momImage;
    public Sprite dadImage;
    public Sprite bullyImage;
    public Sprite ladImage;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";
    //private const string PORTRAIT_TAG = "portrait";
    //private const string LAYOUT_TAG = "layout";

    //serve per non poter premere spazio davanti ad una domanda
    private bool viewChoice;

    //serve per tenere traccia di che dialogo stiamo ascoltando
    private int countDialogue;

    public Camera cam;
    public GameObject mom;
    public GameObject dad;
    public GameObject triggerZone;
    public GameObject ragazzino;
    public GameObject bullo;

    public GameObject canvas2;
    public GameObject canvas; 
    public GameObject dlgMgn;
    public GameObject triggerDialogueBulloRagazzinoZone;

    public bool cartellone;

    //conto il numero di frasi alla quale siamo arrivati nella conversazione
    private int line;

    //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
    public bool disableSpace;

    //serve per verificare se il primo incontro dei genitori è andato a buon fine o meno, dipende dalla risposta alla seconda domanda nel cap 1
    public bool positiveMeet;

    //feeling globale fra padre e ragazzino
    public static float feeling;

    public GameObject audioManager;


    /////////////////////////////SELEZIONE PRIMO PULSANTE NELLE SCELTE/////////////////////////////////
    EventSystem m_EventSystem;
    public GameObject btn_choice_sx;
    public GameObject btn_choice_dx;
    private bool setFirstActiveBtnSx;
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshPro2;

    public GameObject board;

    public TutorialUI tutorial_1;
    public TutorialUI tutorial_2; 

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

    public static DialogueManager GetInstance(){
        return instance;
    }



    private void Start(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        cartellone = false;

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

        if(Keyboard.current.spaceKey.isPressed && viewChoice == false){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                //disableSpace = true;
                //StartCoroutine(disableSpaceFunction());
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);
                //serve per far partire la camminata nella scena cap1 quando siamo davanti al parco
                if(line == 1 && countDialogue == 3 && !cartellone){
                    Debug.Log("Siamo nella terza conversazione alla fine della prima frase frase!");
                    disableSpace = true;
                    dad.GetComponent<PlayerController>().enabled = false;
                    dad.GetComponent<limitZone>().enabled = false;
                    mom.GetComponent<followDestination3>().enabled = false;
                    mom.GetComponent<followDestination4>().enabled = true;
                    dad.GetComponent<followDestination4>().enabled = true;
                }
                //"Adessi avrai capito che..."
                else if (line == 1 && countDialogue == 4)
                {
                    disableSpace = true;
                    StartCoroutine(disableSpaceFunction());
                    bullo.GetComponent<Animator>().SetBool("isArguing", false);
                    ragazzino.GetComponent<Animator>().SetBool("isArguing", true);
                    ContinueStory();
                }
                //"Vediamo che sei in grado di fare"
                else if (line == 2 && countDialogue == 4)
                {
                    disableSpace = true;
                    StartCoroutine(disableSpaceFunction());
                    bullo.GetComponent<Animator>().SetBool("isArguing", true);
                    ragazzino.GetComponent<Animator>().SetBool("isArguing", false);
                    ContinueStory();
                }
                else if(line == 3 && countDialogue == 5 && feeling == 1){
                    //il bullo fa rissa con il padre
                    dad.GetComponent<AnimationEventManager>().StartCombattimento();
                    dad.GetComponent<Animator>().SetBool("Speak", false);
                    bullo.GetComponent<Animator>().SetTrigger("sceltaDue");
                    dad.GetComponent<Animator>().SetTrigger("inizioCombattimento");
                    dialoguePanel.SetActive(false);
                    disableSpace = true;
                }
                else if(line == 4 && countDialogue == 5 && feeling == 1){
                    disableSpace = true;
                    dad.GetComponent<AnimationEventManager>().EndCombattimento();
                    StartCoroutine(disableSpaceFunction());
                    bullo.GetComponent<Animator>().SetTrigger("esciDiScena");
                    ragazzino.GetComponent<Animator>().SetBool("isTalking", true);
                    ContinueStory();
                }
                else{
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


    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        disableSpace = true;
        dad.GetComponent<Animator>().SetFloat("Speed", 0f);
       
        StartCoroutine(activePanelAfterOneSecond());
        ContinueStory();

        if(countDialogue == 3 && !cartellone)       
            imageOfSpeaker.sprite = momImage;


        if (countDialogue == 4)
        {
            bullo.GetComponent<Animator>().SetBool("isArguing", true);
        }
    }


     private IEnumerator activePanelAfterOneSecond(){
        yield return new WaitForSeconds(1f);
        dialoguePanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        disableSpace = false;
     }


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        dad.GetComponent<Animator>().SetBool("Speak", false);
        mom.GetComponent<Animator>().SetBool("Speak", false);

        //cose da fare quando termina il primo dialogo
        if(countDialogue == 1){
            triggerZone.SetActive(false);
            //mom.GetComponent<followDestination2>().enabled = true;
            cam.GetComponent<CameraFollow>().target_aux = cam.GetComponent<CameraFollow>().target2; 
            Debug.Log("conversazione 1 finita");
            //serve per abilitare movimento giocatore e pannello tutorial tasti
            StartCoroutine(triggerDadControl());
        }
        //cose da fare quando termina il secondo dialogo
        else if(countDialogue == 2){
            mom.GetComponent<followDestination2>().enabled = false;
            mom.GetComponent<followDestination3>().enabled = true;
            Debug.Log("conversazione 2 finita");
        }
        //cose da fare quando termina il terzo dialogo
        else if(countDialogue == 3 && !cartellone){
            triggerZone.SetActive(false);
            mom.GetComponent<followDestination5>().enabled = true;
        }
        else if(countDialogue == 3 && cartellone){
            cartellone = false;
            countDialogue--;
            dad.GetComponent<PlayerController>().EnableInput();
            dad.GetComponent<PlayerController>().EnableJump();
            dad.GetComponent<PlayerController>().EnableRotation();
            board.GetComponent<BoardInteractable>().enabled = false;
            board.GetComponent<BoardInteractable>().interactable = false;
            board.GetComponent<DialogueTrigger>().enabled = false;
        }
        //cose da fare quando termina il quarto dialogo
        else if(countDialogue == 4){

            //bullo smette di parlare
            bullo.GetComponent<Animator>().SetBool("isArguing", false);

            //il ragazzino si dirige verso il bullo e lo spinge
            ragazzino.GetComponent<Animator>().SetBool("isWalking", true);
        }
        else if(countDialogue == 5 && feeling == 0){

            
            Debug.Log("conversazione tra padre e ragazzino finita");
            ragazzino.GetComponent<Animator>().SetTrigger("corriVersoBullo");
            dlgMgn.GetComponent<DialogueManager>().enabled = false;
            dialoguePanel.SetActive(false);
            triggerDialogueBulloRagazzinoZone.SetActive(false);
            cam.GetComponent<CameraFollow>().enabled = false;
            canvas2.SetActive(true);
            canvas2.GetComponent<Canvas>().enabled = false;
            StartCoroutine(triggerDadQte());

        }
        else if(countDialogue == 5 && feeling == 1){
            ragazzino.GetComponent<Animator>().SetBool("isTalking", false);
            canvas.GetComponent<Canvas>().enabled = false;
            disableSpace = true;
            canvas2.SetActive(true);
            canvas2.GetComponent<Canvas>().enabled = true;
            canvas2.GetComponent<GameControllerQTERissa>().enabled = true;
        }
       

        line = 0;
        countDialogue++;
    }


    
    IEnumerator triggerDadControl(){    
        yield return new WaitForSeconds(3f);
        tutorial_1.On();
        tutorial_2.On();
        dad.GetComponent<PlayerController>().enabled = true;
        dad.GetComponent<limitZone>().enabled = true;
        yield return new WaitForSeconds(1f);
        mom.GetComponent<followDestination2>().enabled = true;
    }



    IEnumerator triggerDadQte(){    
        yield return new WaitForSeconds(1.5f);
        dad.GetComponent<Animator>().SetTrigger("iniziaQteSpazzatura");
        GameControllerQTESpazzatura.countDialogueQte = 0;
        GameControllerQTESpazzatura.aux = true;
        canvas2.GetComponent<GameControllerQTESpazzatura>().enabled = true;
        canvas2.GetComponent<Canvas>().enabled = true;
        print("canvas2 attivato");
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
            Debug.Log("perchè siamo qui?????");
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
                    if(tagValue == "Bully" || tagValue == "Bullo"){ 
                        imageOfSpeaker.sprite = bullyImage;
                    }
                    if(tagValue == "Lad" || tagValue == "Ragazzino"){ 
                        imageOfSpeaker.sprite = ladImage;
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


         if(PauseMenu.GameIsPaused)
            return;


        Debug.Log("numero della scleta:" + choiceIndex + " " + line + " " + countDialogue);
        
        setFirstActiveBtnSx = true;


        if(line == 3 && countDialogue == 1 && choiceIndex == 0){
            positiveMeet = false;
            Debug.Log("incontro con la madre negativo");

            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
        else if(line == 3 && countDialogue == 1 && choiceIndex == 1){
            positiveMeet = true;
            Debug.Log("incontro con la madre positivo");

            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
        else if(line == 0 && countDialogue == 5 && choiceIndex == 0){
            feeling = 0;
            bullo.GetComponent<Animator>().SetTrigger("sceltaUno");
            Debug.Log("feeling con ragazzino: " + feeling);
            dialoguePanel.SetActive(false);
            disableSpace = true;
            line++;
            currentStory.ChooseChoiceIndex(choiceIndex);
        }
        else if(line == 0 && countDialogue == 5 && choiceIndex == 1){
            feeling = 1;
            /*bullo.GetComponent<Animator>().SetTrigger("sceltaDue");
            dad.GetComponent<Animator>().SetTrigger("inizioCombattimento");
            Debug.Log("feeling con ragazzino: " + feeling);
            line++;
            dialoguePanel.SetActive(false);
            disableSpace = true;*/
            line++;
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
        else if (line == 1 && countDialogue == 5)
        {
            Debug.Log("ho scelto ... ");
            currentStory.ChooseChoiceIndex(choiceIndex);
            line++;
            ContinueStory();
        }
        else{
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
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
