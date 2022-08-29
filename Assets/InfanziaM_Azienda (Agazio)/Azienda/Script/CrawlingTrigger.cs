using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrawlingTrigger : MonoBehaviour
{
    public GameObject player;
    public GameObject desk;
    private Animator animator;
    private PlayerController_Agazio _pController;
    [SerializeField] private float _timer; 

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
        _pController = player.GetComponent<PlayerController_Agazio>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _timer = 0f;
        if (other.gameObject.name == "PlayerArmature")
        {
            Debug.Log("enter");
            animator.SetBool("isDown", true);
            _pController.maxVelocity = 1f;
            _pController.DisableJump(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            Debug.Log("exit");
            animator.SetBool("isDown", false);
            desk.GetComponent<BoxCollider>().enabled = true;
            _pController.maxVelocity = 2f;
            _pController.EnableJump(); 
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            _timer += Time.deltaTime;
            if (_timer > 1f)
            {
                desk.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
