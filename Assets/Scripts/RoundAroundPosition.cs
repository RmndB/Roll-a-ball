using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundAroundPosition : MonoBehaviour
{
    public GameObject ballParent;
    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(ballParent.transform.position.x, ballParent.transform.position.y,
            ballParent.transform.position.z);
        transform.position = position;
    }
}
