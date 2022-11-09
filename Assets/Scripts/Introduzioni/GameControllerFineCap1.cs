using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerFineCap1 : MonoBehaviour
{
  public StoryScene currentScene;
  public StoryScene currentScene_eng;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    private int countScene;

    public GameObject levelLoader;
    private bool aux;


    public GameObject canvasSkip;

    void Start()
    {
        if(LanguageChangeScript.language == 0)
            currentScene = currentScene_eng;

        countScene = 0;
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
        StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("birds", 2, 0));
        StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("audioIntro", 3, 1));
        aux = true;
    }

    void Update()
    {

        if(PauseMenu.GameIsPaused)
            return;

         /*if(aux){
            StartCoroutine(StartFade(audioSource, 4, 0f));
            aux = false;
            }*/

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence() && countScene < 0)
                {
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                    countScene++;
                    Debug.Log(countScene);
                }
                else if(!bottomBar.IsLastSentence() && countScene == 0)
                {
                    bottomBar.PlayNextSentence();
                }
                else if(countScene == 0){
                    //bisogna caricare la scena corretta
                    this.GetComponent<Canvas>().enabled = false;
                    canvasSkip.SetActive(false);
                    //StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioIntro", 5, 1));
                    levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    //SceneManager.LoadScene("Cap2_Scena1_");
                }
            }
            else if (!bottomBar.IsCompleted() && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)))
            {
                bottomBar.EndCurrentSentence();
            }
        }
         else if(Input.GetKeyDown(KeyCode.E)){
            this.GetComponent<Canvas>().enabled = false;
            canvasSkip.SetActive(false);
            levelLoader.GetComponent<LevelLoaderScript>().skip2Scene = true;
         }
    }

   /* public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        yield return new WaitForSeconds(6);
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }*/

}
