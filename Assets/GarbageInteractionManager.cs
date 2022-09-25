using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageInteractionManager : MonoBehaviour
{
    public Transform scatola;
    public Transform bidone;
    public Transform forceDirectionBidone;
    public Transform forceDirectionScatola;
    public float forceScatola;
    public float forceBidone;

    public bool spingi = false;
    private bool interacted = false; 

    public void spingiBidone()
    {
        bidone.GetComponent<Rigidbody>().AddForceAtPosition( forceDirectionBidone.forward * forceBidone, forceDirectionBidone.transform.position );
        scatola.GetComponent<Rigidbody>().AddForceAtPosition(forceDirectionScatola.forward * forceScatola, forceDirectionScatola.transform.position);
    }

    private void Update()
    {
        if( spingi && !interacted)
        {
            spingiBidone();
            interacted = true;
        }
    }

}
