using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ActionEvent
{
    None,
    FoundNothing,
    FindTimeSwaper,
    ChipPast,
    ChipPresent,
    ChipFuture,
    OpenPaper,
    OpenLock,
    OpenNotiz,
    OpenEnigma
}
public class InterAction : MonoBehaviour
{
    [SerializeField] private ActionEvent action;
    [HideInInspector] public bool playerIsTrigger;
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsTrigger = true;
            FindObjectOfType<EventHandler>().currentEvent = action;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsTrigger = false;
            FindObjectOfType<EventHandler>().currentEvent = ActionEvent.None;
        }
    }
    
}
