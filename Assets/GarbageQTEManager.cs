using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GarbageQTEManager : MonoBehaviour
{
    private NavMeshAgent _agent;
    public bool qteStart = false;
    public Transform[] garbageItems; 
    public int currItem = 0;
    public bool setDestination = true; 
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if( qteStart )
        {
            if( setDestination && currItem < garbageItems.Length )
            {
                GetComponent<PlayerController>().enabled = false; 
                _agent.SetDestination(garbageItems[currItem].transform.position);
                _agent.speed = 1.5f; 
                _agent.stoppingDistance = 0f;
                _agent.updatePosition = true;
                _agent.updateRotation = true;
                currItem++;
                setDestination = false;
                //start animazione camminata
            }

            if( _agent.remainingDistance <= _agent.stoppingDistance )
            {
                //smetti di camminare
                _agent.speed = 0f;
                _agent.updatePosition = false;
                _agent.updateRotation = false;
                //stop animazione camminata

                //start QTE per item

                    //se QTE success raccogli item
            }
        }
    }
}
