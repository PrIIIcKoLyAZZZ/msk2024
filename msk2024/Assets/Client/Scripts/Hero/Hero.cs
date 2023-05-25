using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Surv
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private Animator _animator;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                //_animator.SetTrigger("is-dead");
                Time.timeScale = 0;
            }
        }
    }
}
