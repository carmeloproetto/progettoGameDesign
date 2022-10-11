using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerQTESpazzatura : MonoBehaviour
{

    public StoryScene currentScene1;
    public StoryScene currentScene2;
    public StoryScene currentScene3;
    public StoryScene currentScene4;
    public StoryScene currentScene1_eng;
    public StoryScene currentScene2_eng;
    public StoryScene currentScene3_eng;
    public StoryScene currentScene4_eng;

    public BottomBarController bottomBar; 
    private int countScene;

    public StoryScene currentScene_aux;
    public GameObject canvas2;
    public GameObject dad;
    public TextMeshProUGUI barText;


    public static int countDialogueQte;
    public static bool aux;

    public GameObject levelLoader;

    void Start()
    {
        Debug.Log("countDialogueQTE: " + countDialogueQte);
        countScene = 0;
        barText.text = "";

        if(LanguageChangeScript.language == 0){
            currentScene1 = currentScene1_eng;
            currentScene2 = currentScene2_eng;
            currentScene3 = currentScene3_eng;
            currentScene4 = currentScene4_eng;
        }



        currentScene_aux = currentScene1;

        bottomBar.PlayScene(currentScene1);
    }

    void Update(){
        
        if(PauseMenu.GameIsPaused){
        
            return;
        }
        
        if(!aux){
            if(countDialogueQte == 1){
                currentScene_aux = currentScene2;
                aux = true;
                bottomBar.PlayScene(currentScene_aux);
            }
            else if(countDialogueQte == 2){
                currentScene_aux = currentScene3;
                aux = true;
                bottomBar.PlayScene(currentScene_aux);
            }
            else if(countDialogueQte == 3){
                currentScene_aux = currentScene4;
                aux = true;
                bottomBar.PlayScene(currentScene_aux);
            }
            Debug.Log("countDialogueQTE: " + countDialogueQte);
        }


        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                    if(currentScene_aux != currentScene4){
                        dad.GetComponent<Animator>().SetTrigger("qteTrigger");
                        barText.text = "";
                        canvas2.GetComponent<Canvas>().enabled = false;
                        canvas2.GetComponent<GameControllerQTESpazzatura>().enabled = false; 
                        
                    }
                    else if(currentScene_aux == currentScene4){
                        canvas2.GetComponent<Canvas>().enabled = false;
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    }
            }
            else if(!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
            {
                bottomBar.EndCurrentSentence();
            }
        }



    }



}
