using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RepeatBg : MonoBehaviour
{
    public float speed = 1.0f;

    //https://www.youtube.com/watch?v=32EIYs6Z18Q&ab_channel=MadFireOn
    // Update is called olnce per frame
    void Update()
    {
        Vector2 offset = new Vector2(0f, speed) * Time.deltaTime;
        GetComponent<Renderer>().material.mainTextureOffset += offset;
    }
}
