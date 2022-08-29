using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CassettieraInteractable : InteractableObject
{
    public GameObject target;
    public GameObject cassettiera;

    private CharacterController _player;
    private PlayerController_Agazio _pController;
    private bool _moving = false;
    private Vector3 _targetDirection;

    public GameObject enemy; 

    public override bool Interact()
    {
        if (interactable)
        {
            interactable = false;
            Debug.Log("Interazione con Cassettiera");

            //Spostare bambina verso la cassettiera
            _pController.DisableJump();
            _pController.DisableInput();
            _pController.DisableBackward();

            _moving = true;
            _pController.IsMoving(true);
            _targetDirection = (target.transform.position - _player.transform.position).normalized;
            _pController.SetTargetDirection(_targetDirection);
            return true;
        }
        return false;
    }

    public void setInteractable(bool isInteractable)
    {
        interactable = isInteractable;
    }

    protected override void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        _pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Agazio>();
    }

    protected override void Update()
    {
        if (_moving)
        {
            //calcolo il vettore distanza tra player e destinazione
            _targetDirection = (target.transform.position - _player.transform.position).normalized;
            _pController.SetTargetDirection(_targetDirection);

            var offset = target.transform.position - _player.transform.position;

            //at destination
            if (offset.magnitude <= .1f)
            {
                _pController.EnableInput();
                _pController.IsMoving(false);
                _moving = false;
                cassettiera.transform.parent = _player.transform;
                _player.GetComponent<PlayerController_Agazio>()._isBehindChest = true;
                enemy.GetComponent<Animator>().SetBool("BehindTheChest", true);
            }
        }
    }
}