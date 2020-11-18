using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public Transform player;
    public Vector2 size;
    public float radius;
    public LayerMask unwalkableLayerMask;

    private Node[,] grid;
    private float nodeDiamater;
    int gridSizeX, gridSizeY;

    public List<Node> path;

    private void Start()
    {
        nodeDiamater = radius * 2;
        gridSizeX = Mathf.RoundToInt(size.x/nodeDiamater);
        gridSizeY = Mathf.RoundToInt(size.y/nodeDiamater);

        CreateGrid();
    }

    public List<Node> GetNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }

    private void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * size.x / 2 - Vector3.forward * size.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiamater + radius) + Vector3.forward * (y * nodeDiamater + radius);
                bool walkable = !(Physics.CheckSphere(worldPoint, radius, unwalkableLayerMask));
                grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    public Node NodeFromWorldPoint(Vector3 coord) {
        float percentX = (coord.x + size.x / 2) / size.x;
        float percentY = (coord.z + size.y / 2) / size.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);

        return grid[x, y];
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(size.x, 1, size.y));

        if (grid != null)
        {
            foreach (Node n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                if (path != null)
                    if (path.Contains(n))
                        Gizmos.color = Color.black;
                Gizmos.DrawCube(n.coord, Vector3.one * (nodeDiamater - .1f));
            }
        }
    }
}
