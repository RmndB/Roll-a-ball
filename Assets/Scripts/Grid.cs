using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private const float RADIUS = 0.5f;

    [SerializeField]
    private int sizeX = default;
    [SerializeField]
    private int sizeY = default;
    [SerializeField]
    private LayerMask unwalkableLayerMask = default;

    private Node[,] grid;
    private List<Node> path;

    private void Awake()
    {
        grid = new Node[sizeX, sizeY];
        Vector3 anchor = new Vector3(-sizeX / 2, 0, -sizeY / 2);

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Vector3 worldPoint = anchor + Vector3.right * (x * RADIUS * 2 + RADIUS) + Vector3.forward * (y * RADIUS * 2 + RADIUS);
                bool walkable = !(Physics.CheckSphere(worldPoint, RADIUS, unwalkableLayerMask));
                grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }

                int checkX = node.GetX() + x;
                int checkY = node.GetY() + y;

                if (checkX >= 0 && checkX < sizeX && checkY >= 0 && checkY < sizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    public Node NodeFromWorldPoint(Vector3 coord)
    {
        float percentX = (coord.x + sizeX / 2) / sizeX;
        float percentY = (coord.z + sizeY / 2) / sizeY;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((sizeX - 1) * percentX);
        int y = Mathf.RoundToInt((sizeY - 1) * percentY);

        return grid[x, y];
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(sizeX, 1, sizeY));

        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.GetWalkable()) ? Color.white : Color.red;
                if (path != null)
                {
                    if (path.Contains(n))
                    {
                        Gizmos.color = Color.black;
                    }
                }

                Gizmos.DrawCube(n.GetCoord(), Vector3.one * (RADIUS * 2 - .1f));
            }
        }
    }

    public Node GetAWalkableNode()
    {

        int randomX = UnityEngine.Random.Range(0, Mathf.RoundToInt(sizeX));
        int randomY = UnityEngine.Random.Range(0, Mathf.RoundToInt(sizeY));

        Node randomNode = grid[randomX, randomY];

        if (randomNode.GetWalkable())
        {
            return randomNode;
        }
        else
        {
            return GetAWalkableNode();
        }
    }

    public int GetSizeX()
    {
        return sizeX;
    }

    public int GetSizeY()
    {
        return sizeY;
    }

    public List<Node> GetPath() {
        return path;
    }

    public void SetPath(List<Node> path)
    {
        this.path = path;
    }
}
