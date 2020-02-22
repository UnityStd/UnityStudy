using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    int count = 1;

    float startingPoint;
  
    // Start is called before the first frame update
    void Start()
    {

        startingPoint = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        float distance;
        distance = transform.position.z - startingPoint;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.up*300);
            Rigidbody ballRigid;
            ballRigid = gameObject.GetComponent<Rigidbody>();
            ballRigid.AddForce(Vector3.up * 300);

            Debug.Log(ballRigid.mass);
        }
    }

   
}
