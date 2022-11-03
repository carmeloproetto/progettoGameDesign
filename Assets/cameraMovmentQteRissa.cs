using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovmentQteRissa : MonoBehaviour
{

    Vector3 b;


    // Start is called before the first frame update
    void Start()
    {
        b.Set(-35.6246f, 11.88f, -28.978f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, 0.008f);
        
         if(transform.position.x == -35.6246f && transform.position.y == 11.88f && transform.position.z == -28.978f)
        {
            this.GetComponent<CameraFollow>().enabled = true;
            this.GetComponent<CameraFollow>().target_aux = this.GetComponent<CameraFollow>().target2;
            this.GetComponent<cameraMovmentQteRissa>().enabled= false;
        }
    }
}
