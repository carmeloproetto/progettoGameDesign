using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class FootStepSoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;

    [SerializeField] AudioClip landSound; 

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    private void OnFootstep()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private void OnLand()
    {
        audioSource.PlayOneShot(landSound);
    }

    private AudioClip GetRandomClip()
    {
        AudioClip clip = audioClips[Random.Range(0, audioClips.Length - 1)];
        return clip; 
    }
}
