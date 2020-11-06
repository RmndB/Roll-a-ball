using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TouchItems : MonoBehaviour
{
    public int countPlayer;
    public Text scoreUI;

    public LayerMask collectableLayer;

    void Start()
    {
        countPlayer = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & collectableLayer.value) != 0)
        {
            other.gameObject.SetActive(false);
            countPlayer++;
            scoreUI.text = countPlayer.ToString();
        }
    }

    public void resetScore() {
        countPlayer = 0;
        scoreUI.text = countPlayer.ToString();
    }
}
