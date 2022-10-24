using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenTutorial : MonoBehaviour
{

    public GameObject tutorial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         StartCoroutine(setTutorialPannel());
    }

    private IEnumerator setTutorialPannel(){
        if(Input.GetAxisRaw("Horizontal") == 1f || Input.GetAxisRaw("Horizontal") == -1f){
            Debug.Log("premuto");
            yield return new WaitForSeconds(2f);
            tutorial.SetActive(false);
        }
    }
}
