using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;

    public float enemyYSpacing = 2;
    public Transform enemyParent;
    public void StartEnemyManager()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < 1000; i++)
        {
            var newEnemy = Instantiate(enemyPrefab, enemyParent);
            float enemyXPos = Random.Range(-2f, 2f);
            float enemyYPos = 6 + (i * enemyYSpacing);
            newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos , 0);
        }
        
    }
}
