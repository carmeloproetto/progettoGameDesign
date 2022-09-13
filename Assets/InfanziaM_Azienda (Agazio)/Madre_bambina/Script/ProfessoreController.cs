using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfessoreController : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;
    public GameObject ragazzo;

    private bool _isGrounded = true;
    private float _gravityValue = -9.81f;

    public bool profStartRun;

    public float velocity;
    private Vector3 targetDirection;
    private Vector3 velocityComponents;
    private Vector3 lookAtNoY;

    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        targetDirection = transform.forward;
        _animator = this.GetComponent<Animator>();
        //ragazzo = GameObject.Find("Ragazzo");
        velocity = 3.5f;
        profStartRun = false;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _controller.isGrounded;
        _animator.SetBool("Grounded", _isGrounded);

        if (_isGrounded && velocityComponents.y < 0)
        {
            velocityComponents.y = 0;
            _animator.SetBool("FreeFall", false);
        }

        if (profStartRun)
        {
            //animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            //NTime = animStateInfo.normalizedTime;

            //if (NTime > 1.0f) animationFinished = true;

            if (Vector3.Distance(ragazzo.transform.position, transform.position) <= 2f)
                profStartRun = false;


            if (velocity < 3.5f)
                velocity += 0.15f;
            else
                velocity = 3.5f;
            lookAtNoY.Set(ragazzo.transform.position.x, 2.491f, ragazzo.transform.position.z);
            transform.LookAt(lookAtNoY);
            targetDirection = transform.forward;
            Debug.Log(targetDirection);
            Debug.Log("Prof - position:" + ragazzo.transform.position);
            velocityComponents = targetDirection * velocity * Time.deltaTime;
            //velocityComponents.y += _gravityValue * Time.deltaTime * Time.deltaTime;
            _controller.Move(velocityComponents);

            _animator.SetFloat("Speed", velocity);
            //logica distanza dal ragazzino
        }
        else
        {
            
            velocity = velocity > 0 ? velocity - 0.1f : velocity = 0 ;
            //if (velocity < 0) velocity = 0;
            velocityComponents = targetDirection * velocity * Time.deltaTime;
            //velocityComponents.y += _gravityValue * Time.deltaTime * Time.deltaTime;
            _controller.Move(velocityComponents);

            _animator.SetFloat("Speed", velocity);
        }
    }

    public void Restart()
    {
        this.transform.position = startingPosition;
        profStartRun = false;
    }
}
