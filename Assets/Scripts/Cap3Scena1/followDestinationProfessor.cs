using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestinationProfessor : MonoBehaviour
{


    public Transform target;

    public float speed;

    public Animator _animator;

    Vector3 b;

    private float velocity = 3f;
    private float aux = 0.8f;

    public GameObject dad;



      void Start()
    {
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
              dad.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
              dad.GetComponent<Animator>().SetBool("Talk", true);
              //dad.transform.LookAt(this.transform);
              dad.transform.eulerAngles = new Vector3(0f, 85.861f, 0f);
              _animator.SetBool("Talk", true);
              this.GetComponent<followDestinationProfessor>().enabled = false;
        }
    }

}
