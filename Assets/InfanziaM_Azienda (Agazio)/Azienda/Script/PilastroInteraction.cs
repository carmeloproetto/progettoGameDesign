using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilastroInteraction : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy; 
    private Animator playerAnimator;
    private Animator enemyAnimator; 


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        enemyAnimator = enemy.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            playerAnimator.SetBool("isNearTheWall", true);
            enemyAnimator.SetTrigger("canWalk");
            //FindObjectOfType<AudioManager>().Stop("angryCrowd"); 
            StartCoroutine(FindObjectOfType<AudioManager>().FadeOut("angryCrowd", 3f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            playerAnimator.SetBool("isNearTheWall", false);
        }
    }
}
