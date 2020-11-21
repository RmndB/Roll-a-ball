using UnityEngine;

public class Node
{
    private bool walkable;
    private Vector3 coord;
    private int x;
    private int y;
    private int g;
    private int h;

    public Node parent;

    public Node(bool walkable, Vector3 coord, int x, int y)
    {
        this.walkable = walkable;
        this.coord = coord;
        this.x = x;
        this.y = y;
    }

    public bool getWalkable()
    {
        return walkable;
    }

    public Vector3 getCoord()
    {
        return coord;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }

    public int getG()
    {
        return g;
    }

    public void setG(int g)
    {
        this.g = g;
    }

    public void setH(int h)
    {
        this.h = h;
    }

    public int getH()
    {
        return h;
    }

    public int getF()
    {
        return g + h;
    }
}
