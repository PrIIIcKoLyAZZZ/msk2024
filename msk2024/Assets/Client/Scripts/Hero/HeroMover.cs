using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Surv
{
    public class HeroMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _durationShooting;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Camera heroCamera;
        [SerializeField] private Shoot _shoot;
        [SerializeField] private AudioSource _walkSound;
 
        public float directionZ;
        public float directionX;
        public float mousePosition;
        private int _canMove = 1;
        private Vector3 absMousePosition;

        private Rigidbody _rigidbody;
        private Animator _animator;
        private float _standartMoveSpeed;

        private void Awake()
        {
            _standartMoveSpeed = _moveSpeed;
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        IEnumerator StopSpeedBonus()
        {
            yield return new WaitForSeconds(5);
            _moveSpeed = _standartMoveSpeed;
        }
        
        public void UpMoveSpeed()
        {
            _moveSpeed *= 2;
            StartCoroutine(StopSpeedBonus());
        }

        IEnumerator MakeCanMove()
        {
            yield return new WaitForSeconds(_durationShooting);
            _canMove = 1;
        }

        public void Shooting()
        {
            if(Time.timeScale != 0)
            {
                _canMove = 0;
                _shoot.Shooting();
                StartCoroutine(MakeCanMove());
            }
        }

        private void FixedUpdate()
        {
            Vector3 force = new Vector3(directionX, 0, directionZ) * (_moveSpeed * _canMove);
            _animator.SetBool("is-running", directionX != 0 || directionZ != 0);
            if(directionX != 0 || directionZ != 0)
            {
                if(_walkSound.loop == false)
                    _walkSound.Play();
                _walkSound.loop = true;
            }
            else
            {
                _walkSound.Stop();
                _walkSound.loop = false;
            }
            
            _rigidbody.AddRelativeForce(force);
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.y + mousePosition * _rotationSpeed, 0);
        }
    }
}
