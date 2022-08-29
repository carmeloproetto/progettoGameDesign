using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadiettoTriggerManager : MonoBehaviour
{
    public GameObject trigger;
    private Animator _animator; 

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (_animator.GetBool("destinationTwo"))
        {
            trigger.SetActive(true); 
        }     
    }
}
