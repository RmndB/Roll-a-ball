using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private TouchItems touchItemsPlayer1;
    private TouchItems touchItemsPlayer2;

    public Text timerUI;

    public float defaultValue = 10; 
    public float timer;

    public GameObject spawner;
    private Factory factory;

    private void Start()
    {
        timer = defaultValue;
        touchItemsPlayer1 = player1.GetComponent<TouchItems>();
        touchItemsPlayer2 = player2.GetComponent<TouchItems>();

        factory = spawner.GetComponent<Factory>();
        factory.create();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else {
            timer = defaultValue;

            touchItemsPlayer1.resetScore();
            touchItemsPlayer2.resetScore();

            if (touchItemsPlayer1.countPlayer > touchItemsPlayer2.countPlayer)
            {
                // P1 wins
            }
            else if (touchItemsPlayer1.countPlayer < touchItemsPlayer2.countPlayer)
            {
                // P2 wins
            }
            else {
                // Tie
            }

            factory.clean();
            factory.create();
        }
        timerUI.text = Mathf.Round(timer).ToString() + "s";
    }
}
