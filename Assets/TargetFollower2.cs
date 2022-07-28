using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower2 : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Transform target2;

    private Animator _animator;
    
    Vector3 b;

    void Start(){
      _animator = GetComponent<Animator>();
      b = target.position;
    }

    void FixedUpdate(){
        Vector3 a = transform.position;
        
        //transform.LookAt(target);
        

        transform.position = Vector3.MoveTowards(a, b, speed);
        


        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
           // transform.LookAt(barrel);
            transform.eulerAngles = new Vector3(0f, -109f, 0f);
            //GetComponent<TargetFollower2>().enabled = false;
             b = target2.position;
        }

        if(transform.position.x == target2.position.x && transform.position.z == target2.position.z){
            transform.eulerAngles = new Vector3(0f, -190f, 0f);
            _animator.SetBool("kPress", false);
            GetComponent<TargetFollower2>().enabled = false;
        }
    }

}
