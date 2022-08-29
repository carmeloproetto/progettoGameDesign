using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class MoveToDestinationTrigger : MonoBehaviour
{
    //public bool canMoveForward = true;
    public GameObject destination;
    private PlayerController_Agazio _pController;
    public GameObject player;
    private bool destinationReached = false;
    public GameObject enemy; 
    
    // Start is called before the first frame update
    void Start()
    {
        _pController = player.GetComponent<PlayerController_Agazio>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (player.transform.position - destination.transform.position).magnitude;
        if( distance < .1f && !destinationReached )
        {
            destinationReached = true; 
            _pController.IsMoving(false);
            player.transform.DORotate(new Vector3(0, 90f, 0), 1f);
            _pController.SetTargetDirection(Vector3.right);
            _pController._isRightForward = true;
            _pController.EnableInput();
            _pController.EnableJump();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.name == "PlayerArmature" )
        {
            //disable enemy's field of view
            enemy.GetComponent<FieldOfView>().DisableFOV();
            Transform playerTransform = other.GetComponent<Transform>();

            //ruota direzione forward verso lo schermo
            _pController.DisableInput();
            _pController.DisableJump();
            playerTransform.DORotate(new Vector3(0, 180f, 0), 1f);
            _pController.SetTargetDirection(Vector3.back);

            //muovi in avanti
            _pController.IsMoving(true);
            playerTransform.DOMove(destination.transform.position, 4f);
        }
    }
}
