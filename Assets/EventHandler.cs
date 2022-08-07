using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Item
{
    None,
    TimeSwaper,
    TimeChipPast,
    TimeChipPresent,
    TimeChipFuture,
    OpenPaper
}
public class EventHandler : MonoBehaviour
{
    public List<Item> items;
    public List<GameObject> uiItem;
    public ActionEvent currentEvent;

    public GameObject TimeSwaper;
    public GameObject searching;
    public void Interact()
    {
        if (currentEvent != ActionEvent.None)
        {
            if (items[(int)currentEvent] != Item.OpenPaper)
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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Interact();
        }
        searching.SetActive(currentEvent != ActionEvent.None);
    }
}
