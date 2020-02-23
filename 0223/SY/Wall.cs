using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball")
        {
            Application.LoadLevel("02.23");
            //GameMgr gmComponent = GameObject.Find("GameMgr").GetComponent<GameMgr>();
            //gmComponent.RestartGame();
        }
    }
    
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //GameMgr gmComponent = GameObject.Find("GameMgr").GetComponent<GameMgr>();
    }
}
