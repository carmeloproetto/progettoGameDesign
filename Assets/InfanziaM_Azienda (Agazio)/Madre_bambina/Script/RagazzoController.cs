using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagazzoController : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;
    public PadreStudenteController _playerController;
    public ProfessoreController _profController;
    private GameObject obstacles;

    public float acceleration = 3f;
    public float currAcceleration;

    public float qteVelocity = 5f;

    public float rotationSpeed = 0.1f;

    public bool _isRightForward = true;

    private bool _isMoving = false;

    private bool _isGrounded = true;
    private float _gravityValue = -9.81f;

    public float _jumpHeight = 1.0f;
    private Vector3 _playerVelocity;

    public bool _isBehindChest = false;

    private Vector3 targetDirection;

    private bool _inputEnabled = true;
    private bool _jumpEnabled = true;

    public bool qteStart = false;

    private int passedObstacles = 0; //indice array ostacoli
    private int numObstacles;
    private int _auxCount = 0;

    private float currentPositionX;

    private bool jumpQTE = false;
    private float[] obstaclesCoo = { 0, 0, 0, 0, 0, 0 };
    private Vector3 velocityComponents;

    private bool alreadyJumped = true;
    private bool padreAlreadyStarted = true;
    private bool profAlreadyStarted = true;

    private Vector3 startingPosition;

    public GameObject stone;

    public bool stumble;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        targetDirection = transform.forward;
        _animator = this.GetComponent<Animator>();
        //_playerController = GameObject.Find("Padre studente_Unity").GetComponent<PlayerController>();
        startingPosition = transform.position;
        qteStart = true;
        qteVelocity = 5f;
        stumble = false;
        obstacles = GameObject.Find("Obstacles");
        int c = 0;
        foreach (Transform t in obstacles.transform)
        {
            obstaclesCoo[c] = t.position.x;
            c++;
        }


        numObstacles = 6;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _controller.isGrounded;
        _animator.SetBool("Grounded", _isGrounded);

        if(currentPositionX >= 13.75f)
            if (profAlreadyStarted)
            {
                _profController.profStartRun = true;
                profAlreadyStarted = false;
            }

        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0;
            _animator.SetBool("FreeFall", false);
        }

        if (qteStart)
        {
            targetDirection = Vector3.right;
            if (padreAlreadyStarted)
            {
                _playerController.startRun = true;
                padreAlreadyStarted = false;
            }
            
            //_controller.Move(targetDirection * qteVelocity * Time.deltaTime);
            

            if (passedObstacles == numObstacles && transform.position.x >= stone.transform.position.x)
            {

                qteVelocity = 0;
                qteStart = false;
                stumble = true;
                
                //_animator.SetBool("Stumble", true);
            }
            else
                JumpDetection();

            if (jumpQTE)
                JumpRoutine();
            else
                alreadyJumped = true;

            if (stumble)
            {
                //_controller.detectCollisions = false;
                ////TODO
                //if(_controller.OnControllerColliderHit) TODOTODOTODO
                //transform.position = new Vector3(66.4209671f, 1.71000004f, -2.71532965f);
                //_playerVelocity.y += Mathf.Sqrt(-3.0f * _gravityValue);
                //_animator.SetTrigger("Stumble");
                //stumble = false;
            }
            else
                _animator.SetFloat("Speed", qteVelocity);

            velocityComponents = targetDirection * qteVelocity * Time.deltaTime;
            velocityComponents.y = _playerVelocity.y * Time.deltaTime;
            Debug.Log("velocity comp1 " + velocityComponents);
            if(!stumble)
                _controller.Move(velocityComponents);

            

        }
        else
        {
            //if (_isGrounded && _playerVelocity.y < 0)
            //{
            //    _playerVelocity.y = 0f;
            //    _animator.SetBool("FreeFall", false);
            //}

            //float horizontal = Input.GetAxisRaw("Horizontal");

            //if (_isMoving || (horizontal != 0f && _inputEnabled))
            //{
            //    currAcceleration = acceleration;

            //    if (horizontal == 1f && !_isRightForward && _inputEnabled)
            //    {
            //        _isRightForward = true;
            //        //targetDirection = transform.forward * -1f;
            //        targetDirection = Vector3.left * -1f;
            //    }
            //    else if (horizontal == -1f && _isRightForward && _inputEnabled)
            //    {
            //        _isRightForward = false;
            //        targetDirection = Vector3.right * -1f;
            //        //targetDirection = transform.forward * -1f;
            //    }
            //}
            //else
            //{
            //    currAcceleration = -acceleration;
            //}

            //Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);


            //float jump = Input.GetAxisRaw("Jump");
            //if (jump != 0f && _isGrounded && _jumpEnabled)
            //{
            //    _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            //    _animator.SetTrigger("Jump");
            //}
            //else if (!_isGrounded)
            //{
            //    _animator.SetBool("FreeFall", true);
            //}
            //_playerVelocity.y += _gravityValue * Time.deltaTime;
            //_controller.Move(_playerVelocity * Time.deltaTime);
        }
    }

    public void JumpDetection()
    {

        Debug.Log("Ragazzo passedObstacles : " + passedObstacles);

        if (jumpQTE && currentPositionX >= obstaclesCoo[passedObstacles] + 2f)
        {
            passedObstacles++;
            jumpQTE = false;
        }

        currentPositionX = transform.position.x;

        if (passedObstacles < numObstacles && currentPositionX >= obstaclesCoo[passedObstacles] - 3.5f && currentPositionX <= obstaclesCoo[passedObstacles] - 2f) //zona pressione tasto
        {
            jumpQTE = true;
            _jumpEnabled = true;
        }
    }

    public void JumpRoutine()
    {
        if (currentPositionX > obstaclesCoo[passedObstacles] - 2f && alreadyJumped)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            _animator.SetTrigger("Jump");
            alreadyJumped = false;
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
    }

    public void Restart()
    {
        this.transform.position = startingPosition;
        qteVelocity = 0;
        passedObstacles = 0;

        _profController.profStartRun = false;
        profAlreadyStarted = true;

    }

    public void SetTargetDirection(Vector3 targetDirection)
    {
        this.targetDirection = targetDirection;
    }

    public void IsMoving(bool value)
    {
        _isMoving = value;
    }
}
