using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    float horizontal = 0f;
    float vertical = 0f;
    void Update()
    {
        if(Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow))
        {
            vertical += 1f;
        }
        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow))
        {
            vertical -= 1f;
        }
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
            horizontal += 1f;
        }
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal -= 1f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal,vertical) * 3f;
        vertical = 0f;
        horizontal = 0f;
    }
}