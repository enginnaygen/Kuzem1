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
    public AudioManager audioManager;

    public int levelNo;

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
        levelNo = PlayerPrefs.GetInt("HighestLevelReached");
        player.ReStartPlayer();
        enemyManager.ReStartEnemyManager();
        mainUI.CloseMainUI();
        mainUI.SetLevelText(levelNo);
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
        PlayerPrefs.SetInt("HighestLevelReached", PlayerPrefs.GetInt("HighestLevelReached") + 1);
        mainUI.LevelComplated();
    }
}
