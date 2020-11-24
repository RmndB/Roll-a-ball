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

                int xAxis = node.GetX() + x;
                int yAxis = node.GetY() + y;

                if (xAxis >= 0 && xAxis < sizeX && yAxis >= 0 && yAxis < sizeY)
                {
                    neighbours.Add(grid[xAxis, yAxis]);
                }
            }
        }

        return neighbours;
    }

    public Node RetrieveNode(Vector3 coord)
    {
        float percentX = (coord.x + sizeX / 2) / sizeX;
        float percentY = (coord.z + sizeY / 2) / sizeY;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((sizeX - 1) * percentX);
        int y = Mathf.RoundToInt((sizeY - 1) * percentY);

        return grid[x, y];
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
}
