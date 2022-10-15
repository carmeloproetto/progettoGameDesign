using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private Animator _dadAnimator;
    public Transform ragazzo; 
    public Transform target_1;
    public Transform target_2;
    public int targetCount = 0; 

    // Start is called before the first frame update
    void Start()
    {
        _dadAnimator = this.GetComponent<Animator>();
    }

    public void Move()
    {
        this.GetComponent<CharacterController>().enabled = false;
        if( targetCount == 0)
        {
            transform.DOMove(new Vector3(target_1.position.x, transform.position.y, target_1.position.z), 2f).OnComplete(() => { _dadAnimator.SetBool("Move", false); });
            targetCount++;
        }
        else
        {
            transform.DOMove(new Vector3(target_2.position.x, transform.position.y, target_2.position.z), 2f).OnComplete(() => { _dadAnimator.SetBool("Move", false); });
            targetCount++;
        }
    }

    private void Update()
    {
        if( _dadAnimator.GetBool("Move") )
        {
            transform.LookAt(ragazzo);
        }
    }
}
