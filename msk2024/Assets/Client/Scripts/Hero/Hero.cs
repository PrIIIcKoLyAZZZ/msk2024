using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Surv
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private int _health;
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                //
            }
        }
    }
}
