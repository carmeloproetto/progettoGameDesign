using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageInteractionManager : MonoBehaviour
{
    public Transform scatola;
    public Transform bidone;
    public Transform forceDirectionBidone;
    public Transform forceDirectionScatola;
    public ParticleSystem pSystem;
    public float forceScatola;
    public float forceBidone;
    public AudioManager audioMgr; 

    //public bool spingi = false;
    //private bool interacted = false; 

    public void SpingiBidone()
    {
        audioMgr.Play("caduta_bidone");
        pSystem.gameObject.SetActive(true);
        pSystem.Play();
        bidone.GetComponent<Rigidbody>().AddForceAtPosition(forceDirectionBidone.forward * forceBidone, forceDirectionBidone.transform.position);
        scatola.GetComponent<Rigidbody>().AddForceAtPosition(forceDirectionScatola.forward * forceScatola, forceDirectionScatola.transform.position);
    }

}
