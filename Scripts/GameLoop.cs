using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    private const float DEFAULT_TIMER_VALUE = 10;

    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private Text timerUI;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Factory factory;

    private TouchItems touchItemsPlayer1;
    private TouchItems touchItemsPlayer2;
    private float timer;

    private void Start()
    {
        timer = DEFAULT_TIMER_VALUE;
        touchItemsPlayer1 = player1.GetComponent<TouchItems>();
        touchItemsPlayer2 = player2.GetComponent<TouchItems>();

        grid.CreateGrid();
        factory.create();
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

            touchItemsPlayer1.resetScore();
            touchItemsPlayer2.resetScore();

            if (touchItemsPlayer1.getCountPlayer() > touchItemsPlayer2.getCountPlayer())
            {
                // P1 wins
            }
            else if (touchItemsPlayer1.getCountPlayer() < touchItemsPlayer2.getCountPlayer())
            {
                // P2 wins
            }
            else
            {
                // Tie
            }

            factory.clean();
            factory.create();
        }
        timerUI.text = Mathf.Round(timer).ToString() + "s";
    }
}
