using UnityEngine;
using System.Collections;

public class Movement25D : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    
    
    void Update ()
    {
        if(VirtualInputManager.Instance.MoveLeft)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        if(VirtualInputManager.Instance.MoveRight)
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        
       /* if(Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        */
    }
}
