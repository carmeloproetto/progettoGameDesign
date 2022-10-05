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
    public Image icon;

    private void OnTriggerEnter(Collider other)
    {
        InteractableObject ob = other.gameObject.GetComponent<InteractableObject>(); 
        if(ob != null)
        {
            canInteract = true;
            interactableObject = ob;
            //interactionUI.SetActive(true);
            LeanTween.scale(interactionUI, new Vector3(0.4779364f, 0.4779364f, 0.4779364f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine);
            interactionText.text = ob.getText();
            icon.overrideSprite = ob.getImageIcon();
            
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
            LeanTween.scale(interactionUI, new Vector3(0f, 0f, 0f), 0.5f).setDelay(.1f).setEase(LeanTweenType.easeInOutSine);
        }
    }

    private void Update()
    {
        if( canInteract && Input.GetKeyDown(KeyCode.E) )
        {
            interactableObject.Interact();
            //interactionUI.SetActive(false);
            LeanTween.scale(interactionUI, new Vector3(0f, 0f, 0f), 0.5f).setDelay(.3f).setEase(LeanTweenType.easeInOutSine);
        }
    }

    private void Start()
    {
        interactionUI.transform.localScale = new Vector3(0f, 0f, 0f);
    }
}
