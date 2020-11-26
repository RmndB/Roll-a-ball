using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject PauseMenuFirst;
    public GameObject pauseMenu;
    public GameObject victoryMenu;
    public GameObject VictoryMenuFirst;
    
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!gamePaused)
            {
                PauseTheGame();
            }
        }
    }

    public void PauseTheGame()
    {
        pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(PauseMenuFirst);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void ResumeTheGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void QuitCurrentGame()
    {
        Time.timeScale = 1f;
        gamePaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
