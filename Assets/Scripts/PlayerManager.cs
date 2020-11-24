using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool useAIasPlayerB = false;

    [SerializeField]
    private GameObject playerB = default;

    private void Awake()
    {
        if (useAIasPlayerB)
        {
            playerB.GetComponent<Controller>().enabled = false;
            playerB.GetComponent<AgentController>().enabled = true;
            playerB.GetComponent<Pathfinder>().enabled = true;
        }
        else
        {
            playerB.GetComponent<Controller>().enabled = true;
            playerB.GetComponent<AgentController>().enabled = false;
            playerB.GetComponent<Pathfinder>().enabled = false;
        }
    }
}
