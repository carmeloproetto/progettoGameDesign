using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshCharacter : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public GameObject destination;

    public GameObject obj;
    private triggerFall script;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        script = obj.GetComponent<triggerFall>();
    }

    // Update is called once per frame
    void Update()
    {
            
        if(script.startAnimation == true){    
            navMeshAgent.SetDestination(destination.transform.position);
        }

    }
}
