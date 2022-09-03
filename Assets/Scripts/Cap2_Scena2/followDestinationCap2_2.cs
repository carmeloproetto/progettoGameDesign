using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestinationCap2_2 : MonoBehaviour
{

    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;
    private float velocity = 4f;
    private float aux = 0.8f;

    public GameObject guardia;
    public Transform manifestane;
    public GameObject wallSx;

    // Start is called before the first frame update
    void Start()
    {
      _animator = GetComponent<Animator>();
      b = target.position;
     // this.transform.eulerAngles = new Vector3(0f, -130f, 0f);
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
           // transform.LookAt(barrel);
            _animator.SetFloat("Speed", 0f);
            this.GetComponent<followDestinationCap2_2>().enabled = false;
            if(this.name == "Manifestante01")
                guardia.GetComponent<followDestinationCap2_2>().enabled = true;
            
            if(this.name == "Guardia"){
                Debug.Log("perchè non ruoti?");
                transform.LookAt(manifestane);
                _animator.SetBool("No", true);
                wallSx.SetActive(false);
            }
        }
    }
}
