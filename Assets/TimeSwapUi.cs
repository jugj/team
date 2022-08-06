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
            isRotation = true;
        }
        if (Input.GetMouseButton(0) && isRotation)
        {
            if (startMouseDownDirection == 16664f)
            {
                startMouseDownDirection = directionIndicator.localEulerAngles.z;
            }
            transform.rotation = Quaternion.Euler(0f, 0f, directionIndicator.rotation.eulerAngles.z - startMouseDownDirection);
        }
        else
        {
            startMouseDownDirection = directionIndicator.localEulerAngles.z;
        }
        if (Input.GetMouseButtonUp(0) && isRotation)
        {
            if (transform.rotation.eulerAngles.z <= 45f && transform.rotation.eulerAngles.z >= -45f)
            {
                transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            }
            if (transform.rotation.eulerAngles.z < -45f && transform.rotation.eulerAngles.z > -179.9f)
            {
                transform.localEulerAngles = new Vector3(0f, 0f, -90f);
            }
            if (transform.rotation.eulerAngles.z > 45f && transform.rotation.eulerAngles.z < 180.0f)
            {
                transform.localEulerAngles = new Vector3(0f, 0f, 90f);
            }
            isRotation = false;
        }
    }
}
