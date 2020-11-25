using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public static ControlsManager ControlMng;

    public KeyCode forwardP1 {get; set;}
    public KeyCode backwardP1 {get; set;}
    public KeyCode leftP1 {get; set;}
    public KeyCode rightP1 {get; set;}
    public KeyCode jumpP1 {get; set;}
    public KeyCode pauseP1 {get; set;}
    public KeyCode forwardP2 {get; set;}
    public KeyCode backwardP2 {get; set;}
    public KeyCode leftP2 {get; set;}
    public KeyCode rightP2 {get; set;}
    public KeyCode jumpP2 {get; set;}
    
    public KeyCode pauseP2 {get; set;}

    private void Awake()
    {
        if (ControlMng == null)
        {
            DontDestroyOnLoad(gameObject);
            ControlMng = this;
        }
        else if(ControlMng != this)
        {
            Destroy(gameObject);
        }
        
        forwardP1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKeyP1", "W"));
        backwardP1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKeyP1", "S"));
        leftP1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKeyP1", "A"));
        rightP1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKeyP1", "D"));
        jumpP1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKeyP1", "Space"));
        pauseP1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKeyP1", "Escape"));
        forwardP2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKeyP2", "UpArrow"));
        backwardP2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKeyP2", "DownArrow"));
        leftP2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKeyP2", "LeftArrow"));
        rightP2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKeyP2", "RightArrow"));
        jumpP2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKeyP2", "KeypadEnter"));
        pauseP2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKeyP2", "P"));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
