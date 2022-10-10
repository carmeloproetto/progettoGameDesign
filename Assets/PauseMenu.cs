using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] MenuButtonController menuButtonController;
    public GameObject canvas;
    public GameObject pauseMenuUI;
   // public GameObject background;
    public GameObject tutorialMenuUI;
    public GameObject optionsMenuUI;
    public AudioSource audioSourceMenu;

    private AudioSource[] allAudioSources;

    void Start () {
		audioSourceMenu = GetComponent<AudioSource>();
        
	}


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("MENU" + GameIsPaused);
            if (GameIsPaused)
            {
                menuButtonController.index = 0;
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            Debug.Log("sto mpremendo su");



        }
    }

    public void Resume()
    {
        audioSourceMenu.enabled = false;
        allAudioSources = FindObjectsOfType<AudioSource>();
        StartAllAudio();
        audioSourceMenu.Stop();
        Debug.Log("RESUME");
        tutorialMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
       // background.SetActive(false);
        pauseMenuUI.SetActive(false);
        canvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
     
    }

    public void Pause()
    {
        audioSourceMenu.enabled = true;
        allAudioSources = FindObjectsOfType<AudioSource>();
        StopAllAudio();
        audioSourceMenu.Play();
        Debug.Log("PAUSE");
       // background.SetActive(true);
        pauseMenuUI.SetActive(true);
        canvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void StopAllAudio()
    {

        // for (var audioS : AudioSource in allAudioSources)
        foreach (AudioSource audioSource in allAudioSources)
        {
            Debug.Log("AUDIO SOURCES" + allAudioSources);
            audioSource.Pause();
        }
    }

    public void StartAllAudio()
    {
        //for (var audioS : AudioSource in allAudioSources)
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }
}
