using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Surv
{
    public class HeroMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        public float directionZ;
        public float directionX;
        public float directionRotate;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Vector3 force = new Vector3(directionX, 0, directionZ) * _moveSpeed;
            _rigidbody.AddRelativeForce(force);
        }
    }
}
