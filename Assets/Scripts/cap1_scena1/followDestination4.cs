using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestination4 : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 2f;

    public GameObject dlgManger;
    public GameObject canvasTutorialDialogo;


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

        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
            if(this.name == "MadreBambina"){
                transform.eulerAngles = new Vector3(0f, 90f, 0f);
                
                Debug.Log("madre arrivata davanti casa");
                StartCoroutine(triggerContinueConversation());
            }   
            _animator.SetFloat("Speed", 0f);
            this.GetComponent<followDestination4>().enabled = false;
        }
    }

    IEnumerator triggerContinueConversation(){    
        yield return new WaitForSeconds(1);
        dlgManger.GetComponent<DialogueManager>().ContinueStoryByOtherScript();
        dlgManger.GetComponent<DialogueManager>().disableSpace = false;
        dlgManger.GetComponent<DialogueManager>().disableSpace_camminataParco = false;
        canvasTutorialDialogo.GetComponent<Canvas>().enabled = true;
    }



}
