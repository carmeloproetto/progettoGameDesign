using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerFineCap3 : MonoBehaviour
{
    public StoryScene final1;
    public StoryScene final2;
    public StoryScene final3;
    public StoryScene final4;
    public StoryScene final5;

    public BottomBarController bottomBar; 
    private int countScene;

    private StoryScene currentScene_aux;

    public GameObject canvas2;
    public GameObject levelLoader;
    
    

    void Start()
    {
        countScene = 0;
        
        if(DialogueManagerCap3_2.finale == 1)
            currentScene_aux = final1;
        else if(DialogueManagerCap3_2.finale == 2)
            currentScene_aux = final2;
        else if(DialogueManagerCap3_2.finale == 3)
            currentScene_aux = final3;
        else if(DialogueManagerCap3_2.finale == 4)
            currentScene_aux = final4;
        else if(DialogueManagerCap3_2.finale == 5)
            currentScene_aux = final5;
        

        bottomBar.PlayScene(currentScene_aux);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(DialogueManagerCap3_2.finale == 1){
                if (bottomBar.IsCompleted())
                {
                    Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
                    if (bottomBar.IsLastSentence() && countScene < 5)
                    {
                        currentScene_aux = currentScene_aux.nextScene;
                        bottomBar.PlayScene(currentScene_aux);
                        
                        countScene++;
                        Debug.Log(countScene);
                    }
                    else if(!bottomBar.IsLastSentence() && countScene < 5)
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 5){
                        //bisogna caricare la scena corretta
                        FindObjectOfType<AudioManager>().Stop("audioIntro");
                        this.GetComponent<Canvas>().enabled = false;
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    
                    }
                }
                else if (!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
                {
                    bottomBar.EndCurrentSentence();
                }
            }
            else if(DialogueManagerCap3_2.finale == 2){
                if (bottomBar.IsCompleted())
                {
                    Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
                    if (bottomBar.IsLastSentence() && countScene < 4)
                    {
                        currentScene_aux = currentScene_aux.nextScene;
                        bottomBar.PlayScene(currentScene_aux);
                        
                        countScene++;
                        Debug.Log(countScene);
                    }
                    else if(!bottomBar.IsLastSentence() && countScene < 4)
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 4){
                        //bisogna caricare la scena corretta
                        FindObjectOfType<AudioManager>().Stop("audioIntro");
                        this.GetComponent<Canvas>().enabled = false;
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    
                    }
                }
                else if (!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
                {
                    bottomBar.EndCurrentSentence();
                }
            }
            else if(DialogueManagerCap3_2.finale == 3){
                if (bottomBar.IsCompleted())
                {
                    Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
                    if (bottomBar.IsLastSentence() && countScene < 2)
                    {
                        currentScene_aux = currentScene_aux.nextScene;
                        bottomBar.PlayScene(currentScene_aux);
                        
                        countScene++;
                        Debug.Log(countScene);
                    }
                    else if(!bottomBar.IsLastSentence() && countScene < 2)
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 2){
                        //bisogna caricare la scena corretta
                        FindObjectOfType<AudioManager>().Stop("audioIntro");
                        this.GetComponent<Canvas>().enabled = false;
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    
                    }
                }
                else if (!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
                {
                    bottomBar.EndCurrentSentence();
                }
            }
            else if(DialogueManagerCap3_2.finale == 4){
                if (bottomBar.IsCompleted())
                {
                    Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
                    if (bottomBar.IsLastSentence() && countScene < 5)
                    {
                        currentScene_aux = currentScene_aux.nextScene;
                        bottomBar.PlayScene(currentScene_aux);
                        
                        countScene++;
                        Debug.Log(countScene);
                    }
                    else if(!bottomBar.IsLastSentence() && countScene < 5)
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 5){
                        //bisogna caricare la scena corretta
                        FindObjectOfType<AudioManager>().Stop("audioIntro");
                        this.GetComponent<Canvas>().enabled = false;
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    }
                }
                else if (!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
                {
                    bottomBar.EndCurrentSentence();
                }
            }
            else if(DialogueManagerCap3_2.finale == 5){
                if (bottomBar.IsCompleted())
                {
                    Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
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
                    else if(countScene == 1){
                        //bisogna caricare la scena corretta
                        FindObjectOfType<AudioManager>().Stop("audioIntro");
                        this.GetComponent<Canvas>().enabled = false;
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    
                    }
                }
                else if (!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
                {
                    bottomBar.EndCurrentSentence();
                }
            }
        }
    }

  
}
