using System.Collections;
using System.Collections.Generic;
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

        public void Shooting()
        {
            _animator.SetTrigger("is-shooting");
            _particle.Play();
            RaycastHit hit;
            if (Physics.Raycast(_hero.transform.position, _hero.transform.forward, out hit, _range))
            {
                hit.transform.GetComponent<Target>()?.TakeDamage(_damage);
            }
        }
    }
}

