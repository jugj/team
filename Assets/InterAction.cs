using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ActionEvent
{
    None,
    FindTimeSwaper,
    SearchHay,
    ActionKey
}
public class InterAction : MonoBehaviour
{
    [SerializeField] private ActionEvent action;
    private bool playerIsTrigger;
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsTrigger = true;
            FindObjectOfType<EventHandler>().currentEvent = action;
            GameObject.Find("SearchingButton").SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerIsTrigger = false;
            FindObjectOfType<EventHandler>().currentEvent = ActionEvent.None;
            GameObject.Find("SearchingButton").SetActive(false);
        }
    }
    
}
