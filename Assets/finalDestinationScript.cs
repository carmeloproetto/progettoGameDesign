using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalDestinationScript : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider hit) {    
       
        if(hit.name == "PlayerArmature"){
            Debug.Log("fine raggiunta, bisogna caricare la nuova scena"); 
        }
       
    }
}
