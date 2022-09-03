using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invertPosition : MonoBehaviour
{

        public void rotate(){
        
        if(transform.eulerAngles.y >= 0){
            //this.transform.eulerAngles = new Vector3(0f, -90f, 0f);
            transform.Rotate (Vector3.back*6);
            Debug.Log("siamo quii");
        }
        else
            this.transform.eulerAngles = new Vector3(0f, 90f, 0f); 
    }
}
