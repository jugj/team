using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rackete : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        transform.Translate((Vector2.up + new Vector2(Input.GetAxisRaw("Vertical"), 0f)) * Time.deltaTime);
    }
}
