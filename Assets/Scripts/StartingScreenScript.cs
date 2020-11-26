using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingScreenScript : MonoBehaviour
{
    private float _progressTime;
    private float _timeToWait = 3;
    // Start is called before the first frame update
    void Start()
    {
        _progressTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _progressTime += Time.deltaTime;
        var deltaTime = _progressTime / _timeToWait;

        if (deltaTime >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
