using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{

    public bool loadScene;
    public bool skip2Scene;

    public Animator transition;

    public float transitionTime = 1f;

    void Start(){
        loadScene = false;
        skip2Scene = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(loadScene){
            LoadNextLevel();
        }
        else if(skip2Scene)
            Skip2Scene();
    }

    public void LoadNextLevel(){
        loadScene = false;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void Skip2Scene(){
        skip2Scene = false;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 2));
    }

    IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
