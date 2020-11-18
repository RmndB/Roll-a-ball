using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotation : MonoBehaviour
{
    private int rotationSpeed;
    public int limit = 5;

    void Start()
    {
        rotationSpeed = Random.Range(-limit, limit);
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.World);
    }
}