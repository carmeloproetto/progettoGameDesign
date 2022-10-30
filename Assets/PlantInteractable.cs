using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInteractable : InteractableObject
{
    public Animator dipendente_1;
    public Animator dipendente_2;
    public Transform plant; 
    private new Rigidbody rigidbody;
    private Vector3 forceVector;
    private float forceValue;

    //public GameObject tutorial;

    public override bool Interact()
    {
        if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("isDying") &&
            (!dipendente_1.GetBool("isChasing") && !dipendente_1.GetBool("isAtDestination")) && (!dipendente_2.GetBool("isChasing") && !dipendente_2.GetBool("isAtDestination")))
        {
            rigidbody.AddForce(forceVector * forceValue);
            //tutorial.SetActive(false);

            this.interactable = false; 
            this.GetComponent<BoxCollider>().enabled = false;
            dipendente_1.GetComponent<FieldOfView>().DisableFOV();
            dipendente_2.GetComponent<FieldOfView>().DisableFOV();
            return true;
        }
        return false;
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
