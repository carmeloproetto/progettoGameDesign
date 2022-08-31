using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class fineCap2Scena1 : MonoBehaviour
{
    public StoryScene currentScene1;
    public BottomBarController bottomBar; 
    private int countScene;

    public GameObject canvas2;

    // Start is called before the first frame update
    void Start()
    {
         countScene = 0;
         bottomBar.PlayScene(currentScene1);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                Debug.Log("GamecontrolleCap1Intro countScene= " + countScene);
                canvas2.GetComponent<Canvas>().enabled = false;
                //CARICHIAMO QUI LA SCENA SUCCESSIVA
            }
        }
    }

 
}
