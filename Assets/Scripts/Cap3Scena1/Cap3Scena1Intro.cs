using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cap3Scena1Intro : MonoBehaviour
{
    public StoryScene currentScene1;
    public StoryScene currentScene1_eng;
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
        scene = SceneManager.GetActiveScene();
        if(scene.name == "Cap3_scena1"){
            StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioIntro", 2, 0));
            StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("coffee", 4, 0.01f));
        }
        else{
            StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("walkDirt", 3, 1));
        }



        if(LanguageChangeScript.language == 0)
            currentScene1 = currentScene1_eng;

         countScene = 0;
         bottomBar.PlayScene(currentScene1);
    }

    void Update()
    {
        if(PauseMenu.GameIsPaused){
            return;
        }
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                
                canvas2.GetComponent<Canvas>().enabled = false;

                scene = SceneManager.GetActiveScene();
                if(scene.name == "Cap3_scena1"){
                    canvas2.SetActive(false);
                    professor.GetComponentInParent<followDestinationProfessor>().enabled = true;
                }
                else{
                    //GESTIONE SCENA 2 del CAP 3
                    //BISOGNA FAR ANDARE BENE IL PADRE NELL'ALTRA STANZA
                    //audioManager.GetComponent<AudioManager>().Play("walkDirt");
                    dad.GetComponent<Animator>().SetTrigger("StandUp");
                    //StartCoroutine(DadWalk());
                    canvas2.SetActive(false);
                }

            }
            else if(!bottomBar.IsCompleted() && Input.GetKeyDown(KeyCode.Space))
            {
                bottomBar.EndCurrentSentence();
            }
        }
    }

    private IEnumerator DadWalk(){
        yield return new WaitForSeconds(2f);
         yield return new WaitForSeconds(2f);
        canvas2.SetActive(false);
    }

 
}
