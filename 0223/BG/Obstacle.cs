using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //튕겨나갈 방향 정하자 (내위치-공의위치 : 힘의 방향)
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        direction = direction.normalized * 1000; // 가해지는 힘
        collision.gameObject.GetComponent<Rigidbody>().AddForce(direction); 
        // 공의 rigidbody를 호출해서 direction방향의 힘을 적용하는것
        // 부딪히는 영역은 오브젝트면적이 아닌 collider의 지름!

    }
    float delta = 0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float newXPosition = transform.localPosition.x + delta;
        transform.localPosition = new Vector3(newXPosition, 
            transform.localPosition.y, 
            transform.localPosition.z);

        if (transform.localPosition.x < -3.5)
        {
            delta = 0.1f;
        }

        else if(transform.localPosition.x > 3.5)
        {
            delta = -0.1f;
        }


    }
}
