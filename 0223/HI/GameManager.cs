using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public int count = 5;
    public Text unitText;
    // Start is called before the first frame update
    void coincount()
    {
        count--;
        unitText.text = "남은 개수: " + count + "개";
    }
    void Start()
    {
        unitText.text = "남은 개수: " + count + "개";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
