using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSpawner : MonoBehaviour
{
    private float xSize = 80;
    private float zSize = 60;
    private float yCoord = 20;

    void FixedUpdate()
    {
        float xCoord = Random.Range(-xSize / 2, xSize / 2);
        float zCoord = Random.Range(-zSize / 2, zSize / 2);
        Vector3 newPos = new Vector3(xCoord, yCoord, zCoord);
        Pooler.pooler.FetchOldParticle("Snowflake", newPos, Quaternion.identity);

        xCoord = Random.Range(-xSize / 2, xSize / 2);
        zCoord = Random.Range(-zSize / 2, zSize / 2);
        newPos = new Vector3(xCoord, yCoord, zCoord);
        Pooler.pooler.FetchOldParticle("Rain", newPos, Quaternion.identity);
    }
}
