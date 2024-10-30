using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public EnemyManager enemyManager;
     void Start()
    {
        enemyManager.StartEnemyManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
