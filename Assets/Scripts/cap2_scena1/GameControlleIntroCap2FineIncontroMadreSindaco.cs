using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlleIntroCap2FineIncontroMadreSindaco : MonoBehaviour
{

    public StoryScene currentScene1;
    public StoryScene currentScene1_eng;
    public BottomBarController bottomBar; 
    private int countScene;

    public GameObject canvas2;
    public GameObject mom;

    // Start is called before the first frame update
    void Start()
    {
        if(LanguageChangeScript.language == 0)
            currentScene1 = currentScene1_eng;

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
                
                    //canvas2.Canvas.SetActive(false);
                    canvas2.GetComponent<Canvas>().enabled = false;
                    StartCoroutine(animationMom());

            }
        }
    }

    private IEnumerator animationMom(){
        yield return new WaitForSeconds(1f);
        mom.GetComponent<Animator>().SetBool("Cry", false);
        mom.GetComponent<Animator>().SetBool("Call", true);
        //mom.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        yield return new WaitForSeconds(1.5f);
        //facciamo partire il secondo dialogo
        if(mom.GetComponent<DialogueTriggerCap2>().language == 1)
            mom.GetComponent<DialogueTriggerCap2>().ink = mom.GetComponent<DialogueTriggerCap2>().inkJSON2;
        else if(mom.GetComponent<DialogueTriggerCap2>().language == 0)
            mom.GetComponent<DialogueTriggerCap2>().ink = mom.GetComponent<DialogueTriggerCap2>().inkJSON2_Eng;
        mom.GetComponent<DialogueTriggerCap2>().startConvByOtherScript();
        FindObjectOfType<AudioManager>().Stop("phoneRing");
        canvas2.GetComponent<GameControlleIntroCap2FineIncontroMadreSindaco>().enabled = false;
       }
}

