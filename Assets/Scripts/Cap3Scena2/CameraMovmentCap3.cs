using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovmentCap3 : MonoBehaviour
{

     Vector3 b;

    // Start is called before the first frame update
    void Start()
    {
         b.Set(-14.11f, 4.43f, -11.701f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, 0.03f);

         if(transform.position.x == -14.11f && transform.position.y ==  4.43f && transform.position.z == -11.701f){
        
        }
    }
}
