using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;
    public CoinManager coinManager;
    public FxManager fxManager;
    public Player player;
    public MainUI mainUI;

     void Start()
    {
        SetInitialLevel();
        ReStartLevel();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReStartLevel();
        }
    }
    public void ReStartLevel()
    {
        player.ReStartPlayer();
        enemyManager.ReStartEnemyManager();
        mainUI.CloseMainUI();
        mainUI.SetLevelText(PlayerPrefs.GetInt("HighestLevelReached"));
    }

    public void LevelFailed()
    {
        mainUI.LevelFailed();
    }

    public void SetInitialLevel()
    {
        int initialLevel = PlayerPrefs.GetInt("HighestLevelReached");
        if(initialLevel == 0)
        {
            initialLevel = 1;
        }
        PlayerPrefs.SetInt("HighestLevelReached", initialLevel);
    }

    public void LevelComplated()
    {
        int currentHighestLevel = PlayerPrefs.GetInt("HighestLevelReached");
        PlayerPrefs.SetInt("HighestLevelReached", currentHighestLevel++);
    }
}
