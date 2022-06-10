using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace herath{
    public class Movement2D : MonoBehaviour
    {

     
        public float Speed;
        public Vector3 jump;
        public float jumpForce = 2.0f;
     
        public bool isGrounded;
        Rigidbody rb;

        void Start(){
             rb = GetComponent<Rigidbody>();
             jump = new Vector3(0.0f, 2.0f, 0.0f);

         }


        void OnCollisionStay()
         {
             isGrounded = true;
         }

        // Update is called once per frame
        void Update()
        {
            
            
            if(VirtualInputManager.Instance.MoveRight && VirtualInputManager.Instance.MoveLeft){
                return;
            }

            if(VirtualInputManager.Instance.MoveRight){
                this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                
            }

            if(VirtualInputManager.Instance.MoveLeft){
                this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
                this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            /*salto
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
                 rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                 isGrounded = false;
            }
            */

        }
    }
}