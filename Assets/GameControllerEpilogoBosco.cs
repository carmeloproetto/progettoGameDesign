using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerEpilogoBosco : MonoBehaviour
{
    public StoryScene currentScene;
    public StoryScene currentScene_eng;

    public BottomBarController bottomBar; 
    private int countScene;

    public GameObject canvas2;

    public GameObject levelLoader;

    public GameObject canvasSkip;

    private bool aux;

    private bool wait;


    // Start is called before the first frame update
    void Start()
    {
        aux = true;
        wait = false;
        if(LanguageChangeScript.language == 0){
            currentScene = currentScene_eng;
        }
        bottomBar.PlayScene(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.GameIsPaused){
            return;
        }


        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted() && wait)
            {       
                    wait = false;
                    StartCoroutine(Load());
                    
            }
        }
        if(bottomBar.IsCompleted() && aux){
            aux = false;
            StartCoroutine(StartSkip());
        }
    }

    IEnumerator StartSkip(){
        yield return new WaitForSeconds(1.5f);
        wait = true;
        canvasSkip.SetActive(true); 
    }

    IEnumerator Load(){
        yield return new WaitForSeconds(0.1f);
        canvas2.GetComponent<Canvas>().enabled = false;
        canvasSkip.SetActive(false); 
        yield return new WaitForSeconds(2f);
        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
    }
}
