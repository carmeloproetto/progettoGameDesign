using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour
{
    public Text buttonText;

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
        Debug.Log("BUTTONCLICKED" + isOn);

        if (isOn)
        {
            buttonText.text = "< O F F >";

            isOn = false;
            audioSource.mute = true;
        }
        else
        {
            buttonText.text = "< O N >";

            isOn = true;
            audioSource.mute = false;
        }
    }
}
