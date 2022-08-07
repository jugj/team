using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uilevelbutton : MonoBehaviour
{
    public int levelId;
    public Sprite aktive;
    void Start()
    {
        if (PlayerPrefs.HasKey($"LvL{levelId}Unlooked"))
        {
            if (PlayerPrefs.GetInt($"LvL{levelId}Unlooked") == 1)
            {
                GetComponent<SpriteRenderer>().sprite = aktive;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
