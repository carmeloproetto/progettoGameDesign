using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerIntroCap1 : MonoBehaviour
{
   public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    private int countScene;

    public GameObject levelLoader;

    void Start()
    {
        countScene = 0;
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
        FindObjectOfType<AudioManager>().Play("audioIntro");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence() && countScene < 4)
                {
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                    countScene++;
                    Debug.Log(countScene);
                }
                else if(!bottomBar.IsLastSentence() && countScene < 4)
                {
                    bottomBar.PlayNextSentence();
                }
                else if(countScene == 4){
                    //StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioIntro", 4f));
                    FindObjectOfType<AudioManager>().Stop("audioIntro");
                    //SceneManager.LoadScene("Cap1_scena1");
                    this.GetComponent<Canvas>().enabled = false;
                    levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }

            }
        }
    }
}
