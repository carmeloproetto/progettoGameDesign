using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerIntroCap1 : MonoBehaviour
{
   public StoryScene currentScene;
   public StoryScene currentScene_eng;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    private int countScene;

    private int countText; 

    public GameObject levelLoader;

    public AudioSource audioSource;

    private bool firstSpacePressed;

    private int language;

    public GameObject canvasSkip;

    void Start()
    {
        language = LanguageChangeScript.language;
        countScene = 0;

        if(language == 0)
            currentScene = currentScene_eng;

        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
        countText = 1;
        firstSpacePressed = false;

        StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("audioIntro", 5, 1));
        //StartCoroutine(FindObjectOfType<AudioManager>().StartFade("audioIntro", 4, 1));
        //FindObjectOfType<AudioManager>().Play("audioIntro"));
    }

    void Update()
    {

        if(PauseMenu.GameIsPaused)
            return;
        
        
        if(Input.GetKeyDown(KeyCode.Space)  || Input.GetKeyDown(KeyCode.Return))
        {
            
                
            if (bottomBar.IsCompleted())
            {
                 countText++;
                Debug.Log("testo numero: " + countText);
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
                     countText++;
                    Debug.Log("testo numero: " + countText);
                    bottomBar.PlayNextSentence();
                }
                else if(countScene == 4){
                    this.GetComponent<Canvas>().enabled = false;
                    canvasSkip.SetActive(false);
                    levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }

            }else if(!bottomBar.IsCompleted() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                bottomBar.EndCurrentSentence();
            }

            if(countText == 7){
                //StartCoroutine(StartFade(audioSource, 2, 0f));
                //StartCoroutine(FindObjectOfType<AudioManager>().StopFade("audioIntro", 10, 0));
                //StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioIntro", 5));

            }
        }
        else if(Input.GetKeyDown(KeyCode.Z)){
            this.GetComponent<Canvas>().enabled = false;
            canvasSkip.SetActive(false);
            
            levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
        }
    }

 
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
