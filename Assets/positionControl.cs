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
        Debug.Log("animazione caduta barile finita");
        transform.eulerAngles = new Vector3(
            1.201f,
            -17.697f,
            270.253f
        );

        if(transform.position.x < -124.5106f)
                 transform.position = new Vector3(-124.5106f, transform.position.y, transform.position.z);

        if(transform.position.z > 5.229717f)  
            transform.position = new Vector3(transform.position.x, transform.position.y, 5.229717f);   


        if(transform.position.x > -122.815f && transform.position.z < -1.788493f)
                transform.position = new Vector3(-122.815f, transform.position.y, transform.position.z);

        if(transform.position.z < -1.788493f)  
            transform.position = new Vector3(transform.position.x, transform.position.y, -1.788493f);









    }

       }
}
