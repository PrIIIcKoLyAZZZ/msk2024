using System;
using System.Collections;
using System.Collections.Generic;
using Surv;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider _trigger;
    [SerializeField] private Animator _animator ;
    [SerializeField] private int _damage;

    private bool isHit;

    private float time;
    private void Awake()
    {
        _trigger = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        Hero hero = other.GetComponentInParent<Hero>();
        if (hero != null && time > 1.5)
        {
            Debug.Log(hero);
            _animator.SetTrigger("is-attack");
            isHit = false;
            time = 0;
        }

        if (hero != null && time < 1.5 && time > 0.5 && isHit == false)
        {
            hero.TakeDamage(_damage);
            isHit = true;
        }
    }
}
