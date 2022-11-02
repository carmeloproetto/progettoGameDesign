using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followDestination2 : MonoBehaviour
{

    public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 4f;

    public GameObject triggerDialogueSpace;
    

    // Start is called before the first frame update
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
           triggerDialogueSpace.SetActive(true);
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
            _animator.SetFloat("Speed", 0f);
            if( triggerDialogueSpace.GetComponent<DialogueTrigger>().language == 1)
                triggerDialogueSpace.GetComponent<DialogueTrigger>().ink = triggerDialogueSpace.GetComponent<DialogueTrigger>().inkJSON2;
            else
                triggerDialogueSpace.GetComponent<DialogueTrigger>().ink = triggerDialogueSpace.GetComponent<DialogueTrigger>().inkJSON2_Eng;

        }
    }


}
