using UnityEngine;

public class AgentController : MonoBehaviour
{
    private const float SPEED = 10.0f;

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject coinsContainer;
    [SerializeField]
    private Pathfinder pathfinder;

    private Vector3 closestNodeCoord;

    private void Update()
    {
        if (target == null || !target.activeSelf)
        {
            if (coinsContainer.GetComponentsInChildren<Transform>().Length > 1)
            {
                pickUpDestination();
            }
        }

        if (target.activeSelf)
        {
            closestNodeCoord = pathfinder.getClosestNodeCoord();
            Move();
        }
    }

    private void pickUpDestination()
    {
        Transform[] childs = coinsContainer.GetComponentsInChildren<Transform>();
        target = childs[Random.Range(1, childs.Length)].gameObject;
        pathfinder.setTarget(target.transform);
    }

    private void Move()
    {
        float step = SPEED * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(closestNodeCoord.x, transform.position.y, closestNodeCoord.z), step);
    }
}
