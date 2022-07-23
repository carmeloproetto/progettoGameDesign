using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator _animator;
    private float _inputSpeed;
    private Vector3 _inputVector;

    public GameObject obj;
    private triggerFall script;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        script = obj.GetComponent<triggerFall>();
    }

    // Update is called once per frame
    //serve per animare la camminata
    void Update()
    {

      if(script.startAnimation == true){
            _animator.SetBool("kPress", true);
           // _animator.SetBool("kPress", false);
        }

    }
}
