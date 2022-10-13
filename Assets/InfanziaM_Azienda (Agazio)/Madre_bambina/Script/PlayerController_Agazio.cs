using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Agazio : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator; 

    public float acceleration = 3f;
    public float currAcceleration; 

    public float velocity = 0f;
    public float maxVelocity = 2f;

    public float rotationSpeed = 0.1f;

    public bool _isRightForward = true;

    private bool _isMoving = false;

    private bool _isGrounded = true;
    private float _gravityValue = -9.81f;

    public float _jumpHeight = 1.0f;
    private Vector3 _playerVelocity; 

    public bool _isBehindChest = false; 

    private Vector3 curTarDirection;

    private bool _inputEnabled = true;
    private bool _jumpEnabled = true;
    private bool _backwardEnabled = true; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindObjectOfType<AudioManager>().FadeIn("birds", 1, 0.3f));
        _controller = GetComponent<CharacterController>();
        curTarDirection = transform.forward;

        _animator = this.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _controller.isGrounded;
        _animator.SetBool("Grounded", _isGrounded);

        if( _isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
            _animator.SetBool("FreeFall", false);
        }

        float horizontal = Input.GetAxisRaw("Horizontal"); 

        if( _isMoving || (horizontal == 1f && _inputEnabled ) || (horizontal == -1f && _backwardEnabled && _inputEnabled ) )
        {
            currAcceleration = acceleration;

            if ( horizontal == 1f && !_isRightForward && _inputEnabled )
            {
                _isRightForward = true;
                curTarDirection = Vector3.right; 
            }    
            else if( horizontal == -1f && _isRightForward && _inputEnabled && _backwardEnabled )
            {
                _isRightForward = false;
                curTarDirection = Vector3.left;
            }     
        }
        else
        {
            currAcceleration = -acceleration; 
        }

        velocity += currAcceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, 0f, maxVelocity);
        _animator.SetFloat("Speed", velocity);

        Quaternion targetRotation = Quaternion.LookRotation(curTarDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);

        _controller.Move(curTarDirection * velocity * Time.deltaTime);

        float jump = Input.GetAxisRaw("Jump");
        if( jump != 0f && _isGrounded && _jumpEnabled )
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            _animator.SetTrigger("Jump");
        }
        else if( !_isGrounded )
        {
            _animator.SetBool("FreeFall", true);
        }
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
        
    }

    public void SetTargetDirection(Vector3 targetDirection)
    {
        this.curTarDirection = targetDirection; 
    }

    public void IsMoving(bool value)
    {
        _isMoving = value; 
    }

    public void DisableInput()
    {
        _inputEnabled = false; 
    }

    public void EnableInput()
    {
        _inputEnabled = true;
    }

    public void DisableJump()
    {
        _jumpEnabled = false; 
    }

    public void EnableJump()
    {
        _jumpEnabled = true;
    }

    public void DisableBackward()
    {
        _backwardEnabled = false;
    }

    public void EnableBackward()
    {
        _backwardEnabled = true;
    }
}
