using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeLanguagePauseMenu : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {

        if(LanguageChangeScript.language == 1){
            newGameBtnText.text = "R I P R E N D I";
            buttonText.text = "< I T A L I A N O >";
            optionsBtnText.text = "I M P O S T A Z I O N I";
            tutorialBtnText.text = "I S T R U Z I O N I";
            quitBtnText.text = "E S C I";

             if (audioOptionText.text == "< O N >")
            {
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
                               "Usa SPAZIO per completare più velocemente le frasi nei dialoghi.\r\n" +
                               "Usa INVIO per rispondere alle domande durante i dialoghi.\r\n" +
                               "Usa E per completare un task speciale.\r\n\n" +
                               "Scopri il tuo impatto!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
