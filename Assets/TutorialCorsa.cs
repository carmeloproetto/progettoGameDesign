using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCorsa : MonoBehaviour
{
    public DialogueManagerCap3_2 dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager (1)").GetComponent< DialogueManagerCap3_2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            dialogueManager.startCorsa = true;
    }
}
