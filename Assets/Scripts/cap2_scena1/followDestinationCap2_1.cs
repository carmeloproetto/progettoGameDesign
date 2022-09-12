using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestinationCap2_1 : MonoBehaviour
{

    public Transform target;
    public Transform target2;

    public float speed;

    private Animator _animator;

    Vector3 b;

    Vector3 b2;

    private float velocity = 1.6f;

    public Camera cam;

    public GameObject sindaco;

    public GameObject canvas2;

    private bool momMovment;



    // Start is called before the first frame update
    void Start()
    {
      cam.GetComponent<CameraFollow>().enabled = true;
      _animator = GetComponent<Animator>();
      _animator.SetBool("Angry", false);
      b = target.position;
      b2 = target2.position;
      momMovment = false;
      
     
    }

    void FixedUpdate()
    {

        sindaco.transform.eulerAngles = new Vector3(0f, 135f, 0f);
        Vector3 a2 = sindaco.transform.position;
        sindaco.transform.position = Vector3.MoveTowards(a2, b2, 0.05f);
        sindaco.GetComponent<Animator>().SetBool("Talk", false);
        sindaco.GetComponent<Animator>().SetFloat("Speed", 2.0f);

        if(sindaco.transform.position.x == target2.position.x && sindaco.transform.position.z == target2.position.z){
            sindaco.SetActive(false);
            momMovment = true;
        }

        if(momMovment == true){
            transform.eulerAngles = new Vector3(0f, -90f, 0f);
            Vector3 a = transform.position;
            transform.position = Vector3.MoveTowards(a, b, speed);
            _animator.SetFloat("Speed", velocity);


            if(transform.position.x == target.position.x && transform.position.z == target.position.z){
                _animator.SetFloat("Speed", 0f);
                _animator.SetBool("Cry", true);
                canvas2.SetActive(true);
                GetComponent<followDestinationCap2_1>().enabled = false;

            }
        }
    }
}
