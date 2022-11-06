using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("audioEpilogoFine", 3, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadMainMenu(){
        GameObject.Destroy(GameObject.Find("AudioManager"));
        SceneManager.LoadScene("Menu_scene");
    }   
}
