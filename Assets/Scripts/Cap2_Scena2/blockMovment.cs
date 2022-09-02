using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class blockMovment : MonoBehaviour
{


     public GameObject mom;
    // Update is called once per frame
    void Update()
    {   
       if(mom.transform.position.x <= -109.965f){
            mom.GetComponent<Animator>().SetFloat("Speed", 0f); 
       }
    }
}
