﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball")
        {
            col.gameObject.transform.position = new Vector3(0, 0.5f, -3);
            col.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {

    }
}
