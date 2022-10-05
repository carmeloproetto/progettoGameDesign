using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerIntroCap1 : MonoBehaviour
{
   public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;
    private int countScene;

    private int countText; 

    public GameObject levelLoader;

    public AudioSource audioSource;

    private bool firstSpacePressed;

    void Start()
    {
        countScene = 0;
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
        //FindObjectOfType<AudioManager>().Play("audioIntro");
        countText = 1;
        firstSpacePressed = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            //if (firstSpacePressed)
            //{
            //    bottomBar.EndCurrentSentence();
            //    firstSpacePressed = !firstSpacePressed;
            //}
                
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
                    //StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioIntro", 4f));
                    //FindObjectOfType<AudioManager>().Stop("audioIntro");
                    //SceneManager.LoadScene("Cap1_scena1");
                    this.GetComponent<Canvas>().enabled = false;
                    levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                }

            }else if(!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
            {
                bottomBar.EndCurrentSentence();
            }

            if(countText == 7){
                //StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioIntro", 4f));
                StartCoroutine(StartFade(audioSource, 2, 0f));
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
