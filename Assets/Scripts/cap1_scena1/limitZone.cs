using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitZone : MonoBehaviour
{

       public GameObject dad;
    // Update is called once per frame
    void Update()
    {   
       if(dad.transform.position.x >= 109.29f || dad.transform.position.x <= -85.13f){
            Debug.Log("non puoi andare avanti");
            dad.GetComponent<Animator>().SetFloat("Speed", 0f); 
       }
    }
    
}

