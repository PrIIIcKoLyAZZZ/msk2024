using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _loaderScrean;
    [SerializeField] private Image _progressBar;
    [SerializeField] private GameObject _authors;
    private bool _authorsActive = false;
    private float _target;

    private AsyncOperation loadingSceneOperation;

    public async void PlayGame()
    {
        _loaderScrean.SetActive(true);
        
        loadingSceneOperation =
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        loadingSceneOperation.allowSceneActivation = false;
        
        _progressBar.fillAmount = 0;
        _target = 0;

        do
        {
            await Task.Delay(100);
            _target = loadingSceneOperation.progress;
        } while (loadingSceneOperation.isDone);

        await Task.Delay(10000);

        loadingSceneOperation.allowSceneActivation = true;
        _loaderScrean.SetActive(false);
    }

    public void Authors()
    {
        _authorsActive = !_authorsActive;
        _authors.SetActive(_authorsActive);
    }

    private void Update()
    {
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target, Time.deltaTime);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
