using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestination6 : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 3f;

    public GameObject triggerDialogueZone;

    void Start()
    {
      _animator = GetComponent<Animator>();
      b = target.position;
      
    }

    void FixedUpdate()
    {  
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, speed);
        _animator.SetFloat("Speed", velocity);
        this.GetComponent<PlayerController>().enabled = false;

    
        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
            _animator.SetFloat("Speed", 0);
            this.GetComponent<PlayerController>().enabled = false;
            
            if( triggerDialogueZone.GetComponent<DialogueTrigger>().language == 1)
                triggerDialogueZone.GetComponent<DialogueTrigger>().ink = triggerDialogueZone.GetComponent<DialogueTrigger>().inkJSON2;
            else
                triggerDialogueZone.GetComponent<DialogueTrigger>().ink = triggerDialogueZone.GetComponent<DialogueTrigger>().inkJSON2_Eng;

            triggerDialogueZone.GetComponent<DialogueTrigger>().startConvByOtherScript();
            this.GetComponent<followDestination6>().enabled = false;
        }  
            
    }


    

}

