using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : MonoBehaviour
{
    GameObject ball;

    void Start()
    {
        ball = GameObject.Find("Ball");

    }

   
    void Update()
    {
        transform.position = new Vector3(0, 
            ball.transform.position.y+3 //+3과 -14는 카메라와 물체 사이의 상대위치유지
            , ball.transform.position.z - 14);
    }
}
