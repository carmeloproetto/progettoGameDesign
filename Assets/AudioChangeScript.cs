using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChangeScript : MonoBehaviour
{
    public Text buttonText;
    [SerializeField] LanguageChangeScript langChange;

    private bool isOn = true;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked()
    {
        if (isOn)
        {
            if(langChange.isEng)
            {
                buttonText.text = "< O F F >";
            }
            else
            {
                buttonText.text = "< N O >";
            }
           

            isOn = false;
            audioSource.mute = true;
        }
        else
        {

            if (langChange.isEng)
            {
                buttonText.text = "< O N >";
            }
            else
            {
                buttonText.text = "< S I >";
            }

            isOn = true;
            audioSource.mute = false;
        }
    }
}
