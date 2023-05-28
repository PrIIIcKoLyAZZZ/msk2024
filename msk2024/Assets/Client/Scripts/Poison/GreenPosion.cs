using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPosion : MonoBehaviour
{
    [SerializeField] private GameObject _this;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(_this);
        }
    }
}
