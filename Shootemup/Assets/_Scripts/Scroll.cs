using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float speed = 0.5f;

    //https://www.youtube.com/watch?v=32EIYs6Z18Q&ab_channel=MadFireOn
    // Update is called olnce per frame
    void Update()
    {
        Vector2 offset = new Vector2(speed, 0f) * Time.deltaTime;
        GetComponent<Renderer>().material.mainTextureOffset += offset;
    }
}