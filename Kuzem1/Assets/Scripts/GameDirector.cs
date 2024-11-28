using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;
    public CoinManager coinManager;
    public FxManager fxManager;
    public Player player;
     void Start()
    {
        ReStartLevel();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReStartLevel();
        }
    }
    private void ReStartLevel()
    {
        player.ReStartPlayer();
        enemyManager.ReStartEnemyManager();
    }

    public void LevelFailed()
    {

    }
}
