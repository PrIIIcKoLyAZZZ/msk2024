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
        [SerializeField] private Camera heroCamera;
        [SerializeField] private Shoot _shoot;
        [SerializeField] private AudioSource _walkSound;
 
        public float directionZ;
        public float directionX;
        public Vector3 mousePosition;
        private int _canMove = 1;
        private Vector3 absMousePosition;

        private Rigidbody _rigidbody;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private Quaternion getAngleToCursore()
        {
            mousePosition.z = 10;
            absMousePosition =  heroCamera.ScreenToWorldPoint(mousePosition);
            Vector3 lookDir = absMousePosition - _rigidbody.position;
            float angle = Mathf.Atan2(lookDir.z, lookDir.x) * Mathf.Rad2Deg - 90f;
            return Quaternion.Euler(0, -angle, 0);
        }

        IEnumerator MakeCanMove()
        {
            yield return new WaitForSeconds(_durationShooting);
            _canMove = 1;
        }

        public void Shooting()
        {
            _canMove = 0;
            _shoot.Shooting();
            StartCoroutine(MakeCanMove());
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
            
             _rigidbody.rotation = getAngleToCursore();
        }
    }
}
