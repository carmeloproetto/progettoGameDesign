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

    void Start()
    {
        countScene = 0;
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence() && countScene < 5)
                {
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                    countScene++;
                    Debug.Log(countScene);
                }
                else if(!bottomBar.IsLastSentence() && countScene < 5)
                {
                    bottomBar.PlayNextSentence();
                }
                else if(countScene == 5){
                    //bisogna caricare la scena corretta
                    SceneManager.LoadScene("InfanziaP_background_2");
                }
            }
        }
    }
}
