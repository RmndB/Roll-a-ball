using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    [SerializeField]
    private AudioSource menu = default;
    [SerializeField]
    private AudioSource inGame = default;
    [SerializeField]
    private AudioSource coin = default;
    [SerializeField]
    private AudioSource jump = default;
    [SerializeField]
    private AudioSource tick = default;
    [SerializeField]
    private AudioSource timer = default;
    [SerializeField]
    private AudioSource jingleWin = default;
    [SerializeField]
    private AudioSource jingleLose = default;

    private float maxBackgroundVolume;
    private float maxSoundVolume;
    private float maxFoleyVolume;
    private float fadingSpeed = 0.005f;

    void Start()
    {
        if (!PlayerPrefs.HasKey("SoundVolume") || !PlayerPrefs.HasKey("BackVolume") || !PlayerPrefs.HasKey("FoleyVolume"))
        {
            PlayerPrefs.SetFloat("SoundVolume", 0.5f);
            PlayerPrefs.SetFloat("BackVolume", 0.7f);
            PlayerPrefs.SetFloat("FoleyVolume", 0.6f);
        }

        maxBackgroundVolume = PlayerPrefs.GetFloat("BackVolume");
        maxSoundVolume = PlayerPrefs.GetFloat("SoundVolume");
        maxFoleyVolume = PlayerPrefs.GetFloat("FoleyVolume");
        
        if (!menu.isPlaying) {
            menu.Play();
            menu.volume = maxBackgroundVolume;
        }
        inGame.Play();
        inGame.volume = 0;
    }

    public void Update()
    {
        maxBackgroundVolume = PlayerPrefs.GetFloat("BackVolume");
        maxSoundVolume = PlayerPrefs.GetFloat("SoundVolume");
        maxFoleyVolume = PlayerPrefs.GetFloat("FoleyVolume");
        
        menu.volume = maxBackgroundVolume;
        inGame.volume = maxBackgroundVolume;
    }

    public void playCoinSound() {
        maxSoundVolume = PlayerPrefs.GetFloat("SoundVolume");
        coin.volume = maxSoundVolume;
        coin.Play();
    }

    public void playJumpSound()
    {
        maxSoundVolume = PlayerPrefs.GetFloat("SoundVolume");
        jump.volume = maxSoundVolume;
        jump.Play();
    }

    public void playTickSound()
    {
        maxFoleyVolume = PlayerPrefs.GetFloat("FoleyVolume");
        tick.volume = maxFoleyVolume;
        tick.Play();
    }

    public void playTimerFoley()
    {
        maxFoleyVolume = PlayerPrefs.GetFloat("FoleyVolume");
        timer.volume = maxFoleyVolume;
        if (!timer.isPlaying)
        {
            timer.Play();
        }
    }

    public void playWinJingle()
    {
        maxFoleyVolume = PlayerPrefs.GetFloat("FoleyVolume");
        jingleWin.volume = maxFoleyVolume;
        if (timer.isPlaying)
        {
            timer.Stop();
        }
        jingleWin.Play();
    }

    public void playLoseJingle()
    {
        maxFoleyVolume = PlayerPrefs.GetFloat("FoleyVolume");
        jingleLose.volume = maxFoleyVolume;
        if (timer.isPlaying)
        {
            timer.Stop();
        }
        jingleLose.Play();
    }

    private void goToMenu() {
        StartCoroutine(FadeIn(menu));
        StartCoroutine(FadeOut(inGame));
    }

    private void goToGame()
    {
        StartCoroutine(FadeIn(inGame));
        StartCoroutine(FadeOut(menu));
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        if (scene.name == "SampleScene")
        {
            goToGame();
        }
        else if (scene.name == "Menu")
        {
            goToMenu();
        }
    }

    private IEnumerator FadeIn(AudioSource audio) {
        maxBackgroundVolume = PlayerPrefs.GetFloat("BackVolume");
        while (audio.volume < maxBackgroundVolume) {
            audio.volume += fadingSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator FadeOut(AudioSource audio)
    {
        while (audio.volume > 0)
        {
            audio.volume -= fadingSpeed;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
