using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] public int _level;
    [SerializeField] public GameObject _pauseMenuUI;
    private static bool _isGamePaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _isGamePaused = true;
        Cursor.visible = true;
    }

    public void resume()
    {
        Cursor.visible = false;
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _isGamePaused = false;
    }

    public void restart()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(_level);
    }

    public void loadMenu()
    {
        Time.timeScale = 1f;
        //TODO 
    }
}
