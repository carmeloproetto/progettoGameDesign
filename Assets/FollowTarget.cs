using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator; 
    private bool _targetSetted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<NavMeshAgent>();
        this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( _targetSetted && _agent.remainingDistance <= _agent.stoppingDistance)
        {
            _animator.SetFloat("Speed", 0f);
            _agent.speed = 0f;
            _agent.updateRotation = false;
            _agent.enabled = false;
            _targetSetted = false; 
        }
    }

    public void SetDestination(Vector3 target, float stoppingDistance)
    {
        _animator.SetFloat("Speed", 2f); 
        _targetSetted = true; 
        _agent.enabled = true;
        _agent.speed = 1.5f;
        _agent.updatePosition = true;
        _agent.updateRotation = true;
        _agent.stoppingDistance = stoppingDistance;
        _agent.SetDestination(target);
    }
}
