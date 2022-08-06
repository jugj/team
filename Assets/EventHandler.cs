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
    }
    public void GetItem(int item)
    {
        Debug.Log("Fa " + item.ToString());
        if (item == 1)
        {
            TimeSwaper.SetActive(true);
            searching.SetActive(false);
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
