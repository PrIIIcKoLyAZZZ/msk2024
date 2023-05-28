using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thanks : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
