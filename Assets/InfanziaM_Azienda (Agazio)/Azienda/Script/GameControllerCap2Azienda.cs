using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerCap2Azienda : MonoBehaviour
{
 public StoryScene currentScene;
    public BottomBarController bottomBar;
    
    private int countScene;

    public GameObject levelLoader;

    void Start()
    {
        countScene = 0;
        bottomBar.PlayScene(currentScene);
    }

    void Update()
    {

        if(PauseMenu.GameIsPaused){
        
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                Debug.Log(countScene);
                if (bottomBar.IsLastSentence() && countScene < 1)
                {
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    countScene++;
                    Debug.Log(countScene);
                }
                else if(!bottomBar.IsLastSentence() && countScene < 1)
                {
                    bottomBar.PlayNextSentence();
                    countScene++;
                }
                else if(countScene == 1){
                   
                    this.GetComponent<Canvas>().enabled = false;
                    FindObjectOfType<AudioManager>().Stop("crowd");
                    
                    FindObjectOfType<AudioManager>().Stop("birds");
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
