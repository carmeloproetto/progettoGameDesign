using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestination5 : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 3f;

    public GameObject mom;

    public GameObject canvas2;

   

    void Start()
    {
      _animator = GetComponent<Animator>();
      b = target.position;
      
    }

    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0f, -90f, 0f);
       
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, speed);
        _animator.SetFloat("Speed", velocity);

        StartCoroutine(ViewCanvas2());

        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
            mom.SetActive(false);
        }  
            
    }

    IEnumerator ViewCanvas2(){
        yield return new WaitForSeconds(1.5f);
        canvas2.SetActive(true);
    }

    

}
