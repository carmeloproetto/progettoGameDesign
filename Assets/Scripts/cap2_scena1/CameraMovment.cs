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
        b.Set(-4.769f, 3.88f, -8.351f);
        FindObjectOfType<AudioManager>().Play("rainSound");
        mom.GetComponent<Animator>().SetBool("Talk", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        transform.position = Vector3.MoveTowards(a, b, 0.04f);
        
         if(transform.position.x == -4.769f && transform.position.y == 3.88f && transform.position.z == -8.351f)
        {
            //this.GetComponent<CameraFollow>().enabled = true;
            StartCoroutine(startDialogue());
        }
    }

     private IEnumerator startDialogue(){
        
        yield return new WaitForSeconds(1.5f);
        mom.GetComponent<DialogueTriggerCap2>().startConvByOtherScript();
        this.GetComponent<CameraMovment>().enabled = false;
     }
}
