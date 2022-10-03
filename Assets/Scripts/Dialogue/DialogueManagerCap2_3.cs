using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManagerCap2_3 : MonoBehaviour
{
[Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite momImage;
    public Sprite  mayorImage;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerCap2_3 instance;

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
    public GameObject canvas1;
    //public GameObject canvas2;
    

    private bool noAnimation;
    private bool no;



    public float feeling;

    public static int finale;

    public GameObject levelLoader;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        viewChoice = false;
        countDialogue = 1;
        disableSpace = false;
        feeling = DialogueManagerCap2.feeling;
        no = false;
    }

    public static DialogueManagerCap2_3 GetInstance(){
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
    }

    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }

        if(Input.GetKeyDown("space") && viewChoice == false){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);
                if(line == 3 && countDialogue == 2 && feeling < 0.5){
                    Debug.Log("chiudi la conversazione");
                    canvas1.SetActive(false);
                    finale = 2;
                    levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
                else if(line == 1 && countDialogue == 2 && no){
                    //mom.GetComponent<DialogueTriggerCap2_3>().enabled = false;
                    //this.GetComponent<DialogueManagerCap2_3>().enabled = false;
                    canvas1.SetActive(false);
                    mom.GetComponent<Animator>().SetBool("PutBack", false);
                    mom.GetComponent<Animator>().SetBool("Talk", false);
                    mom.GetComponent<DialogueTriggerCap2_3>().enabled = false;
                    this.GetComponent<DialogueManagerCap2_3>().enabled = false;
                    //mom.GetComponent<followDestinationCap2_3>().enabled = false;
                    //mom.GetComponent<followDestinationCap2_3_2>().enabled = true;
                }
                else if(line == 5 && countDialogue == 1){
                    noAnimation = true;
                     sindaco.GetComponent<Animator>().SetBool("Talk2", true);
                     ContinueStory();
                }
                else if(line == 6 && countDialogue == 1){
                    noAnimation = false;
                     sindaco.GetComponent<Animator>().SetBool("Talk2", false);
                     ContinueStory();
                }
                else
                    ContinueStory();
            }
        }
    }







    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        
        dialoguePanel.SetActive(true);
       // StartCoroutine(activePanelAfterOneSecond());
       ContinueStory();
    }


   /*  private IEnumerator activePanelAfterOneSecond(){
        yield return new WaitForSeconds(1f);
        dialoguePanel.SetActive(true);
     }*/


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);

        Debug.Log("sono qui dentro ExitDIalogueMOde");

        dialogueIsPlaying = false;
        //if(countDialogue != 1 && firstChoice){
            dialoguePanel.SetActive(false);
            dialogueText.text = "";
        //}

        //cose da fare quando termina il primo dialogo
        if(countDialogue == 1 && no){
            mom.GetComponent<Animator>().SetBool("PutBack", false);
            mom.GetComponent<Animator>().SetBool("Talk", false);
            mom.GetComponent<DialogueTriggerCap2_3>().enabled = false;
            this.GetComponent<DialogueManagerCap2_3>().enabled = false;
            //mom.GetComponent<followDestinationCap2_3>().enabled = false;
            //mom.GetComponent<followDestinationCap2_3_2>().enabled = true;
        }
        //cose da fare quando termina il secondo dialogo
        else if(countDialogue == 2){
           mom.GetComponent<DialogueTriggerCap2_3>().enabled = false;
           //canvas2.SetActive(true);
           finale = 1;
           levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
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
                        if(line != 7){
                            mom.GetComponent<Animator>().SetBool("Talk", true);
                        }
                        else if(no == false && line > 7){
                            
                            mom.GetComponent<Animator>().SetBool("Talk", true);
                        }
                        sindaco.GetComponent<Animator>().SetBool("Talk", false);
                    }
                    else if(tagValue == "Mayor" || tagValue == "Sindaco"){ 
                        imageOfSpeaker.sprite = mayorImage;
                        mom.GetComponent<Animator>().SetBool("Talk", false);
                        if(noAnimation == false)
                            sindaco.GetComponent<Animator>().SetBool("Talk", true);
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
        //if(choiceIndex == 0 && line == 3 && countDialogue == 1)
           
        if(line == 7 && countDialogue == 1){
            mom.GetComponent<Animator>().SetBool("Talk", false);
            mom.GetComponent<Animator>().SetBool("PutBack", true);
        }

        if(choiceIndex == 0 && line == 2 && countDialogue == 1){
            feeling -= 0.25f;
        }

        if(choiceIndex == 0 && line == 13 && countDialogue == 1){
            if(feeling >= 0.5){
                mom.GetComponent<DialogueTriggerCap2_3>().closeConv();
                mom.GetComponent<DialogueTriggerCap2_3>().ink = mom.GetComponent<DialogueTriggerCap2_3>().inkJSON2;
                mom.GetComponent<DialogueTriggerCap2_3>().startConvByOtherScript();
            }
            else if(feeling < 0.5){
                mom.GetComponent<DialogueTriggerCap2_3>().closeConv();
                mom.GetComponent<DialogueTriggerCap2_3>().ink = mom.GetComponent<DialogueTriggerCap2_3>().inkJSON3;
                mom.GetComponent<DialogueTriggerCap2_3>().startConvByOtherScript();
            }
        }
        else if(choiceIndex == 1 && line == 13 && countDialogue == 1)
            no = true;
        else if(choiceIndex == 1 && line == 0 && countDialogue == 2){
            no = true;

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

