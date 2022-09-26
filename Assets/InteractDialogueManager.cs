using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogueManager : MonoBehaviour
{
    public Transform dialoguePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disableDialoguePanel()
    {
        dialoguePanel.gameObject.SetActive(false); 
    }

    public void enableDialoguePanel()
    {
        dialoguePanel.gameObject.SetActive(true);
    }
}
