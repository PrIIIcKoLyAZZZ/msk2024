using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _cameraSpeed;
    [SerializeField] float speed = 20.0f;
    public float rotateDirection;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        transform.position = _target.position;
        transform.rotation = _target.rotation;
    }
}
