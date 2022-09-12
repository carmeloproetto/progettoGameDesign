using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

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
        StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("audioIntro", 2f));
        //Play("audioIntro");
    }

    public void Play(string name){
        
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
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


    public IEnumerator FadeOut(string name, float FadeTime) {
		Sound audioSource = Array.Find(sounds, sound => sound.name == name);
        float startVolume = audioSource.volume;
		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
			yield return null;
		}
		Stop(name);
	}

	public IEnumerator FadeIn(string name, float FadeTime) {
			Sound audioSource = Array.Find(sounds, sound => sound.name == name);
            Play(name);
			audioSource.source.volume = 0f;
			while (audioSource.source.volume < 1) {
				audioSource.source.volume += Time.deltaTime / FadeTime;
				yield return null;
		}
	}
    //StartCoroutine(FindObjectOfType<AudioManager>().FadeIn(soudtrackAudioSource, fadeTime));
    //StartCoroutine(FindObjectOfType<AudioManager>().FadeOut(soudtrackAudioSource, fadeTime));


    // Update is called once per frame
    void Update()
    {
        
    }

   // FindObjectOfType<AudioManager>().Play("");
}
