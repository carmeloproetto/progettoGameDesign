using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeLanguageUi : MonoBehaviour
{
    public string englishText;
    public string italianText;

    // Start is called before the first frame update
    void Start()
    {
        if( LanguageChangeScript.language == 0)
        {
            this.GetComponent<TextMeshProUGUI>().text = englishText; 
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = italianText;
        }
    }
}
