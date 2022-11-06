using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
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
    private bool _rotationEnabled = true; 
    private bool _backwardEnabled = true; 

    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        curTarDirection = transform.forward;
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(PauseMenu.GameIsPaused)
            return;

        //blocco il movimento se sto conversando
        if(DialogueManager.GetInstance().dialogueIsPlaying || DialogueManagerCap2_2.GetInstance().dialogueIsPlaying){
            _animator.SetFloat("Speed", 0);
            if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(ChangeSpeed(maxVelocity, 4f, 0.4f));
            }
            else if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))
            {
                StartCoroutine(ChangeSpeed(maxVelocity, 2f, 0.4f));
            }
            return;
        }


        _isGrounded = _controller.isGrounded;
        _animator.SetBool("Grounded", _isGrounded);

        if( _isGrounded && _playerVelocity.y < 0 )
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

        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(ChangeSpeed(maxVelocity, 4f, 0.4f));
        }
        else if (Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            StartCoroutine(ChangeSpeed(maxVelocity, 2f, 0.4f));
        }

        velocity += currAcceleration * Time.deltaTime;
        velocity = Mathf.Clamp(velocity, 0f, maxVelocity);
        _animator.SetFloat("Speed", velocity);

        if( _rotationEnabled)
        {
            Quaternion targetRotation = Quaternion.LookRotation(curTarDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
        }
        
        _controller.Move(curTarDirection * velocity * Time.deltaTime);

        float jump = Input.GetAxisRaw("Jump");
        if( jump != 0f && _isGrounded && _jumpEnabled )
        {
            this.GetComponent<Animator>().applyRootMotion = false;
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            _animator.SetTrigger("Jump");
        }
        else if( !_isGrounded )
        {
            _animator.SetBool("FreeFall", true);
        }
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);

        if (jump == 0 && _isGrounded)
        {
            this.GetComponent<Animator>().applyRootMotion = true;
        }

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

    public void DisableRotation()
    {
        _rotationEnabled = false;
    }

    public void EnableRotation()
    {
        _rotationEnabled = true;
    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            maxVelocity = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        maxVelocity = v_end;
    }
}
