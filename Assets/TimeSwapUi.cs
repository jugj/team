using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwapUi : MonoBehaviour
{
    private float startMouseDownDirection;
    public Transform directionIndicator;
    //private Vector2 endMouseDownDirection;
    void Start()
    {
        
    }
    void Update()
    {
        directionIndicator.up = Camera.main.ScreenToWorldPoint(Input.mousePosition) - directionIndicator.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            startMouseDownDirection = transform.localEulerAngles.z;
        }
        if (Input.GetMouseButton(0))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, /*startMouseDownDirection +*/ directionIndicator.rotation.eulerAngles.z);
        }
    }
}
