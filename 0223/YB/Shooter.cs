using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Obstacle
{
   public GameObject stone;

    float timeCount = 0;
    // Update is called once per frame
    void Update()
    {
        base.Update();
        timeCount += Time.deltaTime;
        if (timeCount > 3)
        {
            Instantiate(stone, transform.position, Quaternion.identity);
            Debug.Log("돌을 던져라");
            timeCount = 0;
        }
        
    }
}
