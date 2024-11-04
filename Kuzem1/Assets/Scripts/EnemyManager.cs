using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;

    public float enemyYSpacing = 2;
    public void StartEnemyManager()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < 10; i++)
        {
            var newEnemy = Instantiate(enemyPrefab);
            float enemyXPos = Random.Range(-2f, 2f);
            float enemyYPos = 6 + (i * enemyYSpacing);
            newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos , 0);
        }
        
    }
}
