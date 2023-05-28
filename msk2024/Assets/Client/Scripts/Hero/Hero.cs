using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Surv
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _deadScrean;

        private int _standartHP;

        private void Start()
        {
            _standartHP = _health;
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Time.timeScale = 0;
                _deadScrean.SetActive(true);
                Cursor.visible = true;
            }
        }

        public void RefrashHealth()
        {
            _health = _standartHP;
        }
    }
}
