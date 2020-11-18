using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public GameObject destination;
    public GameObject coinsContainer;
    public Pathfinder pathfinder;
    public Vector3 closestNodeCoord;
    public float speed = 10.0f;

    private NavMeshAgent navMeshAgent;
    private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();

        if (rigidbody == null)
        {
            Debug.LogError("Failled to attach rigidbody");
        }
        else
        {
            pickUpDestination();
            destination = coinsContainer;
        }
    }

    private void Update()
    {
        if (destination == null || !destination.activeSelf || destination == coinsContainer)
        {
            if (coinsContainer.GetComponentsInChildren<Transform>().Length > 1)
            {
                pickUpDestination();
            }
            else
            {
                destination = coinsContainer;
                pathfinder.setTarget(coinsContainer.transform);
            }

        }
        SetDestination();
        Move();
    }

    private void SetDestination()
    {

        closestNodeCoord = pathfinder.getClosestNodeCoord();
        // TODO: TP3 Rotate
    }

    private void pickUpDestination() {
        Transform[] childs = coinsContainer.GetComponentsInChildren<Transform>();
        destination = childs[Random.Range(1, childs.Length)].gameObject;
        pathfinder.setTarget(destination.transform);
    }

    private void Move()
    {
        float step = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(closestNodeCoord.x, this.transform.position.y, closestNodeCoord.z), step);
    }
}
