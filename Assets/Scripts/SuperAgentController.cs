using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SuperAgentController : MonoBehaviour
{
    private const float SPEED = 8.0f;

    private const int EASY_DEPTH = 2;
    private const int HARD_DEPTH = 4;

    [SerializeField]
    private GameObject target = default;
    [SerializeField]
    private GameObject coinsContainer = default;
    [SerializeField]
    private Pathfinder pathfinder = default;

    private Vector3 closestNodeCoord;

    private Queue<GameObject> futureTargets;

    private void Update()
    {
        if (coinsContainer.GetComponentsInChildren<Transform>().Length > 1)
        {
            if (target == null || (futureTargets.Count == 0 && !target.activeSelf))
            {
                if (PlayerManager.superAIHard)
                {
                    setFutureTargets(HARD_DEPTH);
                }
                else
                {
                    setFutureTargets(EASY_DEPTH);
                }
                PopDestination();
            }

            if (target.activeSelf)
            {
                closestNodeCoord = pathfinder.getClosestNodeCoord();
                Move();
            }
            else
            {
                PopDestination();
            }
        }
    }

    private void PopDestination()
    {
        target = futureTargets.Dequeue();
        pathfinder.setTarget(target.transform);
    }

    private void setFutureTargets(int depth)
    {
        Transform[] childs = coinsContainer.GetComponentsInChildren<Transform>();
        var tmpRemover = new List<Transform>(childs);
        tmpRemover.RemoveAt(0);
        childs = tmpRemover.ToArray();
        futureTargets = findOptimalSeries(depth, transform.position, childs, new HashSet<int>(), new Queue<GameObject>(), 0).Item1;
    }

    private Tuple<Queue<GameObject>, float> findOptimalSeries(int depth, Vector3 startPos, Transform[] childs, HashSet<int> visited, Queue<GameObject> nodesInOrder, float distance)
    {
        if (depth == 0 || childs.Length == 0)
        {
            return new Tuple<Queue<GameObject>, float>(new Queue<GameObject>(), 0);
        }
        else if (nodesInOrder.Count < depth && nodesInOrder.Count < childs.Length)
        {
            Tuple<Queue<GameObject>, float> optimalSeries = new Tuple<Queue<GameObject>, float>(new Queue<GameObject>(), 0);
            float minDistance = -1;

            for (int i = 0; i < childs.Length; i++)
            {
                if (!visited.Contains(i))
                {
                    float newDistance;

                    if (nodesInOrder.Count == 0)
                    {
                        newDistance = Vector3.Distance(startPos, childs[i].position);
                    }
                    else
                    {
                        newDistance = distance + Vector3.Distance(nodesInOrder.Last().transform.position, childs[i].position);
                    }

                    HashSet<int> newVisited = new HashSet<int>(visited);
                    newVisited.Add(i);

                    Queue<GameObject> newNodesInOrder = new Queue<GameObject>(nodesInOrder);
                    newNodesInOrder.Enqueue(childs[i].gameObject);

                    Tuple<Queue<GameObject>, float> newOptimalSeries = findOptimalSeries(depth, startPos, childs, newVisited, newNodesInOrder, newDistance);

                    if (newOptimalSeries.Item2 < minDistance || minDistance == -1)
                    {
                        minDistance = newOptimalSeries.Item2;
                        optimalSeries = newOptimalSeries;
                    }
                }
            }

            return optimalSeries;
        }
        else
        {
            return new Tuple<Queue<GameObject>, float>(nodesInOrder, distance);
        }
    }

    private void Move()
    {
        float step = SPEED * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(closestNodeCoord.x, transform.position.y, closestNodeCoord.z), step);
    }
}

