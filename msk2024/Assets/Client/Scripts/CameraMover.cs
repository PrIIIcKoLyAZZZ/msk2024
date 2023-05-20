using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private Vector3 offset = new Vector3(0, 8, -4);

    private void LateUpdate()
    {
        transform.position = _target.position + offset;
    }
}
