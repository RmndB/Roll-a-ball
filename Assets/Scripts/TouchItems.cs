using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchItems : MonoBehaviour
{

    public int countPlayer1;
    
    // Start is called before the first frame update
    void Start()
    {
        countPlayer1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            countPlayer1++;
        }
    }
    
}
