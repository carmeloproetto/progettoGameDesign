using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator _animator;
    private float _inputSpeed;
    private Vector3 _inputVector;

    public GameObject VirtualInputManager;
    private VirtualInputManager input_script;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        input_script = VirtualInputManager.GetComponent<VirtualInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _inputVector = new Vector3(h, 0, v);
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);


      if(input_script.MoveRight){
  
            _animator.SetFloat("speed", _inputSpeed);
        }

        if(input_script.MoveLeft){
    
            _animator.SetFloat("speed", _inputSpeed);
        }  
    }
}
