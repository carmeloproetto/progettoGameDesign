using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerIntroCap3 : MonoBehaviour
{
     public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    private int countScene;
    private int countText;

    public GameObject levelLoader;
    public AudioSource audioSource;

    public GameObject canvas;

    void Start()
    {
        countText = 1;
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
                if (bottomBar.IsLastSentence() && countScene < 1)
                {
                    Debug.Log(countText);
                    countText++;
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    backgroundController.SwitchImage(currentScene.background);
                    countScene++;
                    Debug.Log(countScene);
                }
                else if(!bottomBar.IsLastSentence() && countScene == 1)
                {
                    countText++;
                    Debug.Log(countText);
                    bottomBar.PlayNextSentence();
                }
                else if(countScene == 1){
                    //bisogna caricare la scena corretta
                    canvas.SetActive(false);
                    levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }
            }
            if(countText == 3){
                StartCoroutine(StartFade(audioSource, 10, 0f));
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
