using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;
    void Start()
    {
        player = GameObject.Find("Player");
        offset = new Vector3(0,5,-7);
    }
    
    void Update()
    {
        
        transform.position = (player.transform.position + offset);
        transform.LookAt(player.transform);
    }
}
