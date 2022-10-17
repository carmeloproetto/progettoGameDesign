using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManagerAzienda : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private Image imageOfSpeaker;


    public Sprite momImage;
    public Sprite employee1Image;
    public Sprite employee2Image;


    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerAzienda instance;

    private const string SPEAKER_TAG = "speaker";
    //private const string PORTRAIT_TAG = "portrait";
    //private const string LAYOUT_TAG = "layout";

    //serve per non poter premere spazio davanti ad una domanda
    private bool viewChoice;

    //serve per tenere traccia di che dialogo stiamo ascoltando
    private int countDialogue;

    public GameObject mom;

    //conto il numero di frasi alla quale siamo arrivati nella conversazione
    private int line;

    //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
    public bool disableSpace;


    private void Awake(){
        if(instance != null){
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;

        viewChoice = false;
        countDialogue = 1;
        disableSpace = false;
    }

    public static DialogueManagerAzienda GetInstance(){
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

        /*if(Input.GetKeyDown("space") && viewChoice == false){
            //disable space serve nelle scene dove la conversazione deve andare avanti in automatico senza premere lo spazio
            if(disableSpace == false){
                //disableSpace = true;
                //StartCoroutine(disableSpaceFunction());
                line++;
                Debug.Log("line: " + line + " countDialogue: " + countDialogue);

                if(line == 1 && countDialogue == 3){
                  
                }
                else
                    ContinueStory();
            }
        }*/
    }


    /*private IEnumerator disableSpaceFunction(){
        yield return new WaitForSeconds(1f);
        disableSpace = false;
     }*/


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
        disableSpace = false;
     }


    private IEnumerator ExitDialogueMode(){
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";


        //cose da fare quando termina il primo dialogo
        if(countDialogue == 1){
          
        }
        //cose da fare quando termina il secondo dialogo
        else if(countDialogue == 2){
           
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
                    //displayNameText.text = tagValue;
                    if(tagValue == "Mom" || tagValue == "Mamma"){          
                        imageOfSpeaker.sprite = momImage;
                        displayNameText.text = tagValue;
                    }
                    else if(tagValue == "employee 1" || tagValue == "dipendente 1"){          
                        imageOfSpeaker.sprite = employee1Image;
                        if(tagValue == "employee 1")
                            displayNameText.text = "employee";
                        else
                            displayNameText.text = "dipendente";
                    }
                    else if(tagValue == "employee 2" || tagValue == "dipendente 2"){          
                        imageOfSpeaker.sprite = employee2Image;
                        if(tagValue == "employee 2")
                            displayNameText.text = "employee";
                        else
                            displayNameText.text = "dipendente";
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
        
        if(line == 3 && countDialogue == 1 && choiceIndex == 0){
            
        }
        else if(line == 3 && countDialogue == 1 && choiceIndex == 1){
            
        }

        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }


    public void ContinueStoryByOtherScript(){
        ContinueStory();
    }

}
