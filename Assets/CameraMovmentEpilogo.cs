using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovmentEpilogo : MonoBehaviour
{
    float t;
    Vector3 startPosition;
    Vector3 target;
    Vector3 destination;
    public GameObject canvas2;
    private float duration;

    float timeToReachTarget;
     void Start()
     {
        startPosition = target = transform.position;
        if(SceneManager.GetActiveScene().name != "Epilogo_lago"){
            destination.Set(115,12,-30);
            duration = 16;    
        }
        else{
            destination.Set(-126.6f, 12.5f, 15.89f);
            duration = 10;    
        }
        SetDestination();
        StartCoroutine(startCanvas());
     }
     void Update() 
     {
             t += Time.deltaTime/timeToReachTarget;
             transform.position = Vector3.Lerp(startPosition, target, t);
     }
     public void SetDestination()
     {
            t = 0;
            startPosition = transform.position;
            timeToReachTarget = duration;
            target = destination; 
     }

     IEnumerator startCanvas(){
        yield return new WaitForSeconds(2f);
        canvas2.SetActive(true);
    }
}
