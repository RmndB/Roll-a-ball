using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    public Transform seeker, target;
    Grid grid;

    void Awake()
    {
        grid = GetComponent<Grid>();
    }

    void Update()
    {
        if (target != null)
        {
            FindPath(seeker.position, target.position);
        }
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node node = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].getF() < node.getF() || openSet[i].getF() == node.getF())
                {
                    if (openSet[i].getH() < node.getH())
                        node = openSet[i];
                }
            }

            openSet.Remove(node);
            closedSet.Add(node);

            if (node == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(node))
            {
                if (!neighbour.getWalkable() || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newCostToNeighbour = node.getG() + GetDistance(node, neighbour);
                if (newCostToNeighbour < neighbour.getG() || !openSet.Contains(neighbour))
                {
                    neighbour.setG(newCostToNeighbour);
                    neighbour.setH(GetDistance(neighbour, targetNode));
                    neighbour.parent = node;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
    }

    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;

    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.getX() - nodeB.getX());
        int dstY = Mathf.Abs(nodeA.getY() - nodeB.getY());

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }

    public void setTarget(Transform _target) {
        target = _target;
    }

    public Vector3 getClosestNodeCoord()
    {
        if (grid.path != null && grid.path.Count > 0)
            return grid.path[0].getCoord();
        else
            return target.transform.position;
    }
}
