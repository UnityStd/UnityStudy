using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float startingPoint;  

    void Start()
    {
        Debug.Log("start");
        startingPoint = transform.position.z;

        
    }

    void Update()
    {
        float distance;
        distance =  startingPoint-transform.position.z;

        if (Input.GetKeyDown(KeyCode.Space)) //뗀 순간은 GetKeyUp
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 200);


        }
        


    }
}
