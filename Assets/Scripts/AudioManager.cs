using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    private AudioSource[] allAudioSources;

    void Awake()
    {

        if(instance == null) 
            instance = this;
        else{
            Destroy(gameObject);
            return;
        } 


        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch; 
            s.source.loop = s.loop;
        }
    }

    void Start(){
        //StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("audioIntro", 2f));
        //Play("audioIntro");
    }

    public void Play(string name){
        
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        if(!AudioChangeScript.isOn){
            s.source.volume = 0;
        }
        else{
            s.source.volume = s.volume;
        }


        s.source.Play();
    }

    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }


    public IEnumerator FadeIn(string sound, float duration, float targetVolume){
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            
        }
        else{
            Debug.Log("sound trovato: " + sound);
        
            s.source.Play();
            float currentTime = 0;
            float start = s.source.volume;

            while (currentTime < duration)
            {
                if(!AudioChangeScript.isOn){
                    s.source.volume = 0;
                    yield return null;
                }
                else{
                    //Debug.Log("aumento o diminusico il volume...");
                    currentTime += Time.deltaTime;
                    s.source.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                    yield return null;
                }
            }
        }

    }





    public IEnumerator FadeOut(string sound, float duration, float targetVolume){
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");     
        }
        else{
            Debug.Log("sound trovato: " + sound);
        
        
            float currentTime = 0;
            float start = s.source.volume;

            while (currentTime < duration)
            {   
                if(!AudioChangeScript.isOn){
                    s.source.volume = 0;
                    yield return null;
                }
                else{
                    //Debug.Log("aumento o diminusico il volume...");
                    currentTime += Time.deltaTime;
                    s.source.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                    yield return null;
                }
            }
        }

    }


    /*public void MuteAllSounds(){
       foreach(Sound s in sounds){
            s.source.volume = 0;   
        }
    }*/


}
