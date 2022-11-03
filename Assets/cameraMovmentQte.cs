using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovmentQte : MonoBehaviour
{

    Vector3 b;


    // Start is called before the first frame update
    void Start()
    {
        b.Set(-35.61282f, 11.88f, -29.0143f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, 0.04f);
        
         if(transform.position.x == -35.61282f && transform.position.y == 11.88f && transform.position.z == -29.0143f)
        {

            this.GetComponent<CameraFollow>().enabled = true;
            this.GetComponent<CameraFollow>().target_aux = this.GetComponent<CameraFollow>().target2;
            this.GetComponent<cameraMovmentQte>().enabled= false;
        }
    }
}
