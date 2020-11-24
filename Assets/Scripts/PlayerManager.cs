using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool useAIasPlayerB = true;
    public static bool useSuperAI = true;
	// true -> hard, false -> easy
    public static bool superAIHard = false;

    [SerializeField]
    private GameObject playerB = default;

    private void Awake()
    {
        if (useAIasPlayerB)
        {
            playerB.GetComponent<Controller>().enabled = false;
            if(useSuperAI)
                playerB.GetComponent<SuperAgentController>().enabled = true;
            else
                playerB.GetComponent<AgentController>().enabled = true;
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
