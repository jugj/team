using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        if (PlayerPrefs.HasKey($"LvL1Unlooked"))
        {
            if (PlayerPrefs.GetInt($"LvL1Unlooked") == 1)
            {
                SceneManager.LoadScene(2);
            }
        }
        
    }
    public void Level3()
    {
        if (PlayerPrefs.HasKey($"LvL2Unlooked"))
        {
            if (PlayerPrefs.GetInt($"LvL2Unlooked") == 1)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
    public void Title()
    {
        SceneManager.LoadScene(0);
    }
}
