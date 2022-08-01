using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TargetFollower3 : MonoBehaviour
{

    public Transform target;
    public float speed;
    //serve per sbloccare il movimento sull'asse x e z nel file thirdPersonContoller
    public bool controlPosition1;
   
    public GameObject ps;
    private collisionDetection cd;

    public GameObject colliderJump;

    void Start(){
        cd = ps.GetComponent<collisionDetection>();
        controlPosition1 = true;
    }


    void FixedUpdate(){

        if(cd.climbing == true){
            controlPosition1 = false;
            Vector3 a = transform.position;
            Vector3 b = target.position;
            //transform.LookAt(target);
            //GetComponent<ThirdPersonController>().enabled = false;
            transform.position = Vector3.MoveTowards(a, b, speed);
            GetComponent<Animator>().SetBool("Climbing", true);
            GetComponent<CharacterController>().enabled = false;


            if(transform.position.x == target.position.x && transform.position.z == target.position.z){
                // transform.LookAt(barrel);
                //transform.eulerAngles = new Vector3(0f, 0f, 0f);
                //GetComponent<ThirdPersonController>().enabled = true;
                GetComponent<Animator>().SetBool("Climbing", false);
                GetComponent<CharacterController>().enabled = true;
                GetComponent<TargetFollower3>().enabled = false;
                colliderJump.SetActive(false);
                cd.climbing = false;

            }
        }
    }
}

