using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwapUi : MonoBehaviour
{
    private float startMouseDownDirection;
    public Transform directionIndicator;
    //private Vector2 endMouseDownDirection;
    private bool isRotation;
    void Start()
    {
        
    }
    void Update()
    {
        directionIndicator.up = Camera.main.ScreenToWorldPoint(Input.mousePosition) - directionIndicator.transform.position;
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < 2.2f)
        {
            startMouseDownDirection = directionIndicator.localEulerAngles.z;
            isRotation = true;
        }
        if (Input.GetMouseButton(0) && isRotation)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, directionIndicator.rotation.eulerAngles.z - startMouseDownDirection);
        }
        if (Input.GetMouseButtonUp(0))
        {
            startMouseDownDirection = directionIndicator.localEulerAngles.z;
            isRotation = false;
        }
    }
}
