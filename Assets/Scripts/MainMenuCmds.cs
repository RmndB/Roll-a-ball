using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuCmds : MonoBehaviour
{
    public GameObject mainMenu, optionMenu, cmdsPersoMenu, selectCmdsPersoMenu;
    public GameObject MainMenuFirst, OptionsFirst, CmdsPersoFirst, SelectCmdsPersoFirst;

    public void Start()
    {
        StartMainMenu();
    }

    public void StartOnePlayer()
    {
        PlayerManager.useAIasPlayerB = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void StartTwoPlayers()
    {
        PlayerManager.useAIasPlayerB = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void StartMainMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(MainMenuFirst);
    }
    public void StartOptions()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OptionsFirst);
    }
    
    public void StartCmdsPerso()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(CmdsPersoFirst);
    }
    
    public void StartSelectCmdsPerso()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(SelectCmdsPersoFirst);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
