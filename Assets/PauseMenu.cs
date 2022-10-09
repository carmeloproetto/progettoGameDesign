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
        Debug.Log("PAUSE");
       // background.SetActive(true);
        pauseMenuUI.SetActive(true);
        canvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
