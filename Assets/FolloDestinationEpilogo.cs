using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloDestinationEpilogo : MonoBehaviour
{

    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 2f;
    private float aux = 0.2f;

    public GameObject dad;

    private bool firstTime;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        b = target.position;
        firstTime = true;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(firstTime){
            Vector3 a = transform.position;
            Vector3 a_dad = dad.transform.position;
            transform.position = Vector3.MoveTowards(a, b, speed);
            dad.transform.position = Vector3.MoveTowards(a_dad, b, speed);
            _animator.SetFloat("Speed", velocity);
            dad.GetComponent<Animator>().SetFloat("Speed", velocity);
            //velocity -= aux * Time.deltaTime;
        }

        if(transform.position.x == target.position.x && transform.position.z == target.position.z && firstTime){  
             StartCoroutine(Rotate( new Vector3(0, -180, 0), 0.3f));
             _animator.SetFloat("Speed", 0f);
             dad.GetComponent<Animator>().SetFloat("Speed", 0f);
             firstTime = false;
        }
    }

    private IEnumerator Rotate( Vector3 angles, float duration )
    {
        Quaternion startRotation = this.transform.rotation ;
        Quaternion endRotation = Quaternion.Euler( angles ) * startRotation ;
        for( float t = 0 ; t < duration ; t+= Time.deltaTime )
        {
            this.transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration ) ;
            yield return null;
        }
        this.transform.rotation = endRotation;

        this.gameObject.GetComponent<DialogueTriggerEpilogo>().startConvByOtherScript();
        //rotating = false;
    }
}
