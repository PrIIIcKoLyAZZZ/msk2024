using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private GameObject _this;
    private void OnTriggerEnter(Collider other)
    {
        Inventory inv = other.GetComponentInParent<Inventory>();
        if(inv != null)
        {
            inv.AddItems(_name);
            Destroy(_this);
        }
    }
}
