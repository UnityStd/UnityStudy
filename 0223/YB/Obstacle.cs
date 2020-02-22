using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Vector3 direction = transform.position = collision.gameObject.transform.position;
        direction = direction.normalized * 1000;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);
    }
    
    float delta = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
        float newXPosition = transform.localPosition.x + delta;
        transform.localPosition = new Vector3(newXPosition
            ,transform.localPosition.y
            ,transform.localPosition.z);
        if(transform.localPosition.x<-3.5)
        {
            delta = 0.1f;
        }
        else if (transform.localPosition.x >3.5)
        {
            delta = -0.1f;
        }
    }
}
