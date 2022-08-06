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
    public List<Animator> actionsAnimations;
    public List<Item> items;
    public ActionEvent currentEvent;
    public void Interact()
    {
        if (currentEvent != ActionEvent.None)
           actionsAnimations[(int)currentEvent].SetBool("Happend", true);
    }
    public void GetItem(int item)
    {
        if (item == 1)
        {

        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
