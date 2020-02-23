using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowling : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball")
        {
            Destroy(gameObject);
            GameObject.Find("GameManager").SendMessage("coincount");
            GameObject ball = GameObject.Find("Ball");
            ball.GetComponent<Rigidbody>().AddForce(Vector3.back * 20);
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            ball.transform.position = new Vector3(0, 0.5f, -3);
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
