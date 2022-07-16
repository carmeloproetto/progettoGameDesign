using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public float Speed;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(VirtualInputManager.Instance.MoveRight && VirtualInputManager.Instance.MoveLeft){
            animator.SetBool("Move", false);
            return;
        }

        if(!VirtualInputManager.Instance.MoveRight && !VirtualInputManager.Instance.MoveLeft){
            animator.SetBool("Move", false);
        }

        if(VirtualInputManager.Instance.MoveLeft){
            this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            animator.SetBool("Move", true);
        }

        if(VirtualInputManager.Instance.MoveRight){
            this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
            animator.SetBool("Move", true);
        }

          
                
    }
}
