using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public GameObject destination;
    private NavMeshAgent navMeshAgent;
    public GameObject coinsContainer;

    void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("Failled to attach navMeshAgent");
        }
        else
        {
            pickUpDestination();
            SetDestination();
        }
    }

    private void SetDestination()
    {

        Vector3 targetVector = destination.transform.position;
        // Clumsy
        /*
        float distance = Vector3.Distance(this.transform.position, targetVector);
        float margin = 3;
        targetVector.x = targetVector.x + Random.Range(-distance/margin, distance/margin);
        targetVector.y = targetVector.y + Random.Range(-distance/margin, distance/margin);
        targetVector.z = targetVector.z + Random.Range(-distance/margin, distance/margin);
        */
        navMeshAgent.SetDestination(targetVector);

        // TODO: Rotate
    }

    private void pickUpDestination() {
        Transform[] childs = coinsContainer.GetComponentsInChildren<Transform>();
        destination = childs[Random.Range(0, childs.Length)].gameObject;
    }

    private void Update()
    {
        if (destination == null || !destination.activeSelf)
        {
            pickUpDestination();
        }
        SetDestination();
    }
}
