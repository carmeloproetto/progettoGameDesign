using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetLenguageSkipTutorial : MonoBehaviour
{

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;


    // Start is called before the first frame update
    void Start()
    {
        if(LanguageChangeScript.language == 1){
            text1.text = "premi";
            text2.text = "per saltare la narrazione";
            text3.text = "premi";
            text4.text = "per terminare la frase";
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
