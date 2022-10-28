using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PushingUIManager : MonoBehaviour
{
    public GameObject interationUI; 
    public TextMeshProUGUI pressText;
    public TextMeshProUGUI interactionText;
    public int languageSetting;
    public AudioManager audioManager; 

    // Start is called before the first frame update
    void Start()
    {
        languageSetting = LanguageChangeScript.language;
        if( languageSetting == 0 )
        {
            pressText.text = "PRESS";
            interactionText.text = "TO PUSH THE BARREL";
        }
        else
        {
            pressText.text = "PREMI";
            interactionText.text = "PER SPINGERE IL BARILE";
        }
        
    }

    public void UiOn()
    {
        //audioManager.Play("ding_ui");
        LeanTween.scale(interationUI, new Vector3(0.4779364f, 0.4779364f, 0.4779364f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine);
    }

    public void UiOff()
    {
        //audioManager.Play("ding_ui");
        LeanTween.scale(interationUI, new Vector3(0, 0, 0), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine);
    }

    
}
