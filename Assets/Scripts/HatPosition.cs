using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatPosition : MonoBehaviour
{
    public GameObject ballParent;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 position = new Vector3(ballParent.transform.position.x, ballParent.transform.position.y + 1,
            ballParent.transform.position.z);
        transform.position = position;
    }
}
