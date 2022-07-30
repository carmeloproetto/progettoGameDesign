using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower3 : MonoBehaviour
{

    public Transform target;
    public float speed;
   
    public GameObject ps;
    private collisionDetection cd;

    void Start(){
        cd = ps.GetComponent<collisionDetection>();
    }


    void FixedUpdate(){

        if(cd.climbing == true){
            Vector3 a = transform.position;
            Vector3 b = target.position;
            //transform.LookAt(target);
            transform.position = Vector3.MoveTowards(a, b, speed);
            GetComponent<CharacterController>().enabled = false;

            /*if(transform.position.x == target.position.x && transform.position.z == target.position.z){
                // transform.LookAt(barrel);
                // transform.eulerAngles = new Vector3(0f, -109f, 0f);
                GetComponent<TargetFollower3>().enabled = false;
                
            }*/
        }
    }
}

