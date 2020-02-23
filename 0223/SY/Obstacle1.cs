using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle1 : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            Destroy(gameObject);
            GameObject.Find("GameMgr").SendMessage("Obstaclecount");
            GameObject ball = GameObject.Find("Ball");
            ball.transform.position = new Vector3(0, 8, -22);
           
        }
    }
 
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
