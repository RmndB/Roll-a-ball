using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject prefab;

    public int maxNumberOfEntities = 15;

    public List<Vector2> pos;
    private int height = 15;

    public void clean() {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void create()
    {
        foreach (Vector2 entityPos in pos)
        {
            GameObject newCollectable = Instantiate(prefab, new Vector3(entityPos.x, height, entityPos.y), prefab.transform.rotation);
            newCollectable.transform.parent = this.transform;
        }
    }
}
