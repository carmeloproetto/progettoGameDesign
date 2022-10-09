using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class TimelineSignalReceiver : MonoBehaviour
{
    public Transform gabbia;
    private bool startTransition = false;
    public Rig rig; 

    public void Free()
    {
        gabbia.transform.parent = null;
        gabbia.GetComponentInChildren<Rigidbody>().isKinematic = false;
        startTransition = true; 
        Debug.Log("Gabbia Liberata");
    }

    public void Update()
    {
        if( startTransition && rig.weight > 0f )
        {
            rig.weight -= Time.deltaTime * 0.5f; 
        }
    }
}
