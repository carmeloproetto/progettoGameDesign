using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerEpilogoParco : MonoBehaviour
{
    public StoryScene currentScene;
    public StoryScene currentScene_eng;

    public BottomBarController bottomBar; 
    private int countScene;

    public GameObject canvas2;

    // Start is called before the first frame update
    void Start()
    {
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

        if (bottomBar.IsCompleted())
        {       
            StartCoroutine(HideCanvas());
        }
    }

    IEnumerator HideCanvas(){
        yield return new WaitForSeconds(2f);
        canvas2.SetActive(false); 
    }
}
