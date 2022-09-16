using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BariliTrigger : InteractableObject
{
    private PadreController_RetroAzienda _pController;
    public PathCreator pathCreator;

    private bool canMove = false;
    private float _speed = 2f;
    private float distanceTraveled = 0f;
    private Vector3 _finalPoint;
    private Vector3 _startPoint; 

    public override bool Interact()
    {
        //blocco movimento del player 
        _pController.DisableInput();
        _pController.DisableJump();

        //pathCreator.bezierPath.SetPoint(0, _pController.transform.position);
        //_pController.transform.position.Set(_startPoint.x, _startPoint.y, _startPoint.z);
        canMove = true;

        _pController.IsMoving(true);


        Debug.Log("Interazione barili");
        return true; 
    }

    protected override void Start()
    {
        _pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PadreController_RetroAzienda>();
        _finalPoint = pathCreator.path.GetPoint(3);
        _startPoint = pathCreator.path.GetPoint(1);
    }

    protected override void Update()
    {
        if( canMove )
        {
            distanceTraveled += _speed * Time.deltaTime;
            float newX = pathCreator.path.GetPointAtDistance(distanceTraveled).x;
            float newZ = pathCreator.path.GetPointAtDistance(distanceTraveled).z;
            _pController.SetTargetDirection(new Vector3(newX, 0f, newZ));

            if( _pController.transform.position == _finalPoint )
            {
                canMove = false;
                _pController.IsMoving(false);
            }
        }
    }
}
