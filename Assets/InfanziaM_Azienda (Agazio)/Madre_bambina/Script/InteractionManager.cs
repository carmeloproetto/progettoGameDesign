using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private bool canInteract = false;

    private InteractableObject interactableObject;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;
    public TextMeshProUGUI pressText;
    public Image icon;
    public int languageSetting; //0= Italian, 1= English

    public bool uiEnabledOntriggerStay = false;
    public bool uiDisplayed = true;

    public AudioManager audioMgr;

    private void OnTriggerEnter(Collider other)
    {
        InteractableObject ob = other.gameObject.GetComponent<InteractableObject>(); 
        if(ob != null)
        {
            canInteract = true;
            interactableObject = ob;
            //interactionUI.SetActive(true);

            //audioMgr.Play("ding_ui");
            LeanTween.scale(interactionUI, new Vector3(0.4779364f, 0.4779364f, 0.4779364f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => { uiDisplayed = true; });
            interactionText.text = ob.GetText(languageSetting);
            if( languageSetting == 1 )
            {
                pressText.text = "PREMI";
            }
            else
            {
                pressText.text = "PRESS";
            }
            icon.overrideSprite = ob.getImageIcon();
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if( uiEnabledOntriggerStay && !uiDisplayed)
        {
            //audioMgr.Play("ding_ui");
            LeanTween.scale(interactionUI, new Vector3(0.4779364f, 0.4779364f, 0.4779364f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => { uiDisplayed = true; }); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObject ob = other.gameObject.GetComponent<InteractableObject>();
        if (ob != null)
        {
            canInteract = false;
            interactableObject = null;
            //interactionUI.SetActive(false);
            //audioMgr.Play("ding_ui");
            LeanTween.scale(interactionUI, new Vector3(0f, 0f, 0f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => { uiDisplayed = false; });
        }
    }

    private void Update()
    {
        if( canInteract && Input.GetKeyDown(KeyCode.E) )
        {
            interactableObject.Interact();
            audioMgr.Play("ding_ui");
            LeanTween.scale(interactionUI, new Vector3(0f, 0f, 0f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine).setOnComplete(() => { uiDisplayed = false; });
        }
    }

    private void Start()
    {
        interactionUI.transform.localScale = new Vector3(0f, 0f, 0f);
        languageSetting = LanguageChangeScript.language;
    }
}
