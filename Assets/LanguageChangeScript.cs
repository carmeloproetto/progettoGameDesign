using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageChangeScript : MonoBehaviour
{
    public Text buttonText;
    private bool isEng = true;

    public static int language = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked()
    {
        Debug.Log("BUTTONCLICKED" + isEng);

        if (isEng)
        {
            buttonText.text = "< I T A L I A N O >";
            language = 1;
            isEng = false;
            Debug.Log("italiano selezionato" + language);
        }
        else
        {
            buttonText.text = "< E N G L I S H >";
            language = 0;
            isEng = true;
            Debug.Log("inglese selezionato" + language);
        }
    }
}