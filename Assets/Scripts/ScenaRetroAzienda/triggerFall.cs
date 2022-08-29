using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFall : MonoBehaviour
{

    private triggerStartFall trigger_script;
    public GameObject trigger_object;

    public bool startAnimation;

    public void Start()
    {
        trigger_script = trigger_object.GetComponent<triggerStartFall>();
        startAnimation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("k") && trigger_script.pressSpace == true){
            startAnimation = true;
            GetComponent<Animator>().Play("CadutaBarile");
            // GetComponent<Animator>().enabled = false;
        }  
    }

    void disableAnimator(){
        GetComponent<Animator>().enabled = false;
        startAnimation = false;
    }
}
