using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminManager : MonoBehaviour
{
    public GameDirector gameDirector;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            PlayerPrefs.SetInt("HighestLevelReached", 1);
            gameDirector.ReStartLevel();
        }
    }
}
