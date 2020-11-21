using UnityEngine;

public class AgentController : MonoBehaviour
{
    public GameObject destination;
    public GameObject coinsContainer;
    public Pathfinder pathfinder;
    public Vector3 closestNodeCoord;
    public float speed = 10.0f;

    private void Update()
    {
        if (destination == null || !destination.activeSelf)
        {
            if (coinsContainer.GetComponentsInChildren<Transform>().Length > 1)
            {
                pickUpDestination();
            }
        }

        if (destination.activeSelf)
        {
            closestNodeCoord = pathfinder.getClosestNodeCoord();
            Move();
        }
    }

    private void pickUpDestination()
    {
        Transform[] childs = coinsContainer.GetComponentsInChildren<Transform>();
        destination = childs[Random.Range(1, childs.Length)].gameObject;
        pathfinder.setTarget(destination.transform);
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(closestNodeCoord.x, transform.position.y, closestNodeCoord.z), step);
    }
}
