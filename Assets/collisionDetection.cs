using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
   
    public bool climbing;

    void Start(){
        climbing = false;
    }


    private void OnTriggerEnter(Collider hit) {    
        Debug.Log(gameObject.name + " just hit " + hit.name); 
        if(hit.name == "PlayerArmature"){
           climbing = true;
        }
    }

}
