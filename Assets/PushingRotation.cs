using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingRotation : MonoBehaviour
{
    private Animator _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( _player.GetFloat("Speed") != 0f && _player.GetBool("isPushing") )
        {
            transform.Rotate(Vector3.up * -30f * _player.GetFloat("Speed") * Time.deltaTime);
        } 
    }
}
