using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    
    IEnumerator AddSound()
    {
        for(int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(2);
            _audio.volume += 0.005f;
        }
    }

    private void Start()
    {
        StartCoroutine(AddSound());
    }
}
