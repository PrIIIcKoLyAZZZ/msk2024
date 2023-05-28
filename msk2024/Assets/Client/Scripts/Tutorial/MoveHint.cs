using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveHint : MonoBehaviour
{
    [SerializeField] private GameObject _image;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {   
            _image.SetActive(true);
            StartCoroutine(HideHint());
        }
    }
    
    IEnumerator HideHint()
    {
        yield return new WaitForSeconds(5);
        _image.SetActive(false);
    }

}
