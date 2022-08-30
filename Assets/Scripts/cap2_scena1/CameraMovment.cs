using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{

    Vector3 b;

    public GameObject mom;

    // Start is called before the first frame update
    void Start()
    {
        b.Set(-6.105166f, 4.26f, -11.977f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, 0.04f);

         if(transform.position.x == -6.105166f && transform.position.y ==  4.26f && transform.position.z == -11.977f){
            //this.GetComponent<CameraFollow>().enabled = true;
            StartCoroutine(startDialogue());
        }
    }

     private IEnumerator startDialogue(){
        yield return new WaitForSeconds(1.5f);
        mom.GetComponent<DialogueTriggerCap2>().startConvByOtherScript();
        
     }
}
