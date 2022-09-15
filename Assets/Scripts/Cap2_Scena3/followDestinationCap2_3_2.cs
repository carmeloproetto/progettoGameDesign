using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class followDestinationCap2_3_2 : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 5f;
    private float aux = 0.8f;

    public GameObject dad;
    public Vector3 curTarDirection;

    public bool followDestinationEnabled;

     void Start()
    {
      _animator = GetComponent<Animator>();
      b = target.position;
      followDestinationEnabled = false;
    }


    void FixedUpdate()
    {

        if(followDestinationEnabled){
            this.GetComponent<followDestinationCap2_3>().enabled = false;
        
            Vector3 a = transform.position;
            transform.position = Vector3.MoveTowards(a, b, speed);
            _animator.SetFloat("Speed", velocity);
            velocity -= aux * Time.deltaTime;
            transform.LookAt(target);

            //abbiamo raggiunto la destinazione
            if(transform.position.x == target.position.x && transform.position.z == target.position.z){
                DialogueManagerCap2_3.finale = 3;
                SceneManager.LoadScene("Cap2_fine");
            }
        }
    }

    void startFollowDestination(){
        followDestinationEnabled = true;      
    }
}