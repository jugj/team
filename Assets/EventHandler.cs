using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Item
{
    None,
    TimeSwaper,
    TimeChipPast,
    TimeChipPresent,
    TimeChipFuture,
    OpenPaper,
    OpenLock,
    OpenNotiz,
    OpenEnigma
}
public class EventHandler : MonoBehaviour
{
    public List<Item> items;
    public List<GameObject> uiItem;
    public ActionEvent currentEvent;

    public GameObject TimeSwaper;
    public GameObject searching;
    public InputField num1;
    public InputField num2;
    public InputField num3;
    public InputField num4;
    public InputField num5;
    public InputField num6;
    public InputField num7;
    public InputField num8;
    public string day1;
    public string day2;
    public string month1;
    public string month2;
    public Text PaperText;

    private float timeTilEscape = 0f;
    private bool escaped = false;
    public int levelUnlooked;
    public AudioSource sourceAudioDoor;
    private void Awake()
    {
        int day11 = Random.Range(1, 28);
        int month11 = Random.Range(1, 12);
        if (day11.ToString().Length > 1)
        {
            day1 = day11.ToString().ToCharArray()[0].ToString();
            day2 = day11.ToString().ToCharArray()[1].ToString();
        }
        else
        {
            day1 = "0";
            day2 = day11.ToString().ToCharArray()[0].ToString();
        }
        if (month11.ToString().Length > 1)
        {
            month1 = month11.ToString().ToCharArray()[0].ToString();
            month2 = month11.ToString().ToCharArray()[1].ToString();
        }
        else
        {
            month1 = "0";
            month2 = month11.ToString().ToCharArray()[0].ToString();
        }
        string year = ".1865";
        if (levelUnlooked == 2)
        {
            year = ".1445";
        }
        PaperText.text = PaperText.text.Replace("{time}", day1 + day2 + "." + month1 + month2 + year);
    }
    public void Interact()
    {
        if (currentEvent != ActionEvent.None)
        {
            if (items[(int)currentEvent] != Item.OpenPaper && items[(int)currentEvent] != Item.OpenLock && items[(int)currentEvent] != Item.OpenNotiz && items[(int)currentEvent] != Item.OpenEnigma)
            {
                for (int i = 0; i < FindObjectsOfType<InterAction>().Length; i++)
                {
                    if (FindObjectsOfType<InterAction>()[i].playerIsTrigger)
                    {
                        Destroy(FindObjectsOfType<InterAction>()[i]);
                        break;
                    }
                }
                if (items[(int)currentEvent] != Item.None)
                {
                    GetItem((int)items[(int)currentEvent]);
                }
                currentEvent = ActionEvent.None;
            }
            else
            {
                uiItem[(int)items[(int)currentEvent]].SetActive(true);
            }
        }
    }
    public void GetItem(int item)
    {
        if (item == 1)
        {
            TimeSwaper.GetComponent<TimeSwapUi>().isAktive = true;
        }
        if (item == 2)
        {
            TimeSwaper.GetComponent<TimeSwapUi>().pastChipHave = true;
        }
        if (item == 3)
        {
            TimeSwaper.GetComponent<TimeSwapUi>().presentChipHave = true;
        }
        if (item == 4)
        {
            TimeSwaper.GetComponent<TimeSwapUi>().futureChipHave = true;
        }
    }
    void Start()
    {
        
    }
    private void CheckLock()
    {
        if (levelUnlooked == 1)
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
            if (num5.text != "1")
            {
                return;
            }
            if (num6.text != "4")
            {
                return;
            }
            if (num7.text != "2")
            {
                return;
            }
            if (num8.text == "5")
            {
                escaped = true;
                sourceAudioDoor.Play();
            }
        }
        else
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
            if (num5.text != "1")
            {
                return;
            }
            if (num6.text != "7")
            {
                return;
            }
            if (num7.text != "4")
            {
                return;
            }
            if (num8.text == "5")
            {
                escaped = true;
                sourceAudioDoor.Play();
            }
        }
    }
    void Update()
    {
        if (escaped)
        {
            timeTilEscape += Time.deltaTime;
            if (timeTilEscape > 1.5f)
            {
                PlayerPrefs.SetInt($"LvL{levelUnlooked}Unlooked", 1);
                SceneManager.LoadScene(4);
            }
        }
        else
        {
            CheckLock();
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Interact();
        }
        searching.SetActive(currentEvent != ActionEvent.None);
    }
}
