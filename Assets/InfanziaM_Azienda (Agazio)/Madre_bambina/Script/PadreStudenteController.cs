using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PadreStudenteController : MonoBehaviour
{
    private CharacterController _controller;
    private Animator _animator;
    private GameObject obstacles;
    [SerializeField] GameObject binSprite;

    public RagazzoController ragazzoController;
    public ProfessoreController professoreController;

    public float acceleration = 3f;
    public float currAcceleration;

    public float velocity = 0f;
    public float maxVelocity = 5f;
    public float qteVelocity = 2f;

    private Vector3 velocityComponents;

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

    public bool startRun = false;
    //public bool qteEnd = false;

    private int _auxCount = 0;

    private bool jumpQTE = false;
    public float jumpVelocity = 3f;
    private bool pressed = false;
    private int passedObstacles = 0; //indice array ostacoli
    private float[] obstaclesCoo = { 0, 0, 0, 0, 0, 0 };
    private int numObstacles;
    private bool clicked;

    private int pressTimeCounter = 0;

    private float currentPositionX;

    private bool alreadyJumped = true;

    private Vector3 startingPosition;

    public GameObject dlgMng;
    public GameObject tutorialCorsa;
    public GameObject ragazzo;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        targetDirection = transform.forward;
        _animator = this.GetComponent<Animator>();
        startingPosition = transform.position;
        _auxCount = 0;

        clicked = false;

        obstacles = GameObject.Find("Obstacles");
        int c = 0;
        foreach (Transform t in obstacles.transform)
        {
            obstaclesCoo[c] = t.position.x;
            c++;
        }

        numObstacles = 6;

       // Debug.Log("c:" + c);

        //for (int i = 0; i < obstaclesCoo.Length; i++)
           // Debug.Log(i + " coo: " + obstaclesCoo[i]);


    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _controller.isGrounded;
        _animator.SetBool("Grounded", _isGrounded);
        //Debug.Log("Grounded : " + _isGrounded);

        //_playerVelocity.y += _gravityValue * Time.deltaTime;
        //_controller.Move(_playerVelocity * Time.deltaTime);



        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0;
            _animator.SetBool("FreeFall", false);
        }

        if (startRun)
        {
            targetDirection = Vector3.right;
            DisableInput();
            DisableJump();


            if (Vector3.Distance(ragazzo.transform.position, transform.position) >= 5.5f){
                Restart();
            }


           /* if (passedObstacles >= numObstacles + 1)
                startRun = false;
            else
            {*/
                JumpDetection();
                if (passedObstacles < numObstacles)
                {
                    if (currentPositionX >= obstaclesCoo[passedObstacles] - 1f && currentPositionX <= obstaclesCoo[passedObstacles] && !clicked)
                    {
                        //Debug.Log("ci siamo bro, starting pos " + startingPosition);
                        Restart();
                    }
                    else if (currentPositionX >= obstaclesCoo[passedObstacles] && clicked)
                    {
                        clicked = false;
                    }
                }

            //}


            if (jumpQTE)
                JumpRoutine();
            else
            {
                alreadyJumped = true;
                _auxCount++;
                if (_auxCount >= 10)
                {
                    qteVelocity -= 0.2f;
                    if (qteVelocity <= 0) qteVelocity = 0;
                    _auxCount = 0;
                }

                if (Input.GetKeyDown("space"))
                {
                    qteVelocity += 1f;
                    if (qteVelocity > 5f) qteVelocity = 5f;
                    //Debug.Log("qteVelocity : " + qteVelocity);
                }
            }
            velocityComponents = targetDirection * qteVelocity * Time.deltaTime;
            velocityComponents.y = _playerVelocity.y * Time.deltaTime;
            //Debug.Log("velocity comp1 " + velocityComponents);
            _controller.Move(velocityComponents);
            _animator.SetFloat("Speed", qteVelocity);



        }
        else
        {
            EnableInput();
            //EnableJump();

            float horizontal = Input.GetAxisRaw("Horizontal");

            if (_isMoving || (horizontal != 0f && _inputEnabled))
            {
                currAcceleration = acceleration;

                if (horizontal == 1f && !_isRightForward && _inputEnabled)
                {
                    _isRightForward = true;
                    //targetDirection = transform.forward * -1f;
                    targetDirection = Vector3.right;
                }
                else if (horizontal == -1f && _isRightForward && _inputEnabled)
                {
                    _isRightForward = false;
                    targetDirection = Vector3.left;
                    //targetDirection = transform.forward * -1f;
                }
            }
            else
            {
                currAcceleration = -acceleration;
            }

            velocity += currAcceleration * Time.deltaTime;
            velocity = Mathf.Clamp(velocity, 0f, maxVelocity);
            _animator.SetFloat("Speed", velocity);

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);

            velocityComponents = targetDirection * velocity * Time.deltaTime;

            float jump = Input.GetAxisRaw("Jump");
            if (jump != 0f && _isGrounded && _jumpEnabled)
            {
                _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
                _animator.SetTrigger("Jump");
            }
            else if (!_isGrounded)
            {
                //_animator.SetBool("FreeFall", true);
            }
            _playerVelocity.y += _gravityValue * Time.deltaTime;
            velocityComponents.y = _playerVelocity.y * Time.deltaTime;
            //Debug.Log("velocity comp1 " + velocityComponents);
            _controller.Move(velocityComponents);
        }
    }

    public void RunRoutine()
    {
        //_auxCount++;
        //if (_auxCount >= 10)
        //{
        //    qteVelocity -= 0.2f;
        //    if (qteVelocity <= 0) qteVelocity = 0;
        //    _auxCount = 0;
        //}

        //if (Input.GetKeyDown("space"))
        //{
        //    qteVelocity += 1f;
        //    if (qteVelocity > 5f) qteVelocity = 5f;
        //    Debug.Log("qteVelocity : " + qteVelocity);
        //}
    }

    public void JumpRoutine()
    {
        //if (currentPositionX > obstaclesCoo[passedObstacles] - 2f && currentPositionX < obstaclesCoo[passedObstacles] - 1.8f)
        if (currentPositionX > obstaclesCoo[passedObstacles] - 2f && alreadyJumped)
        {
          //  Debug.Log("salta mbare1 + ground: " + _isGrounded + " + jumpEnabled: " + _jumpEnabled);

            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);

            _animator.SetTrigger("Jump");

            alreadyJumped = false;
        }
       // Debug.Log("player velocity y : " + _playerVelocity.y);
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        //_controller.Move(_playerVelocity * Time.deltaTime);
    }

    public void JumpDetection()
    {
      //  Debug.Log("passedObstacles : " + passedObstacles);

        if (jumpQTE && currentPositionX >= obstaclesCoo[passedObstacles] + 2f)
        {
            int c = 0;
            foreach (Transform t in obstacles.transform)
            {
                if (c == passedObstacles)
                    t.GetChild(0).gameObject.SetActive(false);
                c++;
            }
            //binSprite.SetActive(false);
            passedObstacles++;
            jumpQTE = false;
        }

        currentPositionX = transform.position.x;
        if (passedObstacles < numObstacles && currentPositionX >= obstaclesCoo[passedObstacles] - 3.5f && currentPositionX <= obstaclesCoo[passedObstacles] - 2f) //zona pressione tasto
        {
            //Debug.Log("Press E");
            int c = 0;
            foreach (Transform t in obstacles.transform)
            {
                if (c == passedObstacles)
                    t.GetChild(0).gameObject.SetActive(true);
                c++;
            }

            //binSprite.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("Hai premuto E sei un pazzo");
                jumpQTE = true;
                _jumpEnabled = true;
                clicked = true;
                //passedObstacles++;
            }
            //jumpQTE = true;
            //passedObstacles++;
        }
        else
        {
            int c = 0;
            foreach (Transform t in obstacles.transform)
            {
                if (c == passedObstacles)
                    t.GetChild(0).gameObject.SetActive(false);
                c++;
            }
        }
    }

    public void Restart()
    {
        dlgMng.GetComponent<DialogueManagerCap3_2>().startCorsa = true;
        tutorialCorsa.SetActive(true);

        _auxCount = 0;

        this.transform.position = startingPosition;
        qteVelocity = 0;
        passedObstacles = 0;

        foreach (Transform t in obstacles.transform)
            t.GetChild(0).gameObject.SetActive(false);

        //ragazzoController.Restart();
        //professoreController.Restart();

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetTargetDirection(Vector3 targetDirection)
    {
        this.targetDirection = targetDirection;
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
}