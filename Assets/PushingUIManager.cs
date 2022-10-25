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
    public bool isEnglish = true;

    // Start is called before the first frame update
    void Start()
    {
        if( isEnglish)
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
        LeanTween.scale(interationUI, new Vector3(0.4779364f, 0.4779364f, 0.4779364f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine);
    }

    public void UiOff()
    {
        LeanTween.scale(interationUI, new Vector3(0, 0, 0), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine);
    }

    
}
