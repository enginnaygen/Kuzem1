using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public void StartEnemyManager()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            var newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector3(Random.Range(-2f,2f), 6+(1+i), 0);
        }
        
    }
}
