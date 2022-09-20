using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMomMovment : MonoBehaviour
{

    public Transform target;
    public float speed;
    private Animator _animator;

    Vector3 b;
    private float velocity = 4.5f;
    private float aux = 0.8f;

    private bool startMovment;
    public GameObject mom;

    public GameObject levelLoader;

    private void Start(){
        startMovment = false;
        _animator = mom.GetComponent<Animator>();
        b = target.position;
    }

    private void OnTriggerEnter(Collider collider){
        
        if(collider.CompareTag("Player")){
            startMovment = true;
            mom.GetComponent<PlayerController>().enabled = false;
            Debug.Log("ok");
        }
    }

    void FixedUpdate(){
        if(startMovment == true){
            Debug.Log("ok2");
            Vector3 a = mom.transform.position;
            mom.transform.position = Vector3.MoveTowards(a, b, speed);
            _animator.SetFloat("Speed", velocity);
            velocity -= aux * Time.deltaTime;
            mom.transform.LookAt(target);

            StartCoroutine(LoadScene());

            /*if(mom.transform.position.x == target.position.x && mom.transform.position.z == target.position.z){
            _animator.SetFloat("Speed", 0f);
            this.GetComponent<triggerMomMovment>().enabled = false;
            //BISOGNA CARICARE LA SCENA SUCCESSIVA
            levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
            }*/
        }
    }

    private IEnumerator LoadScene(){
        yield return new WaitForSeconds(1.5f);
        levelLoader.GetComponent<LevelLoaderScript>().loadScene = true;
    }
}
