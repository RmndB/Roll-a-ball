using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector3 coord;
    public int gridX, gridY;

    public int gCost;
    public int hCost;

    public Node parent;

    public Node(bool _walkable, Vector3 _coord, int _gridX, int _griY) {
        walkable = _walkable;
        coord = _coord;
        gridX = _gridX;
        gridY = _griY;
    }

    public int fCost {
        get {
            return gCost + hCost;
        }
    }
}
