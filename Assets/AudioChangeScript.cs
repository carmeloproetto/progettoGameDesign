using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChangeScript : MonoBehaviour
{
    public Text buttonText;
    [SerializeField] LanguageChangeScript langChange;

    public  bool isOn = true;

    private AudioSource[] allAudioSources;



    // Start is called before the first frame update
    void Start()
    {
        Awake();

        if (PlayerPrefs.GetString("audio") == "yes")
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
            //StartAllAudio();

        }
        else
        {
            if (langChange.isEng)
            {
                buttonText.text = "< O F F >";
            }
            else
            {
                buttonText.text = "< N O >";
            }

            isOn = false;
            //StopAllAudio();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClicked()
    {
        Awake();

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
            //StopAllAudio();

            PlayerPrefs.SetString("audio", "no");
            PlayerPrefs.Save();

            AudioListener.volume = 0;

            /*allAudioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.volume = 0;
            }*/
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
            //StartAllAudio();

            PlayerPrefs.SetString("audio", "yes");
            PlayerPrefs.Save();

            AudioListener.volume = 1;

            /*allAudioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.volume = 1;
            }*/
        }
    }

    public void Awake()
    {
        //allAudioSources = FindObjectsOfType(AudioSource) as AudioSource[];
        //allAudioSources = FindObjectsOfType<AudioSource>();

        Debug.Log("AUDIO SOURCES" + allAudioSources);
        
    }

    
}
