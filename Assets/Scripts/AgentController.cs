using UnityEngine;

public class AgentController : MonoBehaviour
{
    private const float SPEED = 10.0f;

    [SerializeField]
    private GameObject target = default;
    [SerializeField]
    private GameObject coinsContainer = default;
    [SerializeField]
    private Pathfinder pathfinder = default;

    private Vector3 closestNodeCoord;

    private void Update()
    {
        if (target == null || !target.activeSelf)
        {
            if (coinsContainer.GetComponentsInChildren<Transform>().Length > 1)
            {
                PickUpDestination();
            }
        }

        if (target.activeSelf)
        {
            closestNodeCoord = pathfinder.getClosestNodeCoord();
            Move();
        }
    }

    private void PickUpDestination()
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
