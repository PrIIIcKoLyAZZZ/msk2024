using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Surv;
using UnityEngine;

namespace Surv
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _range;

        [SerializeField] private Hero _hero;
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private float _thicknessShots;
        [SerializeField] private LayerMask _layermask;

        [SerializeField] private AudioSource _shootSound;
        
        RaycastHit hit;
        Vector3 center;
        Vector3 halfExtents;

        private bool temp;

        public void Shooting()
        {
            _shootSound.Play();
            _animator.SetTrigger("is-shooting");
            _particle.Play();
            center = _hero.transform.position + _hero.transform.forward.normalized * _range / 2;
            halfExtents = new Vector3(_thicknessShots, _range, _range / 2);
            
            RaycastHit[] hits = Physics.BoxCastAll(center, halfExtents, _hero.transform.forward,
                _hero.transform.rotation, _range, _layermask);
            foreach (var e in hits)
            {
                e.transform.GetComponent<Target>()?.TakeDamage(_damage);
            }
        }
        
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (temp)
        {
            Debug.Log("popoal");
            Gizmos.DrawRay(_hero.transform.position, _hero.transform.forward * _range / 2);
            Gizmos.DrawWireCube(_hero.transform.position + _hero.transform.forward * _range / 2, halfExtents * 2);
        }
        else
        {
            Gizmos.DrawRay(_hero.transform.position, _hero.transform.forward * _range / 2);
            Gizmos.DrawWireCube(_hero.transform.position + _hero.transform.forward * _range / 2, halfExtents * 2);
        }
    }
    #endif
    }
}

