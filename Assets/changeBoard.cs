using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBoard : MonoBehaviour
{

    public GameObject ita;
    public GameObject eng;

    // Start is called before the first frame update
    void Start()
    {
        if(LanguageChangeScript.language == 0){
            ita.SetActive(false);
            eng.SetActive(true);
        }
        else{
            ita.SetActive(true);
            eng.SetActive(false);
        }
    }

}
