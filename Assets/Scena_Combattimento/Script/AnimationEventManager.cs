using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    public Animator _bullo;
    public Animator ragazzino;
    public Animator dad;


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
}
