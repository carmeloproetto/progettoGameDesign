using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    private Animator _animator;
    private PlayerController_Agazio _pController; 

    private bool _isEnabled = true; 

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _pController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController_Agazio>(); 
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true && _isEnabled )
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets(); 
        }
    }

    void FindVisibleTargets()
    {
        //visibleTargets.Clear(); 
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for( int i = 0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if( Vector3.Angle(transform.forward, dirToTarget)< viewAngle / 2)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    if (_animator.GetBool("isLooking") || _animator.GetBool("isWalking"))
                    {
                        _animator.SetBool("isChasing", true);
                        //_pController.DisableInput();
                        //_pController.DisableJump();
                    }    
                }
            }
        }
    }


    public Vector3 DirFromAngle(float angleInDegree, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegree += transform.eulerAngles.y; 
        }
        return new Vector3(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
    }

    public void Attack()
    {
        Transform target = visibleTargets[0];
        target.GetComponent<Animator>().SetBool("isDying", true); 
    }

    public void TurningCorutine(float duration, Quaternion targetRotation)
    {
        StartCoroutine(TurnEnemy(duration, targetRotation));
    }

    IEnumerator TurnEnemy(float duration, Quaternion targetRotation)
    {
        float timeElapsed = 0;
        Quaternion startRotation = transform.rotation;
        while(timeElapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null; 
        }
        transform.rotation = targetRotation;
    }

    public void EnableFOV()
    {
        _isEnabled = true;
    }

    public void DisableFOV()
    {
        _isEnabled = false;
    }
}
