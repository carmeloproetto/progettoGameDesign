using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaggiungiPortaTrigger : MonoBehaviour
{
    public NavMeshAgent _padre;
    public bool _isTriggered = false;
    public bool _isArrived = false;
    public Transform destination;
    public GameObject levelLoader;

    // Update is called once per frame
    void Update()
    {
        if( _isTriggered && (_padre.remainingDistance <= _padre.stoppingDistance) && !_isArrived )
        {
            Debug.Log("Porta d'entrata raggiunta!");
            _isArrived = true;
            _padre.gameObject.GetComponent<Animator>().SetBool("isWalking", false);
            _padre.speed = 0f;
            _padre.updateRotation = false;
            _padre.updatePosition = false; 
            levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PadreController_RetroAzienda>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().enabled = true;
            _padre.gameObject.GetComponent<PadreController_RetroAzienda>().DisableInput();
            _padre.gameObject.GetComponent<PadreController_RetroAzienda>().DisableJump();
            _padre.SetDestination(destination.position);
            _padre.updatePosition = true;
            _padre.updateRotation = true;
            _padre.stoppingDistance = 0.8f;
            _padre.speed = 1.5f;
            _padre.gameObject.GetComponent<Animator>().SetBool("isWalking", true);
            _isTriggered = true;
        }
        
    }
}
