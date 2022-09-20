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
    private int countAux;

    public BackgroundController backgroundController;

    public AudioSource audioSource;

    public GameObject levelLoader;

    //public GameObject canvas2;

    // Start is called before the first frame update
    void Start()
    {
        countAux = 1;
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
                        countAux++;
                        Debug.Log(countAux);
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 4){
                        Debug.Log("scena 3 finita");
                        //disattiviamo il canvas e riabilitiamo il movimento del player
                        //canvas2.SetActive(false);
                        //DObbiamo caricare la nuova scena qui
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    }

                    if(countAux == 5){
                        StartCoroutine(StartFade(audioSource, 9, 0f));
                    }
                }
                else if(DialogueManagerCap2_3.finale == 2){
                     if (bottomBar.IsLastSentence() && countScene < 3)
                    {
                        auxScene = auxScene.nextScene;
                        bottomBar.PlayScene(auxScene);
                        countAux++;
                        Debug.Log(countAux);
                        backgroundController.SwitchImage(auxScene.background);
                        countScene++;
                    }
                    else if(!bottomBar.IsLastSentence() && countScene < 3)
                    {
                        countScene++;
                        countAux++;
                        Debug.Log(countAux);
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 3){
                        //bisogna caricare la scena corretta
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    }
                    if(countAux == 4){
                        StartCoroutine(StartFade(audioSource, 9, 0f));
                    }
                }
                else if(DialogueManagerCap2_3.finale == 3){
                    if (bottomBar.IsLastSentence() && countScene < 4)
                    {
                        countAux++;
                    }
                    if(!bottomBar.IsLastSentence() && countScene < 4)
                    {
                        countAux++;
                        countScene++;
                        bottomBar.PlayNextSentence();
                    }
                    else if(countScene == 4){
                        //bisogna caricare la scena corretta
                        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
                    }
                    if(countAux == 5){
                        StartCoroutine(StartFade(audioSource, 9, 0f));
                    }
                }
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
