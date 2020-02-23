using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    public int ObstacleCount = 5;
    public Text ObstacleText;

    void Obstaclecount()
    {
        ObstacleCount--;
        ObstacleText.text = "남은 개수: " + ObstacleCount + "개";
        Debug.Log("개수: " + ObstacleCount);
    }

    /*public void RestartGame()
    {
        Application.LoadLevel("02.23");
    }*/
    

    // Use this for initialization
    void Start()
    {
        ObstacleText.text = "남은 개수: " + ObstacleCount + "개";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
