using UnityEngine;
using UnityEngine.UI;

public class TouchItems : MonoBehaviour
{
    private const int DEFAULT_COUNT_VALUE = 0;

    [SerializeField]
    private LayerMask collectableLayer = default;
    [SerializeField]
    private Text scoreUI = default;
    private Master master;

    private int countPlayer;

    private void Start()
    {
        countPlayer = DEFAULT_COUNT_VALUE;
        master = GameObject.FindGameObjectsWithTag("Music")[0].GetComponent<Master>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & collectableLayer.value) != DEFAULT_COUNT_VALUE)
        {
            other.gameObject.SetActive(false);
            countPlayer++;
            scoreUI.text = countPlayer.ToString();
            master.playCoinSound();
        }
    }

    public void ResetScore()
    {
        countPlayer = DEFAULT_COUNT_VALUE;
        scoreUI.text = countPlayer.ToString();
    }

    public int GetCountPlayer()
    {
        return countPlayer;
    }
}
