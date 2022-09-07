using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestinationProfessor2 : MonoBehaviour
{
    public Transform target;

    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 3f;
    private float aux = 0.8f;

    public GameObject dad;

      void Start()
    {
      _animator = GetComponent<Animator>();
      b = target.position;
    }


    void FixedUpdate()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, speed);
        _animator.SetFloat("Speed", velocity);
        velocity -= aux * Time.deltaTime;
        transform.LookAt(target);

        //abbiamo raggiunto la destinazione
        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
            this.GetComponent<followDestinationProfessor>().enabled = false;
            
        }
    }

}



