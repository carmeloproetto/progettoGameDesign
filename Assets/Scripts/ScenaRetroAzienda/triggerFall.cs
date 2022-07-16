using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFall : MonoBehaviour
{

    private triggerStartFall trigger_script;
    public GameObject trigger_object;

    public void Start()
    {
        trigger_script = trigger_object.GetComponent<triggerStartFall>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && trigger_script.pressSpace == true){
            GetComponent<Animator>().Play("CadutaBarile");
        }  
    }
}
