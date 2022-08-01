using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFall : MonoBehaviour
{

    private triggerStartFall trigger_script;
    public GameObject trigger_object;

    public bool startAnimation;

    private TargetFollower tgFlwscript;
    private TargetFollower2 tgFlwscript2;
    public GameObject tgFlw;



    public Transform target;
    public float speed;


    public void Start()
    {
        trigger_script = trigger_object.GetComponent<triggerStartFall>();
        startAnimation = false;

        tgFlwscript = tgFlw.GetComponent<TargetFollower>();
        tgFlwscript2 = tgFlw.GetComponent<TargetFollower2>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("k") && trigger_script.pressSpace == true){
            tgFlwscript.enabled = true;
            //startAnimation = true;
            //GetComponent<Animator>().Play("CadutaBarile");
            // GetComponent<Animator>().enabled = false;
        }  
    }

    void disableAnimator(){
        GetComponent<positionControl>().animationEnd = true;
        GetComponent<Animator>().enabled = false;
        GetComponent<BoxCollider>().enabled = true;
        //startAnimation = false;

        tgFlwscript2.enabled = true;
        Debug.Log("evento");

    }
}
