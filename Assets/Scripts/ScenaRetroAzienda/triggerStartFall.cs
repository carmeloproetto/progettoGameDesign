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


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Enter");
            pressSpace = true;         }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Exit");
            pressSpace = false;    
        }
    }

}
