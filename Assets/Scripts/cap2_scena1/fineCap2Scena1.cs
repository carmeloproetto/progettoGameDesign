using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class fineCap2Scena1 : MonoBehaviour
{
    public StoryScene currentScene1;
    public StoryScene currentScene1_eng;
    public BottomBarController bottomBar; 
    private int countScene;

    public GameObject canvas2;
    public GameObject levelLoader;

    // Start is called before the first frame update
    void Start()
    {

        if(LanguageChangeScript.language == 0)
            currentScene1 = currentScene1_eng;

         countScene = 0;
         bottomBar.PlayScene(currentScene1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
                canvas2.GetComponent<Canvas>().enabled = false;
                //CARICHIAMO QUI LA SCENA SUCCESSIVA
                this.GetComponent<Canvas>().enabled = false;
                levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
            }
            else if(!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
            {
                bottomBar.EndCurrentSentence();
            }
        }
    }

 
}
