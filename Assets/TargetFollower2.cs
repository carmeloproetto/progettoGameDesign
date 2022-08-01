using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


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
        
      //  GetComponent<ThirdPersonController>().enabled = false;
        transform.position = Vector3.MoveTowards(a, b, speed);
        _animator.SetBool("Destination", true);
        _animator.SetBool("kPress", false);
        


        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
           // transform.LookAt(barrel);
            transform.eulerAngles = new Vector3(0f, -109f, 0f);
            //GetComponent<TargetFollower2>().enabled = false;
             b = target2.position;
        }

        if(transform.position.x == target2.position.x && transform.position.z == target2.position.z){
           // GetComponent<ThirdPersonController>().enabled = true;
            transform.eulerAngles = new Vector3(0f, -190f, 0f);
            _animator.SetBool("Destination", false);
            
            GetComponent<TargetFollower2>().enabled = false;
        }
    }

}
