﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuCmds : MonoBehaviour
{
    static public string player1Control;
    static public string player2Control;
    public GameObject MainMenuFirst, OptionsFirst, CmdsPersoFirst, SelectCmdsPersoFirst;
    public Slider SliderTime, SliderHard;
    public TextMeshProUGUI txtDifficulty, txtTimeOfAGame;
    public void Start()
    {
        player1Control = "keyboard";
        player2Control = "keyboard";
        
        float timeGame = PlayerPrefs.GetFloat("timeGame");
        if (timeGame != 0)
        {
            MoveSliderTime(timeGame);
            SliderTime.value = timeGame;
        }
        else
        {
            MoveSliderTime(30);
            SliderTime.value = 30;
        }

        string niv = PlayerPrefs.GetString("diff");
        if (niv == "Difficile")
        {
            MoveSliderDiff(1);
            SliderHard.value = 1;
        }
        else
        {
            MoveSliderDiff(0);
            SliderHard.value = 0;
        }

        PlayerManager.useSuperAI = true;
        StartMainMenu();
    }

    public void StartOnePlayer()
    {
        PlayerManager.useAIasPlayerB = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void StartTwoPlayers()
    {
        PlayerManager.useAIasPlayerB = false;
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

    public void MoveSliderDiff(float difficulty)
    {
        if (difficulty == 0f)
        {
            txtDifficulty.text = "Facile";
            PlayerManager.superAIHard = false;
            PlayerPrefs.SetString("diff", "Facile");
        }
        else
        {
            txtDifficulty.text = "Difficile";
            PlayerManager.superAIHard = true;
            PlayerPrefs.SetString("diff", "Difficile");
        }
    }
    
    public void MoveSliderTime(float time)
    {
        PlayerPrefs.SetFloat("timeGame", time);
        txtTimeOfAGame.text = time.ToString() + " secondes";
        GameLoop.timerValue = time;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void setPlayer1Control(int control) 
    {
        if (control == 0)
        {
            player1Control = "keyboard";
        }
        else
        {
            player1Control = "controller";
        }
    }
    public void setPlayer2Control(int control) 
    {
        if (control == 0)
        {
            player2Control = "keyboard";
        }
        else
        {
            player2Control = "controller";
        }
    }
}
