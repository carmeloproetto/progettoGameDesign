using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerIntroCap2 : MonoBehaviour
{
  public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    private int countScene;

    public GameObject levelLoader;

    public AudioSource audioSource;

    private int countText;

    void Start()
    {
        countScene = 0;
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
        countText = 1;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence() && countScene < 0)
                {
                    countText++;
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                    countScene++;
                    Debug.Log(countScene);
                }
                else if(!bottomBar.IsLastSentence() && countScene == 0)
                {
                    countText++;
                    bottomBar.PlayNextSentence();
                }
                else if(countScene == 0){
                    //bisogna caricare la scena corretta   
                    this.GetComponent<Canvas>().enabled = false;
                    levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    //SceneManager.LoadScene("Cap2_Scena1_");
                }
            }

            if(countText == 3){
                StartCoroutine(StartFade(audioSource, 4, 0f));
            }
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
