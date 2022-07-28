using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionControl : MonoBehaviour
{
    public bool animationEnd;

    // Start is called before the first frame update
    void Start()
    {
        animationEnd = false;    
    }

    // Update is called once per frame
    void Update()
    {

    if(animationEnd == true){
        transform.eulerAngles = new Vector3(
            1.201f,
            -17.697f,
            270.253f
        );
    }

        if(transform.position.x > 133f)
                transform.position = new Vector3(133f, transform.position.y, transform.position.z);
    }
}
