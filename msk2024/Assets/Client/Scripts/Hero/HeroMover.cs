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
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private Camera heroCamera;
        [SerializeField] private Shoot _shoot;
 
        public float directionZ;
        public float directionX;
        public Vector3 mousePosition;
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

        public void Shooting()
        {
            _shoot.Shooting();
        }

        private void FixedUpdate()
        {
            Vector3 force = new Vector3(directionX, 0, directionZ) * _moveSpeed;
            _animator.SetBool("is-running", directionX != 0 || directionZ != 0);
            _rigidbody.AddRelativeForce(force);
            
             _rigidbody.rotation = getAngleToCursore();
        }
    }
}
