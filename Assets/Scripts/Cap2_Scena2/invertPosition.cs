using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invertPosition : MonoBehaviour
{

    private bool rotateEnabled;
    private int x;
    public GameObject icon;
    
    public void Start(){
          rotateEnabled = false;
          x = 90;
         
    }

    public void Update(){
        if(rotateEnabled == true){
           
            icon.transform.parent = null;
            this.transform.eulerAngles = new Vector3(0f, x, 0f);
            icon.transform.parent = this.transform;
            rotateEnabled = false;
        }
    }



    public void rotate(){ 
        rotateEnabled = true;
        x = -x;
    }
    

}
