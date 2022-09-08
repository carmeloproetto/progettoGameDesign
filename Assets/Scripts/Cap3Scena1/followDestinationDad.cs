using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class followDestinationDad : MonoBehaviour
{

     public Transform target;
    public float speed;

    //private Animator _animator;

    Vector3 b;

    private float velocity = 5f;
    private float aux = 0.8f;

    private Scene scene;


    public GameObject dlgMng;

      void Start()
    {
     // _animator = GetComponent<Animator>();
      b = target.position;
    }


    void FixedUpdate()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, speed);
        //_animator.SetFloat("Speed", velocity);
        velocity -= aux * Time.deltaTime;
        transform.LookAt(target);
        //dlgMng.GetComponent<DialogueManagerCap3_1>().disableSpace = true; 


        //abbiamo raggiunto la destinazione
        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
          
          scene = SceneManager.GetActiveScene();
            if(scene.name == "Cap3_scena2"){
              this.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
            }
            else{
                //BISOGNA FAR PARTIRE IL MINI GIOCO DELLA SCENA 1 CAPITOLO 3 QUI

            }
          //dlgMng.GetComponent<DialogueManagerCap3_1>().disableSpace = false; 
           this.GetComponent<followDestinationDad>().enabled = false;
           

            
        }
    }

}
