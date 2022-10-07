using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameControllerQTERissa : MonoBehaviour
{
  
    public GameObject levelLoader;

    public BottomBarController bottomBar; 
    private int countScene;

    public StoryScene currentScene;
    public StoryScene currentScene_eng;

    // Start is called before the first frame update
    void Start()
    {

        if(LanguageChangeScript.language == 0)
            currentScene = currentScene_eng;

        countScene = 0;
        bottomBar.PlayScene(currentScene);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence() && countScene < 1)
                {
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
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
                    this.GetComponent<Canvas>().enabled = false;
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
