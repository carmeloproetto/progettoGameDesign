using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallInteraction : MonoBehaviour
{
    public GameObject player;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            animator.SetBool("isNearTheWall", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            animator.SetBool("isNearTheWall", false);
        }
    }

}
