using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueManagerCap3_2 : MonoBehaviour{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite dadImage;
    public Sprite thiefImage;
    public Sprite professorImage;

    public GameObject levelLoader;

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

    EventSystem m_EventSystem;
    public GameObject btn_choice_sx;
    public GameObject btn_choice_dx;
    private bool setFirstActiveBtnSx;
    public TextMeshProUGUI textmeshPro;
    public TextMeshProUGUI textmeshPro2;

    private Animator padreAnimator;
    private Animator ragazzoAnimator;
    private Animator profAnimator;

   

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        viewChoice = false;
        countDialogue = 2;
        disableSpace = false;

        QteScoiattoliEnd = false;
        //DA DECOMMENTARE
        //feeling = DialogueManager.feeling;
        feeling = 12;
        helpLad = 1;

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

        m_EventSystem = EventSystem.current;
        setFirstActiveBtnSx = true;

        padreAnimator = dad.GetComponent<Animator>();
        ragazzoAnimator = ragazzo.GetComponent<Animator>();
        profAnimator = professore.GetComponent<Animator>();
    }

    private void Update(){

        if(PauseMenu.GameIsPaused){
            setFirstActiveBtnSx = true;
            return;
        }

        setFirstActiveButton();


        if(!dialogueIsPlaying && !startCorsa){
            return;
        }

        if(Input.GetKeyDown("space") && viewChoice == false && !startCorsa){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);
                
                if(line == 1 && countDialogue == 1){
                    ragazzoAnimator.SetBool("Speak", true);
                    padreAnimator.SetBool("Speak", false);
                }
                else if(line == 2 && countDialogue ==1)
                {
                    ragazzoAnimator.SetBool("Speak", false);
                }
                else if (line == 3 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", true);
                }
                else if (line == 4 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", false);
                    padreAnimator.SetBool("Speak", true);
                }
                else if (line == 5 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", true);
                    padreAnimator.SetBool("Speak", false);
                }
                else if (line == 6 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", true);
                    padreAnimator.SetBool("Speak", false);
                }
                else if (line == 6 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", true);
                    padreAnimator.SetBool("Speak", false);
                }
                else if (line == 8 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", true);
                    padreAnimator.SetBool("Speak", false);
                }
                else if (line == 9 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", false);
                    padreAnimator.SetBool("Speak", false);
                }
                else if (line == 10 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", true);
                    padreAnimator.SetBool("Speak", false);
                }
                else if (line == 12 && countDialogue == 1)
                {
                    ragazzoAnimator.SetBool("Speak", true);
                    padreAnimator.SetBool("Speak", false);
                }

                //il padre non sta aiutando il ragazzo
                if( helpLad == 0) 
                {
                    if (line == 1 && countDialogue == 2)
                    {
                        padreAnimator.SetBool("isArguing", true);
                    }
                    else if (line == 2 && countDialogue == 2)
                    {
                        ragazzoAnimator.SetTrigger("Continue");
                        padreAnimator.SetBool("isArguing", false);
                    }
                    else if (line == 3 && countDialogue == 2)
                    {
                        padreAnimator.SetBool("isArguing", false);
                        profAnimator.SetBool("isArguing", true);
                        ragazzoAnimator.SetTrigger("Continue"); //il ragazzo si alza
                    }
                }
                //il padre sta aiutando il ragazzo
                else if( helpLad == 1)
                {
                    //il padre si avvicina al ragazzo che è a terra
                    if (line == 1 && countDialogue == 2)
                    {
                        //la camera segue il padre
                        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = true;
                        padreAnimator.SetTrigger("Avvicinati");
                    }
                    else if (line == 2 && countDialogue == 2)
                    {
                        padreAnimator.SetBool("Speak", true);
                    }
                    else if(line == 3 && countDialogue == 2)
                    {
                        //il ragazzo risponde al padre
                        
                    }
                    else if (line == 4 && countDialogue == 2)
                    {
                        //il padre afferra la gabbia
                        padreAnimator.SetTrigger("Continue");
                    }

                }

                ContinueStory();
            }
        }


        
        //MINI GIOCO CORSA
        if(startCorsa){
            if(Input.GetKeyDown("space")){  
                StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("QteCorsa", 2, 1)); 
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
            Debug.Log("conversazione finita");
            ragazzoAnimator.SetBool("Speak", false);
            padreAnimator.SetBool("Speak", false);
            tutorialCorsa.SetActive(true);
            dad.GetComponent<DialogueTriggerCap3_1>().closeConv();
            startCorsa = true;
        }
        //cose da fare quando termina il secondo dialogo
        else if(countDialogue == 2){
            dad.GetComponent<DialogueTriggerCap3_1>().enabled = false;
            Debug.Log("conversazione finita");
            if(helpLad == 0){
                //non lo stiamo aiutando
                if (feeling < 0.5 && !auxFinal)
                {
                    //il ragazzo libera gli scoiattoli
                    Debug.Log("Libera gli scoiattoli");
                    ragazzoAnimator.SetTrigger("LiberaScoiattoli");
                    finale = 1;
                    //levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;

                }
                else if (feeling >= 0.5 && !auxFinal)
                {
                    //il ragazzo dà la gabbia al padre
                    Debug.Log("Ragazzo dà la gabbia al padre");
                    finale = 2;
                    levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
                else if (auxFinal)
                {
                    //il padre spinge il ragazzo nel fiume
                    Debug.Log("Spinge il ragazzo nel fiume");
                    ragazzoAnimator.SetTrigger("Continue");
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = true;
                    finale = 3;
                    //levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
                    
            }
            else{
                //lo stiamo aiutando
                if (!auxFinal)
                {
                    finale = 5;
                    //levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
                    

                else if(feeling >= 0.5 && auxFinal)
                {
                    finale = 1;
                    //levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
                    
                else if(feeling < 0.5 && auxFinal)
                {
                    finale = 4;
                    //levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
                    
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
                    if(tagValue == "Dad" || tagValue == "Papà"){ 
                        imageOfSpeaker.sprite = dadImage;
                    }
                    else if(tagValue == "Lad" || tagValue == "Ragazzo"){
                        padreAnimator.SetBool("Speak", false);
                        padreAnimator.SetBool("isArguing", false);
                        imageOfSpeaker.sprite = thiefImage;
                    }
                    else if(tagValue == "Professor" || tagValue == "Professore"){
                        padreAnimator.SetBool("Speak", false);
                        padreAnimator.SetBool("isArguing", false);
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
        
        if(choiceIndex == 0 && line == 3 && countDialogue == 1 && feeling >= 0.5f){
            feeling -= 0.25f;
            Debug.Log("nuovo feeling: " + feeling);
            currentStory.EvaluateFunction("changeFeeling", feeling);
        }
        if( line == 5 && countDialogue == 1)
        {
            ragazzoAnimator.SetBool("Speak", false);
            padreAnimator.SetBool("Speak", true);
        }
        if (line == 7 && countDialogue == 1)
        {
            ragazzoAnimator.SetBool("Speak", false);
            padreAnimator.SetBool("Speak", true);
        }
        if (choiceIndex == 0 && line == 7 && countDialogue == 1 && feeling < 0.5f){
            feeling -= 0.25f;
            Debug.Log("nuovo feeling: " + feeling);
            currentStory.EvaluateFunction("changeFeeling", feeling);
        }
        if (choiceIndex == 0 && line == 7 && countDialogue == 1 && feeling >= 0.5f)
        {
            helpLad = 1;
        }
        if (line == 11 && countDialogue == 1)
        {
            ragazzoAnimator.SetBool("Speak", false);
            padreAnimator.SetBool("Speak", true);
        }

        //Converasazione due
        if (choiceIndex == 0 && line == 2 && countDialogue == 2)
        {
            Debug.Log("Dammi la gabbia");
        }
        if (choiceIndex == 1 && line == 2 && countDialogue == 2)
        {
            feeling -= 0.25f;
            currentStory.EvaluateFunction("changeFeeling", feeling);
            Debug.Log("Avvicinati");
        }

        if ( choiceIndex == 0 && line == 4 && countDialogue == 2)
        {
            padreAnimator.SetBool("Speak", true);
        }
        if (helpLad == 0 && choiceIndex == 1 && line == 4 && countDialogue == 2)
            auxFinal = true;

        //il padre sale sulla macchina
        if(helpLad == 1 && choiceIndex == 0 && line == 5 && countDialogue == 2)
        {
            padreAnimator.SetTrigger("EntraInMacchina");
            auxFinal = true;
        }
        //il padre non sale sulla macchina
        if (helpLad == 1 && choiceIndex == 1 && line == 5 && countDialogue == 2)
        {
            padreAnimator.SetTrigger("Fermati");
            auxFinal = true;
        }




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

