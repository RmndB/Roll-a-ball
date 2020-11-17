using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCmds : MonoBehaviour
{
    public void StartOnePlayer()
    {        

    }
    
    public void StartTwoPlayers()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {        
        Debug.Log("Quit !!!!!");
        Application.Quit();
    }
    
    public void QuitCurrentGame()
    {        
        Debug.Log("Quit Current Game!!!!!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + -1);
    }
}
