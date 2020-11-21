using UnityEngine;

public class Factory : MonoBehaviour
{
    public Grid grid;
    public GameObject prefab;
    public int numberOfCoins;
    public int height;

    public void clean()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void create()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            Node targetNode = grid.GetAWalkableNode();
            GameObject newCollectable = Instantiate(prefab, new Vector3(targetNode.gridX - grid.size.x / 2, height, targetNode.gridY - grid.size.y / 2), prefab.transform.rotation);
            newCollectable.transform.parent = transform;
        }
    }
}
