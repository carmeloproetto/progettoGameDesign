using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarileTrigger : InteractableObject
{
    public GameObject rightArmPin;
    public GameObject leftArmPin;
    private Transform _player;
    public GameObject rightArmIK;
    public GameObject leftArmIK;
    public GameObject barile; 

    public override bool Interact()
    {
        rightArmIK.transform.position = rightArmPin.transform.position;
        //rightArmIK.transform.parent = rightArmPin.transform;

        leftArmIK.transform.position = leftArmPin.transform.position;
        //leftArmIK.transform.parent = leftArmPin.transform;

        barile.transform.parent = _player;
        return true; 
    }

    protected override void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void Update()
    {
        
    }
}
