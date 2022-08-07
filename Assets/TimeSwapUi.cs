using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeCurrent
{
    Past,
    Present,
    Future
}
public class TimeSwapUi : MonoBehaviour
{
    private float startMouseDownDirection;
    private float startRotationDirection;
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

    public Animator colorTriggerChanger;

    public TimeCurrent time;
    public TimeCurrent timeCurrent;
    //private Vector2 endMouseDownDirection;
    private bool isRotation;
    public bool isAktive;

    public Transform translateTime;
    private float timeAddTimeChange = 0f;
    public GameObject pastCollider;
    public GameObject presentCollider;
    public GameObject futureCollider;
    public Transform pastSprites;
    public Transform presentSprites;
    public Transform futureSprites;
    void Start()
    {

    }
    public void TimeChange()
    {
        if (timeCurrent == time || translateTime.gameObject.activeSelf)
            return;
        translateTime.gameObject.SetActive(true);
        translateTime.position = GameObject.Find("Player").transform.position;

        presentSprites.gameObject.SetActive(time == TimeCurrent.Present || timeCurrent == TimeCurrent.Present);
        pastSprites.gameObject.SetActive(time == TimeCurrent.Past || timeCurrent == TimeCurrent.Past);
        futureSprites.gameObject.SetActive(time == TimeCurrent.Future || timeCurrent == TimeCurrent.Future);
        futureCollider.SetActive(time == TimeCurrent.Future);
        pastCollider.SetActive(time == TimeCurrent.Past);
        presentCollider.SetActive(time == TimeCurrent.Present);

        if (timeCurrent == TimeCurrent.Future)
            futureSprites.transform.position = new Vector3(0f, 0f, 0f);
        if (timeCurrent == TimeCurrent.Present)
            presentSprites.transform.position = new Vector3(0f, 0f, 0f);
        if (timeCurrent == TimeCurrent.Past)
            pastSprites.transform.position = new Vector3(0f, 0f, 0f);
        if (time == TimeCurrent.Future)
            futureSprites.transform.position = new Vector3(0f, 0f, 1f);
        if (time == TimeCurrent.Present)
            presentSprites.transform.position = new Vector3(0f, 0f, 1f);
        if (time == TimeCurrent.Past)
            pastSprites.transform.position = new Vector3(0f, 0f, 1f);
        if (timeCurrent == TimeCurrent.Past)
        {
            for (int i = 0; i < pastSprites.childCount; i++)
            {
                pastSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            }
        }
        if (timeCurrent == TimeCurrent.Present)
        {
            for (int i = 0; i < presentSprites.childCount; i++)
            {
                presentSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            }
        }
        if (timeCurrent == TimeCurrent.Future)
        {
            for (int i = 0; i < futureSprites.childCount; i++)
            {
                futureSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
            }
        }
        if (time == TimeCurrent.Past)
        {
            for (int i = 0; i < pastSprites.childCount; i++)
            {
                pastSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            }
        }
        if (time == TimeCurrent.Present)
        {
            for (int i = 0; i < presentSprites.childCount; i++)
            {
                presentSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            }
        }
        if (time == TimeCurrent.Future)
        {
            for (int i = 0; i < futureSprites.childCount; i++)
            {
                futureSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            }
        }
    }
    void Update()
    {
        if (translateTime.gameObject.activeSelf)
        {
            timeAddTimeChange += Time.deltaTime;
            translateTime.localScale = new Vector3(timeAddTimeChange * 9f, timeAddTimeChange * 9f, 1f);
            if (timeAddTimeChange >= 3f)
            {
                translateTime.localScale = new Vector3(0f, 0f, 1f);
                for (int i = 0; i < presentSprites.childCount; i++)
                {
                    presentSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
                }
                for (int i = 0; i < pastSprites.childCount; i++)
                {
                    pastSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
                }
                for (int i = 0; i < futureSprites.childCount; i++)
                {
                    futureSprites.GetChild(i).GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
                }
                presentSprites.gameObject.SetActive(time == TimeCurrent.Present);
                pastSprites.gameObject.SetActive(time == TimeCurrent.Past);
                futureSprites.gameObject.SetActive(time == TimeCurrent.Future);
                presentSprites.transform.position = Vector3.zero;
                pastSprites.transform.position = Vector3.zero;
                futureSprites.transform.position = Vector3.zero;
                timeCurrent = time;
                timeAddTimeChange = 0f;
                translateTime.gameObject.SetActive(false);
            }
        }
        presentChip.SetActive(presentChipHave);
        pastChip.SetActive(pastChipHave);
        futureChip.SetActive(futureChipHave);
        presentChipUI.SetActive(presentChipHave);
        pastChipUI.SetActive(pastChipHave);
        futureChipUI.SetActive(futureChipHave);
        transform.Find("Sprite").gameObject.SetActive(isAktive);
        ClockUI.SetActive(isAktive);

        directionIndicator.up = Camera.main.ScreenToWorldPoint(Input.mousePosition) - directionIndicator.transform.position;
        if (Input.GetMouseButtonDown(0) && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.position) < 2.2f)
        {
            isRotation = true;
            startRotationDirection = transform.localEulerAngles.z;
            startRotationDirection = directionIndicator.localEulerAngles.z;
        }
        if (Input.GetMouseButton(0) && isRotation)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, startRotationDirection + directionIndicator.localEulerAngles.z/* - startMouseDownDirection*/);
        }
        if (Input.GetMouseButtonUp(0) && isRotation)
        {
            if (pastChipHave)
            {
                if (presentChipHave)
                {
                    if (futureChipHave)
                    {
                        if (transform.localEulerAngles.z <= 45f || transform.localEulerAngles.z > 315f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                            if (!translateTime.gameObject.activeSelf)
                            {
                                time = TimeCurrent.Present;
                            }
                            colorTriggerChanger.SetTrigger("ColorKlick");
                        }
                        if (transform.localEulerAngles.z > 45f && transform.localEulerAngles.z <= 180f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, 90f);
                            if (!translateTime.gameObject.activeSelf)
                            {
                                time = TimeCurrent.Future;
                            }
                            colorTriggerChanger.SetTrigger("ColorKlick");
                        }
                        if (transform.localEulerAngles.z > 180f && transform.localEulerAngles.z <= 315f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, -90f);
                            if (!translateTime.gameObject.activeSelf)
                            {
                                time = TimeCurrent.Past;
                            }
                            colorTriggerChanger.SetTrigger("ColorKlick");
                        }
                    }
                    else
                    {
                        if (transform.localEulerAngles.z > 315f || transform.localEulerAngles.z <= 95f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                            if (!translateTime.gameObject.activeSelf)
                            {
                                time = TimeCurrent.Present;
                            }
                            colorTriggerChanger.SetTrigger("ColorKlick");
                        }
                        if (transform.localEulerAngles.z > 95f && transform.localEulerAngles.z <= 315f)
                        {
                            transform.localEulerAngles = new Vector3(0f, 0f, -90f);
                            if (!translateTime.gameObject.activeSelf)
                            {
                                time = TimeCurrent.Past;
                            }
                            colorTriggerChanger.SetTrigger("ColorKlick");
                        }
                    }
                }
                else
                {
                    if (!translateTime.gameObject.activeSelf)
                    {
                        time = TimeCurrent.Past;
                    }
                    transform.localEulerAngles = new Vector3(0f, 0f, -90f);
                    colorTriggerChanger.SetTrigger("ColorKlick");
                }
            }
            isRotation = false;
        }
    }
}