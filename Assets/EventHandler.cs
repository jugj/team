using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Item
{
    None,
    TimeSwaper,
    TimeChipPast,
    TimeChipPresent,
    TimeChipFuture
}
public class EventHandler : MonoBehaviour
{
    public List<Item> items;
    public ActionEvent currentEvent;

    public GameObject TimeSwaper;
    public GameObject searching;
    public void Interact()
    {
        if (currentEvent != ActionEvent.None)
        {
            if (items[(int)currentEvent] != Item.None)
            {
                GetItem((int)items[(int)currentEvent]);
                items.RemoveAt((int)currentEvent);
            }
        }
    }
    public void GetItem(int item)
    {
        if (item == 1)
        {
            TimeSwaper.SetActive(true);
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
