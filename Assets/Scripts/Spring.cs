using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private float maxY = 2.0f;
    private float minY = 1.0f;
    private float maxX = 1.0f;
    private float maxZ = 1.0f;


    public void ApplySpringForce()
    {
        float springForceX = Random.Range(maxX, -maxX);
        float springForceZ = Random.Range(maxZ, -maxZ);
        float springForceY = Random.Range(minY, maxY);

        Vector3 springForce = new Vector3(springForceX, springForceY, springForceZ);
        GetComponent<Rigidbody>().velocity = springForce;
    }
}
