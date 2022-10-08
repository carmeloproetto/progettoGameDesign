using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteraction : MonoBehaviour
{
    //private new Rigidbody rigidbody;
    //private Vector3 forceVector; 
    //private float forceValue;
    //private bool isInteractable = false;
    private AudioSource audioSource;
    public AudioClip clip; 

    public GameObject enemy_1;
    public GameObject enemy_2; 

    //public bool interact;
    public bool aux;

    public GameObject dlgMng;
    public GameObject canvas;
    //public GameObject tutorial;
    public GameObject employee2;


    private void Start()
    {
        /*rigidbody = this.GetComponent<Rigidbody>();
        forceVector = this.GetComponent<Transform>().forward;
        forceValue = UnityEngine.Random.Range(50f, 100f);*/
        audioSource = GetComponent<AudioSource>(); 
        //interact = false;
        aux = false;
    }

    // Update is called once per frame
    /*void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInteractable && interact)
        {
            rigidbody.AddForce(forceVector * forceValue);
            tutorial.SetActive(false);
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "floor")
        {
            enemy_1.GetComponent<Animator>().SetBool("plantOnTheFloor", true);
            enemy_2.GetComponent<Animator>().SetBool("plantOnTheFloor", true);
            audioSource.PlayOneShot(clip);
            if(!aux)
                StartCoroutine(Continue());
        }
    }

    IEnumerator Continue(){   
        aux = true;
        yield return new WaitForSeconds(1);
        canvas.SetActive(true);
        dlgMng.GetComponent<DialogueManagerAzienda>().ContinueStoryByOtherScript();
        yield return new WaitForSeconds(3);
        dlgMng.GetComponent<DialogueManagerAzienda>().ContinueStoryByOtherScript();
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);
        employee2.GetComponent<DialogueTriggerAzienda>().closeConv();

    }


    /*public void setInteractable(bool value)
    {
        isInteractable = value; 
    }*/
}
