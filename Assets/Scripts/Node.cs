using UnityEngine;

public class Node
{
    private bool walkable;
    private Vector3 coord;
    private int x;
    private int y;
    private int g;
    private int h;
    private Node child;

    public Node(bool walkable, Vector3 coord, int x, int y)
    {
        this.walkable = walkable;
        this.coord = coord;
        this.x = x;
        this.y = y;
    }

    public bool GetWalkable()
    {
        return walkable;
    }

    public Vector3 GetCoord()
    {
        return coord;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public int GetG()
    {
        return g;
    }

    public void SetG(int g)
    {
        this.g = g;
    }

    public void SetH(int h)
    {
        this.h = h;
    }

    public int GetH()
    {
        return h;
    }

    public int GetF()
    {
        return g + h;
    }

    public Node GetChild()
    {
        return child;
    }

    public void SetChild(Node child)
    {
        this.child = child;
    }
}
