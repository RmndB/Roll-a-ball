using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Debug.Log("del");
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
