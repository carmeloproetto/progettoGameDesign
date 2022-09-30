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

    // Start is called before the first frame update
    void Start()
    {
    }

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
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Player")
        {
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
