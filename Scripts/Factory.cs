using UnityEngine;

public class Factory : MonoBehaviour
{
    private const int NUMBER_OF_COLLECTABLE = 15;
    private const int HEIGHT = 1;

    [SerializeField]
    private Grid grid;
    [SerializeField]
    private GameObject prefab;

    public void clean()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void create()
    {
        for (int i = 0; i < NUMBER_OF_COLLECTABLE; i++)
        {
            Node targetNode = grid.GetAWalkableNode();
            GameObject newCollectable = Instantiate(prefab, new Vector3(targetNode.getX() - grid.size.x / 2, HEIGHT, targetNode.getY() - grid.size.y / 2), prefab.transform.rotation);
            newCollectable.transform.parent = transform;
        }
    }
}
