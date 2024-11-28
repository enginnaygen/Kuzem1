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

    [SerializeField] Player player;

    [SerializeField] int totalEnemy;

    [SerializeField] List<Enemy> enemies = new List<Enemy>();

    Coroutine enemyGenerationCoroutine;
    public void ReStartEnemyManager()
    {
        DeleteEnemies();

        if (enemyGenerationCoroutine != null)
        {
            StopCoroutine(enemyGenerationCoroutine);
        }
        enemyGenerationCoroutine = StartCoroutine(EnemyGererationCoroutine());

        spawnEnemyCount = 0;

        //SpawnEnemies();
    }

    void DeleteEnemies()
    {
        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
        enemies.Clear();

    }

    IEnumerator EnemyGererationCoroutine()
    {
        while(true)
        {
            float randomSpawnWait = Random.Range(1f, 2f);
            yield return new WaitForSeconds(randomSpawnWait);

            if(spawnEnemyCount < totalEnemy)
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
        newEnemy.StartEnemy(player);
        enemies.Add(newEnemy);
        
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
        newEnemy.StartEnemy(player);
        enemies.Add(newEnemy);

    }
}
