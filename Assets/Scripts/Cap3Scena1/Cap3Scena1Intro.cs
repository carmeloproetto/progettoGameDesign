using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap3Scena1Intro : MonoBehaviour
{
    public StoryScene currentScene1;
    public BottomBarController bottomBar; 
    private int countScene;

    public GameObject canvas2;
    public GameObject professor;

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
                canvas2.SetActive(false);
                professor.GetComponent<followDestinationProfessor>().enabled = true;
                //CARICHIAMO QUI LA SCENA SUCCESSIVA
            }
        }
    }

 
}
