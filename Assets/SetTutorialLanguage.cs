using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTutorialLanguage : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    // Start is called before the first frame update
    void Start()
    {
        if(LanguageChangeScript.language == 1){
            text1.text = "premi";
            text2.text = "per muoverti";
        }

    }

}
