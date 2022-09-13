using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableCanvas : MonoBehaviour
{

    private bool aux;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        aux = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(aux == true){
            aux = false;
            canvas.SetActive(true);
        }

    }

    //parte a metà dell'animazione angry
    void enableFinalCanvas(){
        Debug.Log("animazione arrabbiata");
        aux = true;
    }
}
