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
        if (playerIsTrigger)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {

            }
        }
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
