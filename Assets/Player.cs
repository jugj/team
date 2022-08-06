using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Input.GetAxis("Horizontal").ToString());
        GetComponent<Rigidbody2D>().AddForce(new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0f) * 3f, ForceMode2D.Impulse);
    }
}