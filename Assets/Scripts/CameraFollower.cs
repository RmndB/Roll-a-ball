using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    void Start()
    {
        offset = new Vector3(0,15,-15);
    }
    
    void Update()
    {
        
        transform.position = (player.transform.position + offset);
        transform.LookAt(player.transform);
    }
}
