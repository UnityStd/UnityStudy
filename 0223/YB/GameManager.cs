using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int coinCount = 0;
    public Text coinText;

    void GetCoin()
    {
        //coinCount += coinCount +1
        coinCount++;
        coinText.text = coinCount + "개";
        Debug.Log("동전: " + coinCount);
    }

    public void RestartGame()
    {
        Application.LoadLevel("Game");
    }

    void RedCoinStart()
    {
        DestroyObstacles();
    }

    void DestroyObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
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
