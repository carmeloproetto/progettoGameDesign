using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteractable : InteractableObject
{
    public Transform plant; 
    private new Rigidbody rigidbody;
    private Vector3 forceVector;
    private float forceValue;

    //public GameObject tutorial;

    public override bool Interact()
    {
        rigidbody.AddForce(forceVector * forceValue);
        //tutorial.SetActive(false);
        this.GetComponent<BoxCollider>().enabled = false; 
        return true;
    }

    protected override void Start()
    {
        rigidbody = plant.GetComponent<Rigidbody>();
        forceVector = this.GetComponent<Transform>().forward;
        forceValue = Random.Range(50f, 100f);
    }

    protected override void Update()
    {
    }
}
