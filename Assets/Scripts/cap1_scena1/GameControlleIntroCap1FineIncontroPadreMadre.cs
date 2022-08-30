using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlleIntroCap1FineIncontroPadreMadre : MonoBehaviour
{
   public StoryScene currentScene1;
   public StoryScene currentScene2;
    public BottomBarController bottomBar; 
    private int countScene;

    private StoryScene currentScene_aux;

    public GameObject canvas2;
    public GameObject dad;
    public GameObject dlgMng;
    public GameObject setterPart2;

    void Start()
    {
        countScene = 0;
        
        if(dlgMng.GetComponent<DialogueManager>().positiveMeet == false)
            currentScene_aux = currentScene1;
        else
            currentScene_aux = currentScene2;
        bottomBar.PlayScene(currentScene_aux);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
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
                else if(countScene == 1){
                    //disattiviamo il canvas e riabilitiamo il movimento del player
                    canvas2.SetActive(false);
                    setterPart2.SetActive(true);
                }
            }
        }
    }

  
}