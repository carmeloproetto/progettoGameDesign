using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class followDestinationDad : MonoBehaviour
{

     public Transform target;
    public float speed;

    private Animator _animator;

    Vector3 b;

    private float velocity = 4f;
    private float aux = 0.78f;

    private Scene scene;


    public GameObject dlgMng;
    public Transform ragazzino;
    public GameObject ragazzo;
    public Camera camera;

      void Start()
    {
      _animator = GetComponent<Animator>();
      b = target.position;
      StartCoroutine(WalkRagazzo());

    }


    void FixedUpdate()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, speed);
        _animator.SetFloat("Speed", velocity);
        velocity -= aux * Time.deltaTime;
        transform.LookAt(target);
        //dlgMng.GetComponent<DialogueManagerCap3_1>().disableSpace = true; 
        //ragazzo.GetComponent<Animator>().SetFloat("Speed", 2f);

        //abbiamo raggiunto la destinazione
        if(transform.position.x == target.position.x && transform.position.z == target.position.z){
            Debug.Log("Destinazione raggiunta!");
            FindObjectOfType<AudioManager>().Stop("walkDirt");
          
            scene = SceneManager.GetActiveScene();
            if(scene.name == "Cap3_scena2"){
                Debug.Log(scene.name);
                _animator.SetFloat("Speed", 0f);
                transform.LookAt(ragazzino);
                this.GetComponent<DialogueTriggerCap3_1>().startConvByOtherScript();
                _animator.SetBool("Speak", true);
                camera.GetComponent<CameraFollow>().enabled = true;
                camera.GetComponent<CameraMovmentCap3>().enabled = false;
                //ragazzo.GetComponent<Animator>().SetFloat("Speed", 0f);
            }
            else{
                //BISOGNA FAR PARTIRE IL MINI GIOCO DELLA SCENA 1 CAPITOLO 3 QUI

            }
            //dlgMng.GetComponent<DialogueManagerCap3_1>().disableSpace = false; 
            this.GetComponent<followDestinationDad>().enabled = false;
        }
    }

     private IEnumerator WalkRagazzo(){
        Debug.Log("siamo dentro WalkRagazzo");
        yield return new WaitForSeconds(0.2f);
        ragazzo.GetComponent<followDestinationRagazzinoIniziale>().enabled = true;
    }

}
