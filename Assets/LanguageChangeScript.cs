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

    public static int language = 0;

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
            if(thisScene.name == "Menu_scene")
            {
                newGameBtnText.text = "INIZIA";
            }
            else if(this.name == "PauseMenuCanvas")
            {
                newGameBtnText.text = "RIPRENDI";
            }
            //comuni
            buttonText.text = "< ITALIANO >";
            optionsBtnText.text = "IMPOSTAZIONI";
            tutorialBtnText.text = "ISTRUZIONI";
            quitBtnText.text = "ESCI";

            if (audioOptionText.text == "< ON >")
            {
                Debug.Log("HERE");


                audioOptionText.text = "< SI >";
            }
            else
            {
                audioOptionText.text = "< NO >";
            }

            langLabelText.text = "LINGUA";
            backBtnText.text = "INDIETRO";
            backBtn2Text.text = "INDIETRO";

            tutorialText.text = "Sei pronto per fare la differenza? \r\n" +
                               "Usa A+D per muovere il tuo personaggio a sinistra e destra.\r\n" +
                               "Usa SPAZIO per completare più velocemente le frasi nei dialoghi.\r\n" +
                               "Usa INVIO per rispondere alle domande durante i dialoghi.\r\n" +
                               "Usa E per completare un task speciale.\r\n" +
                               "Usa ESC per aprire il menu di pausa.\r\n" + 
                               "Usa R per ricaricare la scena corrente.\r\n\n" +
                               "Scopri il tuo impatto!";

            language = 1;
            isEng = false;
            Debug.Log("italiano selezionato" + language);
        }
        else
        {
            if (thisScene.name == "Menu_scene")
            {
                newGameBtnText.text = "NEW  GAME";
            }
            else if (this.name == "PauseMenuCanvas")
            {
                newGameBtnText.text = "RESUME ";
            }
            //comuni
            buttonText.text = "< ENGLISH >";
            optionsBtnText.text = "OPTIONS";
            tutorialBtnText.text = "TUTORIAL";
            quitBtnText.text = "QUIT";

            if (audioOptionText.text == "< SI >")
            {
                audioOptionText.text = "< ON >";
            }
            else
            {
                audioOptionText.text = "< OFF >";
            }

            langLabelText.text = "LANGUAGE";
            backBtnText.text = "BACK";
            backBtn2Text.text = "BACK";
            tutorialText.text = "Are you ready to make a difference? \r\n" +
                                "Use A+D to move the character on the left or on the right.\r\n" +
                                "Use SPACE to complete faster the sentence during a dialogue.\r\n" +
                                "Use ENTER to answer questions during dialogues.\r\n" +
                                "Use E to complete a special task.\r\n" +
                                "Use ESC to open the pause menu.\r\n" +
                                "Use R to reload the current scene.\r\n\n" +
                                "Discover your impact!";


            language = 0;
            isEng = true;
            Debug.Log("inglese selezionato" + language);
        }
    }
}
