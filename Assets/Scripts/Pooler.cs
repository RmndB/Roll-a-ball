using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool {
        public string name;
        public GameObject particlePrefab;
        public int size;
    }

    public static Pooler pooler;

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> containers;

    private void Awake()
    {
        pooler = this;
    }

    void Start()
    {
        containers = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools) {
            Queue<GameObject> particles = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) {
                GameObject newParticle = Instantiate(pool.particlePrefab);
                newParticle.transform.parent = this.transform;
                newParticle.SetActive(false);
                particles.Enqueue(newParticle);
            }

            containers.Add(pool.name, particles);
        }
    }

    public GameObject FetchOldParticle(string name, Vector3 coords, Quaternion rotation) {
        GameObject oldParticle = containers[name].Dequeue();
        oldParticle.SetActive(true);
        oldParticle.transform.position = coords;
        oldParticle.transform.rotation = rotation;

        oldParticle.GetComponent<Spring>().ApplySpringForce();

        containers[name].Enqueue(oldParticle);

        return oldParticle;
    }
}
