using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject enemy;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        enemy.GetComponent<Animator>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.name == "PlayerAramture")
        {
            _animator.SetTrigger("turnFront");
        }
    }
}
