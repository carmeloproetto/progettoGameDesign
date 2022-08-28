using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform target2;

    public Transform target_aux;

    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;
    
    private void Start(){
        target_aux = target;
    }

    private void FixedUpdate(){
        Follow();
    }

    void Follow(){
        Vector3 targetPosition = target_aux.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = targetPosition;
    } 
}
