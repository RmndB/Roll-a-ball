using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool useAIasPlayerB  { get; set; }
    public static bool useSuperAI { get; set; }
    // true -> hard, false -> easy
    public static bool superAIHard { get; set; }

    [SerializeField]
    private GameObject playerB = default;

    private void Start()
    {
        string niv = PlayerPrefs.GetString("diff");
        if (niv == "Difficile")
        {
            superAIHard = false;
        }
        else
        {
            superAIHard = false;
            PlayerPrefs.SetString("diff", "Facile");
        }
    }

    private void Awake()
    {
        if (useAIasPlayerB)
        {
            playerB.GetComponent<Controller>().enabled = false;
            if (useSuperAI) {
                playerB.GetComponent<AgentController>().enabled = false;
                playerB.GetComponent<SuperAgentController>().enabled = true;
            }
            else {
                playerB.GetComponent<AgentController>().enabled = true;
                playerB.GetComponent<SuperAgentController>().enabled = false;
            }
            playerB.GetComponent<Pathfinder>().enabled = true;
        }
        else
        {
            playerB.GetComponent<Controller>().enabled = true;
            playerB.GetComponent<AgentController>().enabled = false;
            playerB.GetComponent<SuperAgentController>().enabled = false;
            playerB.GetComponent<Pathfinder>().enabled = false;
        }
    }
}
