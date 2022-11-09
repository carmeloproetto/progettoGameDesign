using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlleIntroCap1FineIncontroPadreMadre : MonoBehaviour
{
   public StoryScene currentScene1;
   public StoryScene currentScene2;
   public StoryScene currentScene1_eng;
   public StoryScene currentScene2_eng;
    public BottomBarController bottomBar; 
    private int countScene;

    private StoryScene currentScene_aux;

    public GameObject canvas2;
    public GameObject dad;
    public GameObject dlgMng;
    public GameObject setterPart2;

    private int language;

    private bool disableSpace;

    void Start()
    {
        countScene = 0;
        
        language = LanguageChangeScript.language;

        disableSpace = true;
        

        if(language == 0){
            currentScene1 = currentScene1_eng;
            currentScene2 = currentScene2_eng;
        }

        if(dlgMng.GetComponent<DialogueManager>().positiveMeet == false)
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
        
        
        if(bottomBar.IsCompleted()){
            StartCoroutine(ActiveSpace());
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (bottomBar.IsCompleted() && !disableSpace)
            {        
                /*Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
                if (bottomBar.IsLastSentence() && countScene == 0)
                {
                    currentScene_aux = currentScene_aux.nextScene;
                    bottomBar.PlayScene(currentScene_aux);
                    
                    countScene++;
                    Debug.Log(countScene);
                }
                else if(!bottomBar.IsLastSentence() && countScene == 0)
                {
                    countScene++;
                    bottomBar.PlayNextSentence();
                }
                else if(countScene == 1){*/
                    //disattiviamo il canvas e riabilitiamo il movimento del player
                    //canvas2.SetActive(false);
                    canvas2.GetComponent<Canvas>().enabled = false;
                    setterPart2.SetActive(true);
                //}
            }
            else if(!bottomBar.IsCompleted() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                bottomBar.EndCurrentSentence();
            }
        }
    }

     IEnumerator ActiveSpace(){
        yield return new WaitForSeconds(2f);
        disableSpace = false;
    }

  
}
