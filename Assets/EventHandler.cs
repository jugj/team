using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private List<Animator> actionsAnimations;
    public ActionEvent currentEvent;
    public void Interact()
    {
        if (currentEvent != ActionEvent.None)
           actionsAnimations[(int)currentEvent].SetBool("Happend", true);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
