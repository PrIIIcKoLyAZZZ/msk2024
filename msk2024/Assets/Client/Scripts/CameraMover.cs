using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed;
    public float rotateDirection;

    private void LateUpdate()
    {
        transform.position = _target.position;
        transform.Rotate(0, rotateDirection * _cameraSpeed, 0);
    }
}
