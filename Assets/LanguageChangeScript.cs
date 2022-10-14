using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LanguageChangeScript : MonoBehaviour
{
    public Text buttonText;

    public Text newGameBtnText;
    public Text optionsBtnText;
    public Text tutorialBtnText;
    public Text quitBtnText;

    public Text audioOptionText;
    public Text langLabelText;
    public Text backBtnText;
    public Text backBtn2Text;
    public Text tutorialText;

    public bool isEng = true;

    public static int language = 1;

    private Scene thisScene;

    // Start is called before the first frame update
    void Start()
    {
        thisScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked()
    {
        thisScene = SceneManager.GetActiveScene();

        Debug.Log("SCENE " + thisScene.name);
        Debug.Log("OBJECT " + this.name);

        if (isEng)
        {
            if(thisScene.name == "Menu")
            {
                newGameBtnText.text = "I N I Z I A";
            }
            else if(this.name == "PauseMenuCanvas")
            {
                newGameBtnText.text = "R I P R E N D I";
            }
            //comuni
            buttonText.text = "< I T A L I A N O >";
            optionsBtnText.text = "I M P O S T A Z I O N I";
            tutorialBtnText.text = "I S T R U Z I O N I";
            quitBtnText.text = "E S C I";

            if (audioOptionText.text == "< O N >")
            {
                Debug.Log("HERE");


                audioOptionText.text = "< S I >";
            }
            else
            {
                audioOptionText.text = "< N O >";
            }

            langLabelText.text = "L I N G U A";
            backBtnText.text = "I N D I E T R O";
            backBtn2Text.text = "I N D I E T R O";

            tutorialText.text = "Sei pronto per fare la differenza? \r\n" +
                               "Usa A+D per muovere il tuo personaggio a sinistra e destra.\r\n" +
                               "Usa SPAZIO per completare pi� velocemente le frasi nei dialoghi.\r\n" +
                               "Usa INVIO per rispondere alle domande durante i dialoghi.\r\n" +
                               "Usa E per completare un task speciale.\r\n\n" +
                               "Scopri il tuo impatto!";

            language = 1;
            isEng = false;
            Debug.Log("italiano selezionato" + language);
        }
        else
        {
            if (thisScene.name == "Menu")
            {
                newGameBtnText.text = "N E W  G A M E";
            }
            else if (this.name == "PauseMenuCanvas")
            {
                newGameBtnText.text = "R E S U M E ";
            }
            //comuni
            buttonText.text = "< E N G L I S H >";
            optionsBtnText.text = "O P T I O N S";
            tutorialBtnText.text = "T U T O R I A L";
            quitBtnText.text = "Q U I T";

            if (audioOptionText.text == "< S I >")
            {
                audioOptionText.text = "< O N >";
            }
            else
            {
                audioOptionText.text = "< O F F >";
            }

            langLabelText.text = "L A N G U A G E";
            backBtnText.text = "B A C K";
            backBtn2Text.text = "B A C K";
            tutorialText.text = "Are you ready to make a difference? \r\n" +
                                "Use A+D to move the character on the left or on the right.\r\n" +
                                "Use SPACE to complete faster the sentence during a dialogue.\r\n" +
                                "Use ENTER to answer questions during dialogues.\r\n" +
                                "Use E to complete a special task.\r\n\n" +
                                "Discover your impact!";


            language = 0;
            isEng = true;
            Debug.Log("inglese selezionato" + language);
        }
    }
}
