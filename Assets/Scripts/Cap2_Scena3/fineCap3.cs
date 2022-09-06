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

    //public GameObject canvas2;

    // Start is called before the first frame update
    void Start()
    {
         countScene = 0;
         if(DialogueManagerCap2_3.finale == 1)
            auxScene = currentScene1;
         else if(DialogueManagerCap2_3.finale == 2)
            auxScene = currentScene2;
         else if(DialogueManagerCap2_3.finale == 3)
            auxScene = currentScene3;
         
         
         bottomBar.PlayScene(auxScene);
          backgroundController.SetImage(auxScene.background);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                Debug.Log("scena numero " + countScene);

                if(DialogueManagerCap2_3.finale == 1){
                    if(!bottomBar.IsLastSentence())
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 4){
                        Debug.Log("scena 3 finita");
                        //disattiviamo il canvas e riabilitiamo il movimento del player
                        //canvas2.SetActive(false);
                        //DObbiamo caricare la nuova scena qui
                        SceneManager.LoadScene("Cap1_scena1");
                    }
                }
                else if(DialogueManagerCap2_3.finale == 2){
                     if (bottomBar.IsLastSentence() && countScene < 3)
                    {
                        auxScene = auxScene.nextScene;
                        bottomBar.PlayScene(auxScene);
                        backgroundController.SwitchImage(auxScene.background);
                        countScene++;
                    }
                    else if(!bottomBar.IsLastSentence() && countScene < 3)
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 3){
                        //bisogna caricare la scena corretta
                        SceneManager.LoadScene("Cap1_scena1");
                    }
                }
                else if(DialogueManagerCap2_3.finale == 3){
                    /*if (bottomBar.IsLastSentence() && countScene < 4)
                    {
                        auxScene = auxScene.nextScene;
                        bottomBar.PlayScene(auxScene);
                        backgroundController.SwitchImage(auxScene.background);
                        countScene++;
                        Debug.Log(countScene);
                    }*/
                    if(!bottomBar.IsLastSentence() && countScene < 4)
                    {
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 4){
                        //bisogna caricare la scena corretta
                        SceneManager.LoadScene("Cap1_scena1");
                    }
                }



            }
        }
    }
}
