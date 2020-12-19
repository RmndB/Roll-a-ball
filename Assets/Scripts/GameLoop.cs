using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public static float timerValue { get; set; }
    
    private const float DEFAULT_TIMER_VALUE = 30;
    
    private const int PLAYER1WON = 0;
    private const int PLAYER2WON = 1;
    private const int YOUWON = 2;
    private const int AIWON = 3;
    private const int DRAW = 4;
    [SerializeField]
    private GameObject player1 = default;
    [SerializeField]
    private GameObject player2 = default;
    [SerializeField]
    private Text timerUI = default;
    [SerializeField]
    private Factory factory = default;
    [SerializeField]
    private Text totalUI = default;
    
    private TouchItems touchItemsPlayer1;
    private TouchItems touchItemsPlayer2;
    public float timer;
    public GameObject victoryMenu;
    public GameObject VictoryMenuFirst;

    private Master master;

    private void Start()
    {
        victoryMenu.SetActive(false);
        
        timerValue = PlayerPrefs.GetFloat("timeGame");
        if (timerValue == 0)
        {
            PlayerPrefs.SetFloat("timeGame",DEFAULT_TIMER_VALUE);
            timerValue = DEFAULT_TIMER_VALUE;
            
        }

        timer = timerValue;
        touchItemsPlayer1 = player1.GetComponent<TouchItems>();
        touchItemsPlayer2 = player2.GetComponent<TouchItems>();

        factory.Create();

        master = GameObject.FindGameObjectsWithTag("Music")[0].GetComponent<Master>();
    }

    private void Update()
    {

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            
            if (touchItemsPlayer1.GetCountPlayer() + touchItemsPlayer2.GetCountPlayer() >= Factory.NUMBER_OF_COLLECTABLE)
            {
                showTheWinner();
                touchItemsPlayer1.ResetScore();
                touchItemsPlayer2.ResetScore();
            }
        }
        else
        {
            timer = timerValue;
            showTheWinner();
            touchItemsPlayer1.ResetScore();
            touchItemsPlayer2.ResetScore();
        }
        timerUI.text = Mathf.Round(timer).ToString() + "s";
        totalUI.text = (Factory.NUMBER_OF_COLLECTABLE -
                       (touchItemsPlayer1.GetCountPlayer() + touchItemsPlayer2.GetCountPlayer())).ToString();

        if (timer <= 10 && timer >= 1) {
            master.playTimerFoley();
        }

        if ((int)timer % 3 == 0) {           
            master.playTickSound();
        }
    }

    public void showTheWinner()
    {
        if (touchItemsPlayer1.GetCountPlayer() > touchItemsPlayer2.GetCountPlayer())
        {
            EndTheGame(factory, PLAYER1WON, touchItemsPlayer1.GetCountPlayer(), touchItemsPlayer2.GetCountPlayer());
            master.playWinJingle();
        }
        else if (touchItemsPlayer1.GetCountPlayer() < touchItemsPlayer2.GetCountPlayer())
        {
            EndTheGame(factory, PLAYER2WON, touchItemsPlayer1.GetCountPlayer(), touchItemsPlayer2.GetCountPlayer());
            master.playLoseJingle();
        }
        else
        {
            EndTheGame(factory, DRAW, touchItemsPlayer1.GetCountPlayer(), touchItemsPlayer2.GetCountPlayer());
            master.playLoseJingle();
        }
    }

    public void EndTheGame(Factory factory, int result, int countP1,int countP2)
    {
        factory.Clean();
        factory.Create();
        victoryMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(VictoryMenuFirst);
        
        Time.timeScale = 0f;
        
        TextMeshProUGUI textTitle = GameObject.Find("VictoryTitle").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nbPieceP1 = GameObject.Find("J1Pieces").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nbPieceP2 = GameObject.Find("J2Pieces").GetComponent<TextMeshProUGUI>();

        nbPieceP1.text = countP1.ToString();
        nbPieceP2.text = countP2.ToString();
        
        switch (result)
        {
            case PLAYER1WON:
                textTitle.text = " VICTOIRE J1 !";
                break;
            case PLAYER2WON:
                textTitle.text = " VICTOIRE J2 !";
                break;
            case YOUWON:
                textTitle.text = " VICTOIRE !!!";
                break;
            case AIWON:
                textTitle.text = " DÉFAITE !!!";
                break;
            case DRAW:
                textTitle.text = " ÉGALITÉ!";
                break;
        }
    }
    public void RestartTheGame()
    {
        victoryMenu.SetActive(false);
        Time.timeScale = 1f;
        timer = timerValue;
    }
}
