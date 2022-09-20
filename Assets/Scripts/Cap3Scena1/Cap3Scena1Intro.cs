using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cap3Scena1Intro : MonoBehaviour
{
    public StoryScene currentScene1;
    public BottomBarController bottomBar; 
    private int countScene;

    public GameObject canvas2;
    public GameObject professor;
    public GameObject dad;
    public Camera camera;

    private Scene scene;

    public GameObject audioManager;

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
                
                canvas2.GetComponent<Canvas>().enabled = false;

                scene = SceneManager.GetActiveScene();
                if(scene.name == "Cap3_scena1"){
                    canvas2.SetActive(false);
                    professor.GetComponent<followDestinationProfessor>().enabled = true;
                }
                else{
                    //GESTIONE SCENA 2 del CAP 3
                    //BISOGNA FAR ANDARE BENE IL PADRE NELL'ALTRA STANZA
                    audioManager.GetComponent<AudioManager>().Play("walkDirt");
                    StartCoroutine(DadWalk());
                }

            }
        }
    }

    private IEnumerator DadWalk(){
        yield return new WaitForSeconds(2f);
        dad.GetComponent<followDestinationDad>().enabled = true;
        camera.GetComponent<CameraMovmentCap3>().enabled = true;
         yield return new WaitForSeconds(2f);
         audioManager.GetComponent<AudioManager>().Stop("walkDirt");
        canvas2.SetActive(false);
    }

 
}
