using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Transform target3;

    public Transform target_aux;

    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;
    
    //serve per non cambiare il target della camera prima di aver raggiunto la corretta posizione ed evitare 
    //cambi bruschi di camera nell'animazione
    public bool destinationReached;

    Vector3 b;

    private void Start(){
        target_aux = target;
        destinationReached = false;
    }

    private void Update(){
        if(target_aux == target2 && !destinationReached){
           Vector3 a = transform.position;
           b.Set(91.78f, 11.89683f, -29.005f);
           transform.position = Vector3.MoveTowards(a, b, 0.02f);
        }

         if(target_aux == target3 && !destinationReached){
           Vector3 a = transform.position;
           b.Set(-33.703f, 11.874f, -29.005f);
           transform.position = Vector3.MoveTowards(a, b, 0.02f);
        }

        if(transform.position.x == 91.78f && transform.position.y == 11.89683f && transform.position.z == -29.005f){
            destinationReached = true;
        }

        if(transform.position.x == -33.703f && transform.position.y == 11.874f && transform.position.z == -29.005f){
            destinationReached = true;
        }

        if(target_aux == target || destinationReached)
            Follow();
    }

    void Follow(){
        Vector3 targetPosition = target_aux.position + offset;
        //Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.deltaTime);
        transform.position = targetPosition;
    } 
}
