using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int coinCount = 0; // 계속 0으로 초기화 되면 안되니까 밖에다!
    void GetCoin()
    {
        coinCount++;
        Debug.Log("박살낸 갯수: " + coinCount);

    }
    void RestartGame()
    {
        Application.LoadLevel("Game");
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
