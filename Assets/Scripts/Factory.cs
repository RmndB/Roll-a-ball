using UnityEngine;

public class Factory : MonoBehaviour
{
    static public int NUMBER_OF_COLLECTABLE = 15;
    private const int HEIGHT = 1;

    [SerializeField]
    private Grid grid = default;
    [SerializeField]
    private GameObject prefab = default;

    public void Clean()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Create()
    {
        for (int i = 0; i < NUMBER_OF_COLLECTABLE; i++)
        {
            Node targetNode = grid.GetAWalkableNode();
            GameObject newCollectable = Instantiate(prefab, new Vector3(targetNode.GetX() - grid.GetSizeX() / 2, HEIGHT, targetNode.GetY() - grid.GetSizeY() / 2), prefab.transform.rotation);
            newCollectable.transform.parent = transform;
        }
    }
}
