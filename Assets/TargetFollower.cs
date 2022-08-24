using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


public class TargetFollower : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Transform barrel;

    private Animator _animator;

    public GameObject barrel4;
    private Animator barrelAnimator;



    void Start(){
        _animator = GetComponent<Animator>();
        barrelAnimator = barrel4.GetComponent<Animator>();
    }

    void FixedUpdate(){
        Vector3 a = transform.position;
        Vector3 b = target.position;
        //transform.LookAt(target);
        //GetComponent<ThirdPersonController>().enabled = false;
        transform.position = Vector3.MoveTowards(a, b, speed);
        _animator.SetBool("Destination", true);


        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
           // transform.LookAt(barrel);
            transform.eulerAngles = new Vector3(0f, -109f, 0f);
            _animator.SetBool("Destination", false);
            _animator.SetBool("kPress", true);
          //  GetComponent<ThirdPersonController>().enabled = true;
            GetComponent<TargetFollower>().enabled = false;
            
        }
    }


    //trigger caduta barile a metà spinta
    void triggerFallBarrel(){
         Debug.Log("caduta barile");
         barrelAnimator.Play("CadutaBarile");
         //barrelAnimator.enabled = false;
    }   

}