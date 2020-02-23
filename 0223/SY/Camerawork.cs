using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerawork : MonoBehaviour {
    public GameObject ball;
	// Use this for initialization
	void Start () {
        //ball = GameObject.Find("Ball"); //public 쓰면 생략가능

        /*GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        for (int i = 0; i < coins.Length; i++)
        {
            Debug.Log(coins[i].name);
        }*/
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(0
            , ball.transform.position.y + 3
            , ball.transform.position.z - 14);
	}
}
