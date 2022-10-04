using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestination : MonoBehaviour
{

    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 4f;
    private float aux = 0.8f;
    private bool firstTime;
    public GameObject dad;

    private DialogueTrigger script_dialogueTrigger;
    public GameObject madreBambina;
    public GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
      _animator = GetComponent<Animator>();
      b = target.position;
      firstTime = true;
      script_dialogueTrigger = madreBambina.GetComponent<DialogueTrigger>();
      dad.transform.eulerAngles = new Vector3(0f, 90f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, speed);
        _animator.SetFloat("Speed", velocity);
        velocity -= aux * Time.deltaTime;

        //abbiamo raggiunto la destinazione
        if(transform.position.x == target.position.x && transform.position.z == target.position.z && firstTime){
           // transform.LookAt(barrel);
            //dad.transform.eulerAngles = new Vector3(0f, -90f, 0f);
            StartCoroutine( Rotate( new Vector3(0, -180, 0), 0.3f));
            _animator.SetFloat("Speed", 0f);
            _animator.SetBool("Hello", true);
            firstTime = false;
            //GetComponent<TargetFollower2>().enabled = false;
        }
    }


     private IEnumerator Rotate( Vector3 angles, float duration )
    {
        Quaternion startRotation = dad.transform.rotation ;
        Quaternion endRotation = Quaternion.Euler( angles ) * startRotation ;
        for( float t = 0 ; t < duration ; t+= Time.deltaTime )
        {
            dad.transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration ) ;
            yield return null;
        }
        dad.transform.rotation = endRotation ;
        //rotating = false;
    }



    //funzione che parte quando finisce l'animazione di hello
    void endHello(){
        Debug.Log("animazione hello terminata");
       
        _animator.SetBool("Hello", false);
        canvas.GetComponent<Canvas>().enabled = true;
        script_dialogueTrigger.startConv = true;
        this.GetComponent<followDestination>().enabled = false;
    }
}
