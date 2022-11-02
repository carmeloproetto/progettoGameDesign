using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestinationRagazzinoIniziale : MonoBehaviour
{

     public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 3f;
    

    public Transform dad;

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
        transform.LookAt(target);
        //dlgMng.GetComponent<DialogueManagerCap3_1>().disableSpace = true; 
        //ragazzo.GetComponent<Animator>().SetFloat("Speed", 2f);

        //abbiamo raggiunto la destinazione
        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
            Debug.Log("Destinazione raggiunta!");
            transform.LookAt(dad);
            dad.LookAt(this.transform);
            _animator.SetFloat("Speed", 0);
            this.GetComponent<followDestinationRagazzinoIniziale>().enabled = false;

        }
    }
}
