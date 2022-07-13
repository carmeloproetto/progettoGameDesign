using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerStartFall : MonoBehaviour
{
    public bool pressSpace;

    // Start is called before the first frame update
    void Start()
    {
       pressSpace = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision other){
        pressSpace = true;
    }
}
