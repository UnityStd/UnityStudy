﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailZone : MonoBehaviour
{

    void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.name == "Ball")
        {
            Application.LoadLevel("Game");

        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
