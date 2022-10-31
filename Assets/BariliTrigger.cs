using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;
using UnityEngine.AI;
using DG.Tweening;

public class BariliTrigger : InteractableObject
{
    private PadreController_RetroAzienda _pController;
    private NavMeshAgent _agent;
    private Animator _animator; 
    public GameObject destination;
    public GameObject barili;
    public ManagerGUI_QTE GUIManager; 
    private bool _interacted = false;
    private bool _arrived = false;

    public override bool Interact()
    {
        //blocco movimento del player 
        _pController.enabled = false;
        if( !_interacted )
        {
            _animator.SetTrigger("raggiungiBarile_1");
        }
        
        _agent.SetDestination(destination.transform.position);
        _agent.updateRotation = true;
        _interacted = true;
        this.interactable = false;
        return true; 
    }

    protected override void Start()
    {
        _pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PadreController_RetroAzienda>();
        _agent = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        _animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    protected override void Update()
    {
        if (_agent.enabled && _interacted && _agent.remainingDistance <= 0.1f && !_arrived )
        {
            _arrived = true; 
            _agent.transform.DORotate(new Vector3(0f, 270f, 0f), 2f);
            _animator.SetBool("isPushing", true);
            GUIManager.EaseInButton();
        }
       
    }
}
