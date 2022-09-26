using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimationEventManager : MonoBehaviour
{
    public Animator _bullo;
    public Animator ragazzino;
    public Animator dad;
    public Transform rightHandIK;


    public void PunchReact()
    {
        _bullo.SetTrigger("PunchReacting");
    }

    public void Punch()
    {
        ragazzino.GetComponent<Animator>().SetTrigger("Cadi");
    }


    //funzione che parte quando il bambino è per terra
    void dadWalks(){
        dad.GetComponent<followDestination6>().enabled = true;
    }

    public void StartDadReaction()
    {
        dad.SetTrigger("startReaction");
    }

    public void StartBullyReaction()
    {
        _bullo.SetTrigger("startReaction");
    }

    public void SpingiBullo()
    {
        _bullo.SetTrigger("cadi");
    }

    public void RaccogliLattina_1()
    {
        Transform lattina = GameObject.FindGameObjectWithTag("Spazzatura_1").transform;
        rightHandIK.position = lattina.position;
        dad.gameObject.GetComponentInChildren<Rig>().weight = 1;
    }

    public void RaccogliLattina_2()
    {
        Transform lattina = GameObject.FindGameObjectWithTag("Spazzatura_2").transform;
        rightHandIK.position = lattina.position;
        dad.gameObject.GetComponentInChildren<Rig>().weight = 1;
    }

    public void RaccogliLattina_3()
    {
        Transform lattina = GameObject.FindGameObjectWithTag("Spazzatura_3").transform;
        rightHandIK.position = lattina.position;
        dad.gameObject.GetComponentInChildren<Rig>().weight = 1;
    }

    public void AzzeraWeight()
    {
        dad.gameObject.GetComponentInChildren<Rig>().weight = 0;
    }

}
