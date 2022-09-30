using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;

public class DestinationTrigger : MonoBehaviour
{
    public Transform player;
    public Rig rig;
    private bool enableTransition = false;
    public float transitionSpeed = 1f;
    public Transform barile;
    public Transform destinazionePorta;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<Animator>().SetBool("isPushing", false);
            enableTransition = true;

            player.GetComponent<PadreController_RetroAzienda>().EnableJump();
            player.GetComponent<PadreController_RetroAzienda>().EnableBackward();
            player.GetComponent<PadreController_RetroAzienda>().maxVelocity = 2f;

            barile.parent = null;
            barile.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<NavMeshAgent>().speed = 0f;
            //player.GetComponent<NavMeshAgent>().updatePosition = false;
            //player.GetComponent<NavMeshAgent>().updateRotation = false; 
            player.GetComponent<NavMeshAgent>().SetDestination(destinazionePorta.position);
        }
        
    }

    public void Update()
    {
        if (enableTransition)
        {
            if (rig.weight > 0f)
                rig.weight -= transitionSpeed * Time.deltaTime;
            else if( rig.weight <= 0f)
            {
                enableTransition = false; 
            }
        }
    }
}

