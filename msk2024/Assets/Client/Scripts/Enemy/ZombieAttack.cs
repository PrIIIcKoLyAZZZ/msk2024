using System;
using System.Collections;
using System.Collections.Generic;
using Surv;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator ;
    [SerializeField] private int _damage;
    [SerializeField] private float _whenDamadge;
    private Target _we;
    private float animationDuration = 1.5f;

    private bool isHit;
    private float time;

    private void Awake()
    {
        _we = GetComponent<Target>();
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if(_we.isDead == false)
        {
            Hero hero = other.GetComponentInParent<Hero>();
            if (hero != null && time > animationDuration)
            {
                //Debug.Log(hero);
                _animator.SetTrigger("is-attack");
                isHit = false;
                time = 0;
            }

            if (hero != null && time < animationDuration && time > _whenDamadge && isHit == false)
            {
                hero.TakeDamage(_damage);
                isHit = true;
            }
        }
    }
}
