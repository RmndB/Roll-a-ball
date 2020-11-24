using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    private const float DEFAULT_TIMER_VALUE = 10;

    [SerializeField]
    private GameObject player1 = default;
    [SerializeField]
    private GameObject player2 = default;
    [SerializeField]
    private Text timerUI = default;
    [SerializeField]
    private Factory factory = default;

    private TouchItems touchItemsPlayer1;
    private TouchItems touchItemsPlayer2;
    private float timer;

    private void Start()
    {
        timer = DEFAULT_TIMER_VALUE;
        touchItemsPlayer1 = player1.GetComponent<TouchItems>();
        touchItemsPlayer2 = player2.GetComponent<TouchItems>();

        factory.Create();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = DEFAULT_TIMER_VALUE;

            touchItemsPlayer1.ResetScore();
            touchItemsPlayer2.ResetScore();

            if (touchItemsPlayer1.GetCountPlayer() > touchItemsPlayer2.GetCountPlayer())
            {
                // P1 wins
            }
            else if (touchItemsPlayer1.GetCountPlayer() < touchItemsPlayer2.GetCountPlayer())
            {
                // P2 wins
            }
            else
            {
                // Tie
            }

            factory.Clean();
            factory.Create();
        }
        timerUI.text = Mathf.Round(timer).ToString() + "s";
    }
}
