using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovmentQte : MonoBehaviour
{

    Vector3 b;


    // Start is called before the first frame update
    void Start()
    {
        b.Set(-36.17051f, 11.88f, -29.5153f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, 0.04f);
        
         if(transform.position.x == -36.17051f && transform.position.y == 11.88f && transform.position.z == -29.5153f)
        {

            this.GetComponent<CameraFollow>().enabled = true;
            this.GetComponent<CameraFollow>().target_aux = this.GetComponent<CameraFollow>().target2;
            this.GetComponent<cameraMovmentQte>().enabled= false;
        }
    }
}
