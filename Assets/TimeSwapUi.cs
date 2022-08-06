using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwapUi : MonoBehaviour
{
    private float startMouseDownDirection;
    public Transform directionIndicator;
    public bool pastChipHave;
    public bool presentChipHave;
    public bool futureChipHave;
    public GameObject presentChipUI;
    public GameObject pastChipUI;
    public GameObject futureChipUI;
    public GameObject presentChip;
    public GameObject pastChip;
    public GameObject futureChip;
    public GameObject ClockUI;
    //private Vector2 endMouseDownDirection;
    private bool isRotation;
    public bool isAktive;
    void Start()
    {
        
    }
    void Update()
    {
        presentChip.SetActive(presentChipHave);
        pastChip.SetActive(pastChipHave);
        futureChip.SetActive(futureChipHave);
        transform.Find("Sprite").gameObject.SetActive(isAktive);
        ClockUI.SetActive(isAktive);

        directionIndicator.up = Camera.main.ScreenToWorldPoint(Input.mousePosition) - directionIndicator.transform.position;
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < 2.2f)
        {
            isRotation = true;
        }
        if (Input.GetMouseButton(0) && isRotation)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, directionIndicator.rotation.eulerAngles.z);
        }
        else
        {
        }
        if (Input.GetMouseButtonUp(0) && isRotation)
        {
            if (pastChipHave)
            {
                if (presentChipHave)
                {
                    if (futureChipHave)
                    {
                        if ((transform.localEulerAngles.z > 0f && transform.localEulerAngles.z <= 90f) || transform.localEulerAngles.z > 270f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                        }
                        if (transform.localEulerAngles.z > 120f && transform.localEulerAngles.z <= 240f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, -90f);
                        }
                        if (transform.localEulerAngles.z > 240f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                        }
                    }
                    else
                    {
                        if (transform.localEulerAngles.z > 0f && transform.localEulerAngles.z <= 180f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, 90f);
                        }
                        if (transform.localEulerAngles.z > 180f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, -90f);
                        }
                    }
                }
                else
                {
                    if (transform.localEulerAngles.z > 180f)
                    {
                        transform.localEulerAngles = new Vector3(0f, 0f, -90f);
                    }
                }
            }
            isRotation = false;
        }
    }
}