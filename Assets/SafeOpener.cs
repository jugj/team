using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeOpener : MonoBehaviour
{
    public InputField num1;
    public InputField num2;
    public InputField num3;
    public InputField num4;
    public InputField num5;
    public InputField num6;
    public InputField num7;
    public InputField num8;
    public Text sword1;
    public Text sword2;
    public Text sword3;
    public string day1;
    public string day2;
    public string month1;
    public string month2;
    public string year1;
    public string year2;
    public string year3;
    public string year4;
    public GameObject commbination;
    void Start()
    {
        day1 = Random.Range(0, 9).ToString();
        day2 = Random.Range(0, 9).ToString();
        month1 = Random.Range(0, 9).ToString();
        month2 = Random.Range(0, 9).ToString();
        year1 = Random.Range(0, 9).ToString();
        year2 = Random.Range(0, 9).ToString();
        year3 = Random.Range(0, 9).ToString();
        year4 = Random.Range(0, 9).ToString();
        sword1.text = day1 + day2;
        sword2.text = month1 + month2;
        sword3.text = year1 + year2 + year3 + year4;
    }
    void Update()
    {
        if (num1.text != day1)
        {
            return;
        }
        if (num2.text != day2)
        {
            return;
        }
        if (num3.text != month1)
        {
            return;
        }
        if (num4.text != month2)
        {
            return;
        }
        if (num5.text != year1)
        {
            return;
        }
        if (num6.text != year2)
        {
            return;
        }
        if (num7.text != year3)
        {
            return;
        }
        if (num8.text == year4)
        {
            commbination.SetActive(true);
            num1.text = "";
            num2.text = "";
            num3.text = "";
            num4.text = "";
            num5.text = "";
            num6.text = "";
            num7.text = "";
            num8.text = "";
        }
    }
}
