using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class blockMovment : MonoBehaviour
{

     void Start(){
          FindObjectOfType<AudioManager>().Play("birdsAudio");
     }

     public GameObject mom;
    // Update is called once per frame
    void Update()
    {   
       if(mom.transform.position.x <= -109.965f || mom.transform.position.x > -85.949566){
            mom.GetComponent<Animator>().SetFloat("Speed", 0f); 
       }
     
    }
}
