using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    private float _timeToWait = 4;
    private float _progressTime;
    [SerializeField]
    private Image _progressBar = default;
    public void Start()
    {
        _progressTime = 0;
    }

    public void Update()
    {
        _progressTime += Time.deltaTime;
        var deltaTime = _progressTime / _timeToWait;

        if (deltaTime >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            _progressBar.fillAmount = deltaTime;
        }
    }
}
