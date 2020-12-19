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

    private float maxBackgroundVolume = 0.7f;
    private float maxSoundVolume = 0.5f;
    private float maxFoleyVolume = 0.6f;
    private float fadingSpeed = 0.005f;

    void Start()
    {
        if (!menu.isPlaying) {
            menu.Play();
            menu.volume = maxBackgroundVolume;
        }
        inGame.Play();
        inGame.volume = 0;
    }

    public void playCoinSound() {
        coin.volume = maxSoundVolume;
        coin.Play();
    }

    public void playJumpSound()
    {
        jump.volume = maxSoundVolume;
        jump.Play();
    }

    public void playTickSound()
    {
        tick.volume = maxFoleyVolume;
        tick.Play();
    }

    public void playTimerFoley()
    {
        timer.volume = maxFoleyVolume;
        if (!timer.isPlaying)
        {
            timer.Play();
        }
    }

    public void playWinJingle()
    {
        jingleWin.volume = maxFoleyVolume;
        if (timer.isPlaying)
        {
            timer.Stop();
        }
        jingleWin.Play();
    }

    public void playLoseJingle()
    {
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

    public void setBackgroundVolume(float volume) {
        maxBackgroundVolume = volume;
        if (menu.volume != 0) {
            menu.volume = maxBackgroundVolume;
        }
        if (inGame.volume != 0)
        {
            inGame.volume = maxBackgroundVolume;
        }
    }

    public void setSoundVolume(float volume)
    {
        maxSoundVolume = volume;
    }
    public void setFoleyVolume(float volume)
    {
        maxFoleyVolume = volume;
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
