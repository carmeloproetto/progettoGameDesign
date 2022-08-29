using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteraction : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private Vector3 forceVector; 
    private float forceValue;
    private bool isInteractable = false;
    private AudioSource audioSource;
    public AudioClip clip; 

    public GameObject enemy_1;
    public GameObject enemy_2; 

    private void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        forceVector = this.GetComponent<Transform>().forward;
        forceValue = UnityEngine.Random.Range(50f, 100f);
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInteractable )
        {
            rigidbody.AddForce(forceVector * forceValue);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "floor")
        {
            enemy_1.GetComponent<Animator>().SetBool("plantOnTheFloor", true);
            enemy_2.GetComponent<Animator>().SetBool("plantOnTheFloor", true);
            audioSource.PlayOneShot(clip);
        }
    }

    public void setInteractable(bool value)
    {
        isInteractable = value; 
    }
}
