using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLocation : MonoBehaviour
{
    [SerializeField] private int _level;
    [SerializeField] private GameObject _PressFtext;
    private void OnCollisionStay(Collision player)
    {
        if (player.transform.tag == "Player")
        {
            _PressFtext.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                _PressFtext.SetActive(false);
                Application.LoadLevel(_level + 1);
            }
        }
    }
}
