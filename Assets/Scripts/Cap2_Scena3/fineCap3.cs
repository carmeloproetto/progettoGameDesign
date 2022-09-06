using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class fineCap3 : MonoBehaviour
{
    public StoryScene currentScene1;
    public StoryScene currentScene2;
    public StoryScene currentScene3;
    public StoryScene auxScene;
    public BottomBarController bottomBar; 
    private int countScene;

    public BackgroundController backgroundController;

    public GameObject canvas2;

    // Start is called before the first frame update
    void Start()
    {
         countScene = 0;
         auxScene = currentScene1;
         bottomBar.PlayScene(auxScene);
          backgroundController.SetImage(auxScene.background);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if(!bottomBar.IsLastSentence())
                {
                    countScene++;
                    bottomBar.PlayNextSentence();
                }
                else if(countScene == 4){
                    //disattiviamo il canvas e riabilitiamo il movimento del player
                    canvas2.SetActive(false);
                    //DObbiamo caricare la nuova scena qui
                }
            }
        }
    }

 
}
