using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovmentCap3 : MonoBehaviour
{

     Vector3 b;

    // Start is called before the first frame update
    void Start()
    {
         b.Set(-13.72f, 4.26f, -9.761f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, 0.046f);

         if(transform.position.x == -13.72f && transform.position.y ==  4.26f && transform.position.z == -9.761f){
           
        }
    }
}
