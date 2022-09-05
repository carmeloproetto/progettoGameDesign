using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestinationCap2_3 : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 4f;
    private float aux = 0.8f;

    public GameObject dad;
    public Vector3 curTarDirection;

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
        transform.LookAt(dad.transform);

        //abbiamo raggiunto la destinazione
        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
            dad.GetComponent<Animator>().SetBool("StopTexting", false);
            //dad.transform.LookAt(this.transform);

            Quaternion targetRotation = Quaternion.LookRotation(curTarDirection, Vector3.up);
            dad.transform.rotation = Quaternion.Slerp(dad.transform.rotation, targetRotation, 0.1f);
            _animator.SetFloat("Speed", 0f);
            this.GetComponent<DialogueTriggerCap2_3>().startConvByOtherScript();
        }
    }
}

