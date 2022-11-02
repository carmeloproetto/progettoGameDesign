using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableTutorialPanel : MonoBehaviour
{

    public TutorialUI tutorial_1;
    public TutorialUI tutorial_2; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.name == "PadreBambino" )
        {
            tutorial_1.Off();
            tutorial_2.Off();
        }
    }
}
