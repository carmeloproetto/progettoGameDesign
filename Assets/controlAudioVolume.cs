using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlAudioVolume : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
       /* if(!AudioChangeScript.isOn){
            allAudioSources = FindObjectsOfType<AudioSource>();
            foreach (AudioSource audioSource in allAudioSources)
            {
                audioSource.volume = 0;
            }

        }*/

    }
}
