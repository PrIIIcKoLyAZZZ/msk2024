using System;
using System.Collections;
using System.Collections.Generic;
using Surv;
using UnityEngine;

public class RedPoison : MonoBehaviour
{
    [SerializeField] private GameObject _this; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<Hero>().RefrashHealth();
            Destroy(_this);
        }
    }
}
