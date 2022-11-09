using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerFineScena1 : MonoBehaviour
{
   public StoryScene currentScene1;
   public StoryScene currentScene2;
   public StoryScene currentScene1_eng;
   public StoryScene currentScene2_eng;
   
    public BottomBarController bottomBar; 
    private int countScene;

    private StoryScene currentScene_aux;

    public GameObject canvas2;
    
    public GameObject dlgMng;

    void Start()
    {
        countScene = 0;

        if(LanguageChangeScript.language == 0){
            currentScene1 = currentScene1_eng;
            currentScene2 = currentScene2_eng;
        }
        
        if(DialogueManager.feeling == 0)
            currentScene_aux = currentScene1;
        else
            currentScene_aux = currentScene2;
        bottomBar.PlayScene(currentScene_aux);
    }

    void Update()
    {
        if(PauseMenu.GameIsPaused){
        
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (bottomBar.IsCompleted())
            {
                Debug.Log("GamecontrollerFineScena1 countScene= " + countScene);
                if(DialogueManager.feeling == 0)
                {
                    if (bottomBar.IsLastSentence() && countScene < 3)
                    {
                        currentScene_aux = currentScene_aux.nextScene;
                        bottomBar.PlayScene(currentScene_aux);
                        
                        countScene++;
                        Debug.Log(countScene);
                    }
                    else if(!bottomBar.IsLastSentence() && countScene < 3)
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 3)
                    {
                        //disattiviamo il canvas
                        canvas2.SetActive(false);
                    
                    }
                }
                else
                {
                    if (bottomBar.IsLastSentence() && countScene < 1)
                    {
                        currentScene_aux = currentScene_aux.nextScene;
                        bottomBar.PlayScene(currentScene_aux);
                        
                        countScene++;
                        Debug.Log(countScene);
                    }
                    else if(!bottomBar.IsLastSentence() && countScene < 1)
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 1)
                    {
                        //disattiviamo il canvas
                        canvas2.SetActive(false);
                    
                    }
                }     
            }else if(!bottomBar.IsCompleted() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                bottomBar.EndCurrentSentence();
            }
        }
    }
}
