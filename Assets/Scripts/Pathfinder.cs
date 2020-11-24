using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    private const int DIAGONAL_COST = 14;
    private const int ADJACENT_COST = 10;

    [SerializeField]
    public Grid grid;

    private Transform agent = default;
    private Transform target = default;

    private List<Node> path;

    private void Start()
    {
        agent = this.GetComponent<Transform>();
    }

    private void Update()
    {
        if (target != null)
        {
            FindPath(agent, target);
        }
    }

    private void FindPath(Transform agent, Transform target)
    {
        Node startNode = grid.RetrieveNode(agent.position);
        Node targetNode = grid.RetrieveNode(target.position);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node node = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].GetF() < node.GetF() || openSet[i].GetF() == node.GetF())
                {
                    if (openSet[i].GetH() < node.GetH())
                    {
                        node = openSet[i];
                    }
                }
            }

            openSet.Remove(node);
            closedSet.Add(node);

            if (node == targetNode)
            {
                RecordShortestPath(startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(node))
            {
                if (!neighbour.GetWalkable() || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newCostToNeighbour = node.GetG() + ComputeCost(node, neighbour);
                if (newCostToNeighbour < neighbour.GetG() || !openSet.Contains(neighbour))
                {
                    neighbour.SetG(newCostToNeighbour);
                    neighbour.SetH(ComputeCost(neighbour, targetNode));
                    neighbour.SetChild(node);

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                }
            }
        }
    }

    private void RecordShortestPath(Node nodeA, Node nodeB)
    {
        List<Node> shortestPath = new List<Node>();

        Node visitor = nodeB;
        while (visitor != nodeA)
        {
            shortestPath.Insert(0, visitor);
            visitor = visitor.GetChild();
        }

        path = shortestPath;
    }

    private int ComputeCost(Node nodeA, Node nodeB)
    {
        int distanceX = Mathf.Abs(nodeB.GetX() - nodeA.GetX());
        int distanceY = Mathf.Abs(nodeB.GetY() - nodeA.GetY());

        int diagonalDistance;
        int adjacentDistance;

        if (distanceX < distanceY)
        {
            diagonalDistance = distanceX;
            adjacentDistance = distanceY - distanceX;
        }
        else {
            diagonalDistance = distanceY;
            adjacentDistance = distanceX - distanceY;
        }

        return DIAGONAL_COST * diagonalDistance + ADJACENT_COST * adjacentDistance;
    }

    public void setTarget(Transform target)
    {
        this.target = target;
    }

    public Vector3 getClosestNodeCoord()
    {
        if (path != null && path.Count > 0)
        {
            return path[0].GetCoord();
        }
        else
        {
            return target.transform.position;
        }
    }
}
