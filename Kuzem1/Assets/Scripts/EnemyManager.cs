using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Enemy bossEnemyPrefab;

    public float enemyYSpacing = 2;
    public Transform enemyParent;

    [SerializeField] int spawnEnemyCount;
    public void StartEnemyManager()
    {
        StartCoroutine(EnemyGererationCoroutine());
        //SpawnEnemies();
    }

    IEnumerator EnemyGererationCoroutine()
    {
        while(true)
        {
            float randomSpawnWait = Random.Range(0f, 2f);
            yield return new WaitForSeconds(randomSpawnWait);

            if(spawnEnemyCount < 5)
            {
                if (Random.value < .75f)
                {
                    SpawnNewEnemy(-2f, 2f);
                }
                else
                {
                    SpawnTwoEnemies();
                }
            }

            else
            {
                yield return new WaitForSeconds(3f);
                SpawnBoss();
                break;
            }
           

        }
    }

    void SpawnNewEnemy(float minXpos,float maxXpos)
    {
        var newEnemy = Instantiate(enemyPrefab, enemyParent);
        float enemyXPos = Random.Range(minXpos, maxXpos);
        float enemyYPos = 4 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);

        spawnEnemyCount++;

    }

    void SpawnTwoEnemies()
    {
        SpawnNewEnemy(1f,2.2f);

        SpawnNewEnemy(-2.2f,-1f);
    }

    void SpawnBoss()
    {
        var newEnemy = Instantiate(bossEnemyPrefab, enemyParent);
        float enemyXPos = Random.Range(-2f, 2f);
        float enemyYPos = 4 * enemyYSpacing;
        newEnemy.transform.position = new Vector3(enemyXPos, enemyYPos, 0);
    }
}
