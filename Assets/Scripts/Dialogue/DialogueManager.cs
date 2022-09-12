using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    public GameObject tutorialPanel;

    //conto il numero di frasi alla quale siamo arrivati nella conversazione
    private int line;

    //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
    public bool disableSpace;

    //serve per verificare se il primo incontro dei genitori è andato a buon fine o meno, dipende dalla risposta alla seconda domanda nel cap 1
    public bool positiveMeet;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        viewChoice = false;
        countDialogue = 1;
        disableSpace = false;
        FindObjectOfType<AudioManager>().Play("birdsAudio");
    }

    public static DialogueManager GetInstance(){
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
                //serve per far partire la camminata nella scena cap1 quando siamo davanti al parco
                if(line == 1 && countDialogue == 3){
                    Debug.Log("Siamo nella terza conversazione alla fine della prima frase frase!");
                    disableSpace = true;
                    dad.GetComponent<PlayerController>().enabled = false;
                    dad.GetComponent<limitZone>().enabled = false;
                    mom.GetComponent<followDestination3>().enabled = false;
                    mom.GetComponent<followDestination4>().enabled = true;
                    dad.GetComponent<followDestination4>().enabled = true;
                }
                else
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
        dad.GetComponent<Animator>().SetFloat("Speed", 0f);
       
        StartCoroutine(activePanelAfterOneSecond());
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
        else if(countDialogue == 3){
            triggerZone.SetActive(false);
            mom.GetComponent<followDestination5>().enabled = true;
        }
        //cose da fare quando termina il quarto dialogo
        else if(countDialogue == 4){
            ragazzino.GetComponent<startBattleAnimation>().enabled = true;
        }



        line = 0;
        countDialogue++;
    }


    
    IEnumerator triggerDadControl(){    
        yield return new WaitForSeconds(2);
        tutorialPanel.SetActive(true);
        dad.GetComponent<PlayerController>().enabled = true;
        dad.GetComponent<limitZone>().enabled = true;
        yield return new WaitForSeconds(1f);
        mom.GetComponent<followDestination2>().enabled = true;
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
                    if(tagValue == "Mom" && countDialogue != 3){          
                        imageOfSpeaker.sprite = momImage;
                        dad.GetComponent<Animator>().SetBool("Speak", false);
                        mom.GetComponent<Animator>().SetBool("Speak", true);
                    }
                    if(tagValue == "Dad"){ 
                        imageOfSpeaker.sprite = dadImage;
                        dad.GetComponent<Animator>().SetBool("Speak", true);
                        mom.GetComponent<Animator>().SetBool("Speak", false);
                    }
                    if(tagValue == "Bully"){ 
                        imageOfSpeaker.sprite = bullyImage;
                    }
                    if(tagValue == "Lad"){ 
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
        Debug.Log("numero della scleta:" + choiceIndex + " " + line + " " + countDialogue);
        
        if(line == 3 && countDialogue == 1 && choiceIndex == 0){
            positiveMeet = false;
            Debug.Log("incontro con la madre negativo");
        }
        else if(line == 3 && countDialogue == 1 && choiceIndex == 1){
            positiveMeet = true;
            Debug.Log("incontro con la madre positivo");
        }

        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }


    public void ContinueStoryByOtherScript(){
        ContinueStory();
    }

}
