using System;
using System.Collections;
using System.Collections.Generic;
using Surv;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)]
    public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Hero _hero;
    [SerializeField] private float _forceMove;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }
    
    private Quaternion getAngleToHero()
    {
        Vector3 lookDir = _hero.transform.position - _rigidbody.position;
        float angle1 = Mathf.Atan2(lookDir.z, lookDir.x) * Mathf.Rad2Deg - 90f;
        return Quaternion.Euler(0, -angle1, 0);
    }

    private void FixedUpdate()
    {
        if(canSeePlayer)
            _rigidbody.rotation = getAngleToHero();
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    canSeePlayer = true;
                    _rigidbody.rotation = getAngleToHero();
                    _rigidbody.AddRelativeForce(Vector3.forward * _forceMove);
                    _animator.SetBool("is-walking", true);
                }
                else
                {
                    canSeePlayer = false;
                    _animator.SetBool("is-walking",  false);
                }
            }
            else
            {
                canSeePlayer = false;
                _animator.SetBool("is-walking",  false);
            }
        }
        else if (canSeePlayer)
        {
            canSeePlayer = false;
            _animator.SetBool("is-walking",  false);
        }
    }
}