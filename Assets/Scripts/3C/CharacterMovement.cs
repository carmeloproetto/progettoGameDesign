using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float m_MovementSpeed = 1.0f;
    [SerializeField]
    private Transform m_CameraTransform;

    private CharacterController m_CharacterController;

    private Animator _animator;
    private Vector3 _inputVector;
    private float _inputSpeed;


    private void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 forward = (transform.position - m_CameraTransform.position).normalized;
        forward.y = 0;
        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

        float moveAxisX = m_MovementSpeed * Input.GetAxis("Horizontal");
        //  float moveAxisY = m_MovementSpeed * Input.GetAxis("Vertical");

        /*if(VirtualInputManager.Instance.MoveRight && VirtualInputManager.Instance.MoveLeft){
            return;
        }*/

        float h = Input.GetAxis("Horizontal");
        _inputVector = new Vector3(h, 0, 0);
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);
        UpdateAnimations();

        //rotazione personaggio
        if(VirtualInputManager.Instance.MoveRight){
            // this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            
        }

        //rotazione personaggio
        if(VirtualInputManager.Instance.MoveLeft){
            // this.gameObject.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }


        Vector3 movement = /*forward * moveAxisY +*/ right * moveAxisX;

        m_CharacterController.Move(movement);


    }

     private void UpdateAnimations()
    {
        _animator.SetFloat("speed", _inputSpeed);
    }
}
