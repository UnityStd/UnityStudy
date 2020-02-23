using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball1 : MonoBehaviour
{

    public GameObject Ball;
    

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))  //스페이스바 누르면 공 튀어오름
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
            /*Rigidbody ballRigid;
            ballRigid = gameObject.GetComponent<Rigidbody>();
            ballRigid.AddForce(Vector3.up * 300);
            */
        }


        if (Input.GetKey(KeyCode.A))
        {
            Ball.transform.Translate(-0.05f, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Ball.transform.Translate(0.05f, 0, 0);
        }

    }
}
