using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{
    private Animator _bullo;
    public GameObject ragazzino;

    // Start is called before the first frame update
    void Start()
    {
        _bullo = GameObject.FindGameObjectWithTag("Bullo").GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PunchReact()
    {
        _bullo.SetTrigger("PunchReacting");
    }

    public void Punch()
    {
        ragazzino.GetComponent<Animator>().SetTrigger("Cadi");
    }
}
