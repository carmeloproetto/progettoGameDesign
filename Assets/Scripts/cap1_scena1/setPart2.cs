using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPart2 : MonoBehaviour
{

    public GameObject dad;
    public GameObject triggerDialogueBulloRagazzino;
    public GameObject ragazzino;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableDadMovement());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      private IEnumerator EnableDadMovement(){
        yield return new WaitForSeconds(0.5f);
        dad.GetComponent<PlayerController>().enabled = true;
        dad.GetComponent<limitZone>().enabled = true;
        triggerDialogueBulloRagazzino.SetActive(true);
        ragazzino.SetActive(true);
    }
}
