using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrolldeaktivieren : MonoBehaviour
{
    public GameObject scroll;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r")) {
            scroll.SetActive(false);
        }
    }
}
