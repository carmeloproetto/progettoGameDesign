using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTutorialPanel : MonoBehaviour
{

    public GameObject tutorialPanel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Enter");
            tutorialPanel.SetActive(false);
        }
    }
}
