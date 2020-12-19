using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersoCmdMenu : MonoBehaviour
{
    private Event _keyEvent;
    private TextMeshProUGUI _text;
    private KeyCode _keyCode;
    private bool _waitForUserToPressKey;
    private bool isQWERTY;

    [SerializeField]
    private int player = default;
    [SerializeField]
    private List<TextMeshProUGUI> textButtons = default;
    
    // Start is called before the first frame update
    void Start()
    {
        isQWERTY = true;
        TextMeshProUGUI qwertyTxt = GameObject.Find("qwerty_txt").GetComponent<TextMeshProUGUI>();
        qwertyTxt.text = "QWERTY";
        
        _waitForUserToPressKey = false;

        for (int i = 0; i < textButtons.Count; i++)
        {
            textButtons[i].text =  (getControlsMngCorrespondingString(textButtons[i].name));
        }
    }

    private void OnGUI()
    {
        _keyEvent = Event.current;
        if (_keyEvent.isKey && _waitForUserToPressKey)
        {
            _keyCode = _keyEvent.keyCode;
            _waitForUserToPressKey = false;
        }
    }

    public void setTextToButton(TextMeshProUGUI textToSet)
    {
        _text = textToSet;
    }

    public void waitWhileUserSelectKey(string name)
    {
        if (!_waitForUserToPressKey)
        {
            StartCoroutine(bindKey(name));
        }
    }

    private string getControlsMngCorrespondingString(string name)
    {
        string controlMngString = "";
        if (player == 1)
        {
            switch (name)
            {
                case "btn_avancer_txt":
                    controlMngString = ControlsManager.ControlMng.forwardP1.ToString();
                    break;
                case "btn_reculer_txt":
                    controlMngString = ControlsManager.ControlMng.backwardP1.ToString();
                    break;
                case "btn_droite_txt":
                    controlMngString = ControlsManager.ControlMng.rightP1.ToString();
                    break;
                case "btn_gauche_txt":
                    controlMngString = ControlsManager.ControlMng.leftP1.ToString();
                    break;
                case "btn_jump_txt":
                    controlMngString = ControlsManager.ControlMng.jumpP1.ToString();
                    break;
                case "btn_pause_txt":
                    controlMngString = ControlsManager.ControlMng.pauseP1.ToString();
                    break;
            }
        }
        else if (player == 2)
        {
            switch (name)
            {
                case "btn_avancer_txt":
                    controlMngString = ControlsManager.ControlMng.forwardP2.ToString();
                    break;
                case "btn_reculer_txt":
                    controlMngString = ControlsManager.ControlMng.backwardP2.ToString();
                    break;
                case "btn_droite_txt":
                    controlMngString = ControlsManager.ControlMng.rightP2.ToString();
                    break;
                case "btn_gauche_txt":
                    controlMngString = ControlsManager.ControlMng.leftP2.ToString();
                    break;
                case "btn_jump_txt":
                    controlMngString = ControlsManager.ControlMng.jumpP2.ToString();
                    break;
                case "btn_pause_txt":
                    controlMngString = ControlsManager.ControlMng.pauseP2.ToString();
                    break;
            }
        }
        return controlMngString;
    }

    IEnumerator waitKeyPress()
    {
        while (!_keyEvent.isKey)
        {
            yield return null;
        }
    }

    public IEnumerator bindKey(string name)
    {
        _waitForUserToPressKey = true;
        yield return waitKeyPress();
        modifKeyParams(name);
    }

    public void modifKeyParams(string name)
    {
        if (player == 1)
        {
            switch (name)
            {
                case "avancer":
                    ControlsManager.ControlMng.forwardP1 = _keyCode;
                    _text.text = ControlsManager.ControlMng.forwardP1.ToString();
                    PlayerPrefs.SetString("forwardKeyP1", ControlsManager.ControlMng.forwardP1.ToString());
                    break;
                case "reculer":
                    ControlsManager.ControlMng.backwardP1 = _keyCode;
                    _text.text = ControlsManager.ControlMng.backwardP1.ToString();
                    PlayerPrefs.SetString("backwardKeyP1", ControlsManager.ControlMng.backwardP1.ToString());
                    break;
                case "droite":
                    ControlsManager.ControlMng.rightP1 = _keyCode;
                    _text.text = ControlsManager.ControlMng.rightP1.ToString();
                    PlayerPrefs.SetString("rightKeyP1", ControlsManager.ControlMng.rightP1.ToString());
                    break;
                case "gauche":
                    ControlsManager.ControlMng.leftP1 = _keyCode;
                    _text.text = ControlsManager.ControlMng.leftP1.ToString();
                    PlayerPrefs.SetString("leftKeyP1", ControlsManager.ControlMng.leftP1.ToString());
                    break;
                case "jump":
                    ControlsManager.ControlMng.jumpP1 = _keyCode;
                    _text.text = ControlsManager.ControlMng.jumpP1.ToString();
                    PlayerPrefs.SetString("jumpKeyP1", ControlsManager.ControlMng.jumpP1.ToString());
                    break;
                case "pause":
                    ControlsManager.ControlMng.pauseP1 = _keyCode;
                    _text.text = ControlsManager.ControlMng.pauseP1.ToString();
                    PlayerPrefs.SetString("pauseKeyP1", ControlsManager.ControlMng.pauseP1.ToString());
                    break;
            }
        }
        else if(player == 2)
        {
            switch (name)
            {
                case "avancer":
                    ControlsManager.ControlMng.forwardP2 = _keyCode;
                    _text.text = ControlsManager.ControlMng.forwardP2.ToString();
                    PlayerPrefs.SetString("forwardKeyP2", ControlsManager.ControlMng.forwardP2.ToString());
                    break;
                case "reculer":
                    ControlsManager.ControlMng.backwardP2 = _keyCode;
                    _text.text = ControlsManager.ControlMng.backwardP2.ToString();
                    PlayerPrefs.SetString("backwardKeyP2", ControlsManager.ControlMng.backwardP2.ToString());
                    break;
                case "droite":
                    ControlsManager.ControlMng.rightP2 = _keyCode;
                    _text.text = ControlsManager.ControlMng.rightP2.ToString();
                    PlayerPrefs.SetString("rightKeyP2", ControlsManager.ControlMng.rightP2.ToString());
                    break;
                case "gauche":
                    ControlsManager.ControlMng.leftP2 = _keyCode;
                    _text.text = ControlsManager.ControlMng.leftP2.ToString();
                    PlayerPrefs.SetString("leftKeyP2", ControlsManager.ControlMng.leftP2.ToString());
                    break;
                case "jump":
                    ControlsManager.ControlMng.jumpP2 = _keyCode;
                    _text.text = ControlsManager.ControlMng.jumpP2.ToString();
                    PlayerPrefs.SetString("jumpKeyP2", ControlsManager.ControlMng.jumpP2.ToString());
                    break;
                case "pause":
                    ControlsManager.ControlMng.pauseP2 = _keyCode;
                    _text.text = ControlsManager.ControlMng.pauseP2.ToString();
                    PlayerPrefs.SetString("pauseKeyP2", ControlsManager.ControlMng.pauseP2.ToString());
                    break;
            }
        }
    }

    public void backToDefault()
    {
        _keyCode = KeyCode.W;
        _text = GameObject.Find("btn_avancer_txt").GetComponent<TextMeshProUGUI>();
        modifKeyParams("avancer");
        _keyCode = KeyCode.S;
        _text = GameObject.Find("btn_reculer_txt").GetComponent<TextMeshProUGUI>();
        modifKeyParams("reculer");
        _keyCode = KeyCode.A;
        _text = GameObject.Find("btn_gauche_txt").GetComponent<TextMeshProUGUI>();
        modifKeyParams("gauche");
        _keyCode = KeyCode.D;
        _text = GameObject.Find("btn_droite_txt").GetComponent<TextMeshProUGUI>();
        modifKeyParams("droite");
        _keyCode = KeyCode.P;
        _text = GameObject.Find("btn_pause_txt").GetComponent<TextMeshProUGUI>();
        modifKeyParams("pause");
        _keyCode = KeyCode.Space;
        _text = GameObject.Find("btn_jump_txt").GetComponent<TextMeshProUGUI>();
        modifKeyParams("jump");
    }
    public void switchAsertyQwerty()
    {
        if (isQWERTY)
        { 
            TextMeshProUGUI qwertyTxt = GameObject.Find("qwerty_txt").GetComponent<TextMeshProUGUI>();
            qwertyTxt.text = "AZERTY";
            
            _keyCode = KeyCode.Z;
            _text = GameObject.Find("btn_avancer_txt").GetComponent<TextMeshProUGUI>();
            modifKeyParams("avancer");
            _keyCode = KeyCode.S;
            _text = GameObject.Find("btn_reculer_txt").GetComponent<TextMeshProUGUI>();
            modifKeyParams("reculer");
            _keyCode = KeyCode.Q;
            _text = GameObject.Find("btn_gauche_txt").GetComponent<TextMeshProUGUI>();
            modifKeyParams("gauche");
            _keyCode = KeyCode.D;
            _text = GameObject.Find("btn_droite_txt").GetComponent<TextMeshProUGUI>();
            modifKeyParams("droite");
            _keyCode = KeyCode.P;
            _text = GameObject.Find("btn_pause_txt").GetComponent<TextMeshProUGUI>();
            modifKeyParams("pause");
            _keyCode = KeyCode.Space;
            _text = GameObject.Find("btn_jump_txt").GetComponent<TextMeshProUGUI>();
            modifKeyParams("jump");
            
            isQWERTY = false;
            return;
        }
        else
        {
            backToDefault();
            TextMeshProUGUI qwertyTxt = GameObject.Find("qwerty_txt").GetComponent<TextMeshProUGUI>();
            qwertyTxt.text = "QWERTY";
            isQWERTY = true;
        }
    }
}
